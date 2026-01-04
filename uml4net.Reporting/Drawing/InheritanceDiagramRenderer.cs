// -------------------------------------------------------------------------------------------------
//  <copyright file="InheritanceDiagramRenderer.cs" company="Starion Group S.A.">
// 
//    Copyright (C) 2019-2026 Starion Group S.A.
// 
//    Licensed under the Apache License, Version 2.0 (the "License");
//    you may not use this file except in compliance with the License.
//    You may obtain a copy of the License at
// 
//        http://www.apache.org/licenses/LICENSE-2.0
// 
//    Unless required by applicable law or agreed to in writing, software
//    distributed under the License is distributed on an "AS IS" BASIS,
//    WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//    See the License for the specific language governing permissions and
//    limitations under the License.
// 
//  </copyright>
//  ------------------------------------------------------------------------------------------------

namespace uml4net.Reporting.Drawing
{
    using System;
    using System.IO;
    using System.Linq;

    using Microsoft.Extensions.Logging;
    using Microsoft.Msagl.Core.Geometry.Curves;
    using Microsoft.Msagl.Core.Layout;
    using Microsoft.Msagl.Core.Routing;
    using Microsoft.Msagl.Layout.Layered;

    using Svg;
    using Svg.DataTypes;
    using Svg.Pathing;
 
    using uml4net.Extensions;
    using uml4net.Reporting.Payload;
    using uml4net.StructuredClassifiers;
    using uml4net.xmi.Readers;

    /// <summary>
    /// The purpose of the <see cref="InheritanceDiagramRenderer"/> is to render a UML class diagram
    /// that shows the inheritance of the classes in a UML model
    /// </summary>
    public class InheritanceDiagramRenderer : IInheritanceDiagramRenderer
    {
        /// <summary>
        /// The (injected) <see cref="ILogger"/>
        /// </summary>
        private readonly ILogger<InheritanceDiagramRenderer> logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="InheritanceDiagramRenderer"/> class
        /// </summary>
        /// <param name="logger">
        /// The (injected) <see cref="ILogger"/>
        /// </param>
        public InheritanceDiagramRenderer(ILogger<InheritanceDiagramRenderer> logger)
        {
            this.logger = logger;
        }

        /// <summary>
        /// Renders the content of the <see cref="XmiReaderResult"/> to a stream
        /// </summary>
        /// <param name="xmiReaderResult">
        /// The <see cref="XmiReaderResult"/> that contains the UML model
        /// </param>
        /// <param name="xmiId">
        /// the unique identifier of the root package to generate
        /// </param>
        /// <param name="rootName">
        /// the name of the root package to generate
        /// </param>
        /// <param name="stream">
        /// The target <see cref="Stream"/> to write to
        /// </param>
        public void SvgRender(XmiReaderResult xmiReaderResult, string xmiId, string rootName, Stream stream)
        {
            var payload = HandlebarsPayloadFactory.CreateHandlebarsPayload(xmiReaderResult, xmiId, rootName);

            var geometryGraph = this.GenerateGeometryGraph(payload);

            var svgDocument = this.GenerateSvg(geometryGraph);

            svgDocument.Write(stream);
        }

        /// <summary>
        /// Renders the content of the <see cref="XmiReaderResult"/>
        /// </summary>
        /// <param name="xmiReaderResult">
        /// The <see cref="XmiReaderResult"/> that contains the UML model
        /// </param>
        /// <param name="xmiId">
        /// the unique identifier of the root package to generate
        /// </param>
        /// <param name="rootName">
        /// the name of the root package to generate
        /// </param>
        /// <returns>
        /// a string that contains the diagram in SVG format
        /// </returns>
        public string SvgRender(XmiReaderResult xmiReaderResult, string xmiId, string rootName)
        {
            using var ms = new MemoryStream();

            this.SvgRender(xmiReaderResult, xmiId, rootName, ms);

            ms.Position = 0;
            using var reader = new StreamReader(ms);
            return reader.ReadToEnd();
        }

        /// <summary>
        /// Generate a <see cref="GeometryGraph"/> that has a layout applied to it
        /// </summary>
        /// <param name="payload">
        /// The <see cref="HandlebarsPayload"/> that contains the UML content on the basis
        /// of which the Inheritance diagram is generated
        /// </param>
        /// <returns>
        /// an instance of <see cref="GeometryGraph"/>
        /// </returns>
        private GeometryGraph GenerateGeometryGraph(HandlebarsPayload payload)
        {
            var geometryGraph = new GeometryGraph();

            foreach (var @class in payload.Classes)
            {
                var (height, width) = SvgDrawingHelper.EstimateBoxSize(@class.Name);

                var curve = CurveFactory.CreateRectangle(width, height, new Microsoft.Msagl.Core.Geometry.Point());

                var node = new Node(curve, @class);

                geometryGraph.Nodes.Add(node);
            }

            foreach (var @class in payload.Classes)
            {
                foreach (var superClass in @class.SuperClass)
                {
                    var sourceNode = geometryGraph.FindNodeByUserData(@class);
                    var targetNode = geometryGraph.FindNodeByUserData(superClass);

                    var edge = new Edge(sourceNode, targetNode);

                    geometryGraph.Edges.Add(edge);
                }
            }

            this.logger.LogInformation("edges count: {Edges}", geometryGraph.Edges.Count);

            var settings = new SugiyamaLayoutSettings()
            {
                LayerSeparation = 30,
                NodeSeparation = 10,
                EdgeRoutingSettings = new EdgeRoutingSettings
                {
                    EdgeRoutingMode = EdgeRoutingMode.Rectilinear,
                },
            };

            var layoutEngine = new LayeredLayout(geometryGraph, settings);
            layoutEngine.Run();

            this.logger.LogInformation("edges count: {Edges}", geometryGraph.Edges.Count);

            return geometryGraph;
        }

        /// <summary>
        /// Generates and SVG document based on a <see cref="GeometryGraph"/>
        /// </summary>
        /// <param name="geometryGraph">
        /// the subject <see cref="GeometryGraph"/>
        /// </param>
        /// <returns>
        /// The generated <see cref="SvgDocument"/>
        /// </returns>
        private SvgDocument GenerateSvg(GeometryGraph geometryGraph)
        {
            var padding = 10f;

            var bbox = geometryGraph.BoundingBox;

            var width = (float)(bbox.Width + 2 * padding);
            var height = (float)(bbox.Height + 2 * padding);

            var svgDocument = new SvgDocument
            {
                Width = width,
                Height = height,
                ViewBox = new SvgViewBox(
                    (float)(bbox.Left - padding),
                    (float)(bbox.Bottom - padding),
                    width,
                    height)
            };
            svgDocument.ID = "inheritance-diagram";

            svgDocument.Children.Add(new SvgTitle
            {
                Content = "UML Inheritance Diagram"
            });

            svgDocument.Children.Add(new SvgDescription
            {
                Content = "A UML diagram showing class inheritance relationships - generated with uml4net \u00a9 2022–2025 Starion Group S.A."
            });

            var borderRect = new SvgRectangle
            {
                X = (float)(bbox.Left - padding),
                Y = (float)(bbox.Bottom - padding),
                Width = width,
                Height = height,
                Fill = SvgPaintServer.None,
                Stroke = new SvgColourServer(System.Drawing.Color.Black),
                StrokeWidth = 1
            };

            svgDocument.Children.Add(borderRect);

            var copyright = new SvgText("generated with uml4net © 2022–2025 Starion Group S.A.")
            {
                X = { svgDocument.ViewBox.MinX + 10 },
                Y = { svgDocument.ViewBox.MinY + svgDocument.ViewBox.Height - 10 },
                TextAnchor = SvgTextAnchor.Start,
                FontSize = 10,
                FontFamily = "sans-serif",
                Fill = new SvgColourServer(System.Drawing.Color.Gray)
            };

            svgDocument.Children.Add(copyright);

            var arrowMarker = new SvgMarker
            {
                ID = "generalization-arrow",
                MarkerUnits = SvgMarkerUnits.StrokeWidth,
                MarkerWidth = 10,
                MarkerHeight = 10,
                RefX = 10,
                RefY = 5,
                Orient = new SvgOrient { IsAuto = true }
            };

            var arrowPath = new SvgPath
            {
                Stroke = new SvgColourServer(System.Drawing.Color.Black),
                Fill = new SvgColourServer(System.Drawing.Color.White),
                StrokeWidth = 1,
                PathData = SvgPathBuilder.Parse("M0,0 L10,5 L0,10 Z".AsSpan())
            };

            arrowMarker.Children.Add(arrowPath);
            svgDocument.Children.Add(arrowMarker);

            foreach (var node in geometryGraph.Nodes)
            {
                var group = this.ConvertNodeToRectangleAndLabel(node);

                svgDocument.Children.Add(group);
            }

            foreach (var edge in geometryGraph.Edges)
            {
                var svgPath = this.ConvertEdgeToSvgPath(edge);
                svgDocument.Children.Add(svgPath);
            }

            return svgDocument;
        }

        /// <summary>
        /// Converts a <see cref="Node"/> to an <see cref="SvgRectangle"/> and <see cref="SvgText"/>
        /// that provides the label of the rectangle
        /// </summary>
        /// <param name="node">
        /// The <see cref="Node"/> that represents a <see cref="IClass"/> in the inheritance diagram
        /// </param>
        /// <returns>
        /// the <see cref="SvgRectangle"/> and <see cref="SvgText"/>
        /// </returns>
        private SvgGroup ConvertNodeToRectangleAndLabel(Node node)
        {
            var group = new SvgGroup();

            var box = node.BoundingBox;
            var rectangle = new SvgRectangle
            {
                X = (float)box.Left,
                Y = (float)box.Bottom,
                Width = (float)box.Width,
                Height = (float)box.Height,
                Fill = new SvgColourServer(System.Drawing.Color.White),
                Stroke = new SvgColourServer(System.Drawing.Color.Black)
            };

            var @class = (IClass)node.UserData;
            var label = new SvgText(@class.Name)
            {
                X = { (float)box.Center.X },
                Y = { (float)box.Center.Y + 4 }, // tweak to center baseline
                TextAnchor = SvgTextAnchor.Middle,
                FontSize = 12,
                FontFamily = "sans-serif",
                Fill = new SvgColourServer(System.Drawing.Color.Black),
                FontStyle = @class.IsAbstract ? SvgFontStyle.Italic : SvgFontStyle.Normal
            };

            var tooltipText = $"Name: {@class.Name}\n" +
                              $"Is Abstract: {@class.IsAbstract}\n" +
                              $"Superclasses: {string.Join(", ", @class.SuperClass.Select(c => c.Name))}\n" +
                              $"Description: {@class.QueryRawDocumentation()}";

            var title = new SvgTitle
            {
                Content = tooltipText
            };

            group.Children.Add(rectangle);
            group.Children.Add(label);
            group.Children.Add(title);

            return group;
        }

        /// <summary>
        /// Converts an <see cref="Edge"/> into an <see cref="SvgPath"/>
        /// </summary>
        /// <param name="edge">
        /// The subject <see cref="Edge"/> that is to be converted
        /// </param>
        /// <returns>
        /// the resulting <see cref="SvgPath"/>
        /// </returns>
        private SvgPath ConvertEdgeToSvgPath(Edge edge)
        {
            var curve = edge.Curve;
            if (curve == null)
            {
                return null;
            }

            var segments = new SvgPathSegmentList();

            segments.Add(new SvgMoveToSegment(false, SvgDrawingHelper.ToPointF(curve.Start)));

            switch (curve)
            {
                case Curve compound:
                    foreach (var segment in compound.Segments)
                    {
                        this.AddSegment(segments, segment);
                    }
                    break;

                case LineSegment line:
                    segments.Add(new SvgLineSegment(false, SvgDrawingHelper.ToPointF(line.End)));
                    break;

                case CubicBezierSegment bezier:
                    segments.Add(new SvgCubicCurveSegment(
                        isRelative: false,
                        SvgDrawingHelper.ToPointF(bezier.B(0)),
                        SvgDrawingHelper.ToPointF(bezier.B(1)),
                        SvgDrawingHelper.ToPointF(bezier.B(3))
                    ));
                    break;

                case Polyline polyline:
                    foreach (var point in polyline.Skip(1))
                    {
                        segments.Add(new SvgLineSegment(false, SvgDrawingHelper.ToPointF(point)));
                    }
                    break;

                case RoundedRect:
                    this.logger.LogWarning("RoundedRect is not (yet) supported");
                    break;

                case Ellipse:
                    this.logger.LogWarning("Ellipse is not (yet) supported");
                    break;

                default:
                    this.logger.LogWarning("Unsupported Curve type encountered: {CurveType}", curve.GetType().FullName);
                    return null;
            }

            return new SvgPath
            {
                Stroke = new SvgColourServer(System.Drawing.Color.Black),
                Fill = SvgPaintServer.None,
                PathData = segments,
                MarkerEnd = new Uri("url(#generalization-arrow)", UriKind.Relative)
            };
        }

        /// <summary>
        /// Adds a segment to the given <see cref="SvgPathSegmentList"/> based on the specified MSAGL curve segment.
        /// Supports <see cref="LineSegment"/> and <see cref="CubicBezierSegment"/> types.
        /// </summary>
        /// <param name="segments">
        /// The <see cref="SvgPathSegmentList"/> to which the SVG path segment will be added.
        /// </param>
        /// <param name="segment">
        /// The MSAGL <see cref="ICurve"/> segment to convert into an SVG path segment.
        /// </param>
        private  void AddSegment(SvgPathSegmentList segments, ICurve segment)
        {
            switch (segment)
            {
                case LineSegment line:
                    segments.Add(new SvgLineSegment(false, SvgDrawingHelper.ToPointF(line.End)));
                    break;

                case CubicBezierSegment bezier:
                    segments.Add(new SvgCubicCurveSegment(
                        false,
                        SvgDrawingHelper.ToPointF(bezier.B(0)),
                        SvgDrawingHelper.ToPointF(bezier.B(1)),
                        SvgDrawingHelper.ToPointF(bezier.B(3))
                    ));
                    break;

                default:
                    this.logger.LogWarning("Unsupported segment type encountered: {SegmentType}", segment.GetType().FullName);
                    break;
            }
        }
    }
}
