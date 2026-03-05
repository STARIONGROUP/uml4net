// -------------------------------------------------------------------------------------------------
//  <copyright file="AssociationDiagramRenderer.cs" company="Starion Group S.A.">
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
    using System.Collections.Generic;
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

    using uml4net.Classification;
    using uml4net.Extensions;
    using uml4net.Reporting.Payload;
    using uml4net.StructuredClassifiers;

    /// <summary>
    /// The purpose of the <see cref="AssociationDiagramRenderer"/> is to render a UML association diagram
    /// that shows a class and all its first-order neighbours connected by typed properties
    /// </summary>
    public class AssociationDiagramRenderer : IAssociationDiagramRenderer
    {
        /// <summary>
        /// The (injected) <see cref="ILogger"/>
        /// </summary>
        private readonly ILogger<AssociationDiagramRenderer> logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="AssociationDiagramRenderer"/> class
        /// </summary>
        /// <param name="logger">
        /// The (injected) <see cref="ILogger"/>
        /// </param>
        public AssociationDiagramRenderer(ILogger<AssociationDiagramRenderer> logger)
        {
            this.logger = logger;
        }

        /// <summary>
        /// Renders a per-class association SVG diagram that shows the target class
        /// and all classes connected to it via typed properties, with multiplicity labels
        /// and UML notation (composition diamonds, aggregation diamonds, navigability arrows)
        /// </summary>
        /// <param name="targetClass">
        /// The <see cref="IClass"/> for which to render the association diagram
        /// </param>
        /// <param name="payload">
        /// The <see cref="HandlebarsPayload"/> that contains the UML content
        /// </param>
        /// <returns>
        /// a string that contains the per-class association diagram in SVG format,
        /// or an empty string if the class has no associations
        /// </returns>
        public string SvgRenderForClass(IClass targetClass, HandlebarsPayload payload)
        {
            var classSet = new HashSet<IClass>(payload.Classes);

            var associationEdges = this.CollectAssociationEdges(targetClass, payload.Classes, classSet);

            if (associationEdges.Count == 0)
            {
                return string.Empty;
            }

            var involvedClasses = new HashSet<IClass> { targetClass };

            foreach (var edge in associationEdges)
            {
                involvedClasses.Add(edge.OwnerClass);
                involvedClasses.Add(edge.TypeClass);
            }

            var geometryGraph = this.GenerateGeometryGraph(involvedClasses.ToList(), associationEdges);

            var svgDocument = this.GenerateSvg(geometryGraph, targetClass);

            using var ms = new MemoryStream();
            svgDocument.Write(ms);
            ms.Position = 0;
            using var reader = new StreamReader(ms);
            return reader.ReadToEnd();
        }

        /// <summary>
        /// Collects all association edges (property-based relationships) for the target class
        /// </summary>
        /// <param name="targetClass">
        /// The <see cref="IClass"/> for which to collect associations
        /// </param>
        /// <param name="allClasses">
        /// All classes in the payload
        /// </param>
        /// <param name="classSet">
        /// A <see cref="HashSet{T}"/> of all classes for fast lookup
        /// </param>
        /// <returns>
        /// A list of <see cref="AssociationEdgeInfo"/> representing all associations
        /// </returns>
        private List<AssociationEdgeInfo> CollectAssociationEdges(IClass targetClass, IEnumerable<IClass> allClasses, HashSet<IClass> classSet)
        {
            var edges = new List<AssociationEdgeInfo>();

            foreach (var property in targetClass.OwnedAttribute)
            {
                if (property.Type is IClass typeClass && classSet.Contains(typeClass))
                {
                    edges.Add(new AssociationEdgeInfo(targetClass, typeClass, property));
                }
            }

            foreach (var otherClass in allClasses)
            {
                if (otherClass == targetClass)
                {
                    continue;
                }

                foreach (var property in otherClass.OwnedAttribute)
                {
                    if (property.Type is IClass typeClass && typeClass == targetClass)
                    {
                        edges.Add(new AssociationEdgeInfo(otherClass, targetClass, property));
                    }
                }
            }

            return edges;
        }

        /// <summary>
        /// Generates a <see cref="GeometryGraph"/> for the association diagram
        /// </summary>
        /// <param name="classes">
        /// The classes to include in the graph
        /// </param>
        /// <param name="associationEdges">
        /// The association edges to include
        /// </param>
        /// <returns>
        /// an instance of <see cref="GeometryGraph"/>
        /// </returns>
        private GeometryGraph GenerateGeometryGraph(List<IClass> classes, List<AssociationEdgeInfo> associationEdges)
        {
            var geometryGraph = new GeometryGraph();

            foreach (var @class in classes)
            {
                var (height, width) = SvgDrawingHelper.EstimateBoxSize(@class.Name);

                var curve = CurveFactory.CreateRectangle(width, height, new Microsoft.Msagl.Core.Geometry.Point());

                var node = new Node(curve, @class);

                geometryGraph.Nodes.Add(node);
            }

            foreach (var assocEdge in associationEdges)
            {
                var sourceNode = geometryGraph.FindNodeByUserData(assocEdge.OwnerClass);
                var targetNode = geometryGraph.FindNodeByUserData(assocEdge.TypeClass);

                if (sourceNode != null && targetNode != null)
                {
                    var edge = new Edge(sourceNode, targetNode)
                    {
                        UserData = assocEdge
                    };

                    geometryGraph.Edges.Add(edge);
                }
            }

            var settings = new SugiyamaLayoutSettings()
            {
                LayerSeparation = 180,
                NodeSeparation = 120,
                EdgeRoutingSettings = new EdgeRoutingSettings
                {
                    EdgeRoutingMode = EdgeRoutingMode.Rectilinear,
                },
            };

            var layoutEngine = new LayeredLayout(geometryGraph, settings);
            layoutEngine.Run();

            return geometryGraph;
        }

        /// <summary>
        /// Generates an SVG document for the association diagram
        /// </summary>
        /// <param name="geometryGraph">
        /// The subject <see cref="GeometryGraph"/>
        /// </param>
        /// <param name="targetClass">
        /// The <see cref="IClass"/> that should be highlighted in the diagram
        /// </param>
        /// <returns>
        /// The generated <see cref="SvgDocument"/>
        /// </returns>
        private SvgDocument GenerateSvg(GeometryGraph geometryGraph, IClass targetClass)
        {
            var padding = 40f;

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
            svgDocument.ID = $"association-diagram-{targetClass.XmiId}";

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

            this.AddMarkerDefinitions(svgDocument, targetClass.XmiId);

            foreach (var node in geometryGraph.Nodes)
            {
                var @class = (IClass)node.UserData;
                var isTarget = @class == targetClass;

                var group = this.ConvertNodeToRectangleAndLabel(node, isTarget);

                svgDocument.Children.Add(group);
            }

            foreach (var edge in geometryGraph.Edges)
            {
                var group = this.ConvertEdgeToSvgGroup(edge, targetClass.XmiId);

                if (group != null)
                {
                    svgDocument.Children.Add(group);
                }
            }

            return svgDocument;
        }

        /// <summary>
        /// Adds SVG marker definitions for composition diamond, aggregation diamond, and navigability arrow
        /// </summary>
        /// <param name="svgDocument">
        /// The <see cref="SvgDocument"/> to add markers to
        /// </param>
        /// <param name="idPrefix">
        /// A prefix for marker IDs to ensure uniqueness
        /// </param>
        private void AddMarkerDefinitions(SvgDocument svgDocument, string idPrefix)
        {
            var compositionMarker = new SvgMarker
            {
                ID = $"composition-diamond-{idPrefix}",
                MarkerUnits = SvgMarkerUnits.StrokeWidth,
                MarkerWidth = 12,
                MarkerHeight = 8,
                RefX = 0,
                RefY = 4,
                Orient = new SvgOrient { IsAuto = true }
            };

            var compositionPath = new SvgPath
            {
                Stroke = new SvgColourServer(System.Drawing.Color.Black),
                Fill = new SvgColourServer(System.Drawing.Color.Black),
                StrokeWidth = 1,
                PathData = SvgPathBuilder.Parse("M0,4 L6,0 L12,4 L6,8 Z".AsSpan())
            };

            compositionMarker.Children.Add(compositionPath);
            svgDocument.Children.Add(compositionMarker);

            var aggregationMarker = new SvgMarker
            {
                ID = $"aggregation-diamond-{idPrefix}",
                MarkerUnits = SvgMarkerUnits.StrokeWidth,
                MarkerWidth = 12,
                MarkerHeight = 8,
                RefX = 0,
                RefY = 4,
                Orient = new SvgOrient { IsAuto = true }
            };

            var aggregationPath = new SvgPath
            {
                Stroke = new SvgColourServer(System.Drawing.Color.Black),
                Fill = new SvgColourServer(System.Drawing.Color.White),
                StrokeWidth = 1,
                PathData = SvgPathBuilder.Parse("M0,4 L6,0 L12,4 L6,8 Z".AsSpan())
            };

            aggregationMarker.Children.Add(aggregationPath);
            svgDocument.Children.Add(aggregationMarker);

            var arrowMarker = new SvgMarker
            {
                ID = $"navigable-arrow-{idPrefix}",
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
                Fill = SvgPaintServer.None,
                StrokeWidth = 1,
                PathData = SvgPathBuilder.Parse("M0,0 L10,5 L0,10".AsSpan())
            };

            arrowMarker.Children.Add(arrowPath);
            svgDocument.Children.Add(arrowMarker);
        }

        /// <summary>
        /// Converts a <see cref="Node"/> to an <see cref="SvgRectangle"/> and <see cref="SvgText"/>
        /// with optional highlighting for the target class
        /// </summary>
        /// <param name="node">
        /// The <see cref="Node"/> that represents a <see cref="IClass"/> in the association diagram
        /// </param>
        /// <param name="isTarget">
        /// Whether this node represents the target class that should be highlighted
        /// </param>
        /// <returns>
        /// the <see cref="SvgGroup"/>
        /// </returns>
        private SvgGroup ConvertNodeToRectangleAndLabel(Node node, bool isTarget)
        {
            var box = node.BoundingBox;
            var @class = (IClass)node.UserData;

            var fillColor = isTarget ? System.Drawing.Color.FromArgb(5, 166, 229) : System.Drawing.Color.White;
            var textColor = isTarget ? System.Drawing.Color.White : System.Drawing.Color.Black;

            var anchor = new SvgAnchor
            {
                Href = $"#{@class.XmiId}"
            };

            var rectangle = new SvgRectangle
            {
                X = (float)box.Left,
                Y = (float)box.Bottom,
                Width = (float)box.Width,
                Height = (float)box.Height,
                Fill = new SvgColourServer(fillColor),
                Stroke = new SvgColourServer(System.Drawing.Color.Black)
            };

            var label = new SvgText(@class.Name)
            {
                X = { (float)box.Center.X },
                Y = { (float)box.Center.Y + 4 },
                TextAnchor = SvgTextAnchor.Middle,
                FontSize = 12,
                FontFamily = "sans-serif",
                Fill = new SvgColourServer(textColor),
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

            anchor.Children.Add(rectangle);
            anchor.Children.Add(label);
            anchor.Children.Add(title);

            var group = new SvgGroup();
            group.Children.Add(anchor);

            return group;
        }

        /// <summary>
        /// Converts an <see cref="Edge"/> into an <see cref="SvgGroup"/> containing the edge path,
        /// markers, multiplicity labels, and role name
        /// </summary>
        /// <param name="edge">
        /// The subject <see cref="Edge"/> that is to be converted
        /// </param>
        /// <param name="idPrefix">
        /// A prefix for marker reference IDs
        /// </param>
        /// <returns>
        /// the resulting <see cref="SvgGroup"/>, or null if the edge has no curve
        /// </returns>
        private SvgGroup ConvertEdgeToSvgGroup(Edge edge, string idPrefix)
        {
            var curve = edge.Curve;

            if (curve == null)
            {
                return null;
            }

            var assocEdge = (AssociationEdgeInfo)edge.UserData;
            var property = assocEdge.Property;

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

                default:
                    this.logger.LogWarning("Unsupported Curve type encountered: {CurveType}", curve.GetType().FullName);
                    return null;
            }

            var svgPath = new SvgPath
            {
                Stroke = new SvgColourServer(System.Drawing.Color.Black),
                Fill = SvgPaintServer.None,
                PathData = segments,
                MarkerEnd = new Uri($"url(#navigable-arrow-{idPrefix})", UriKind.Relative)
            };

            switch (property.Aggregation)
            {
                case AggregationKind.Composite:
                    svgPath.MarkerStart = new Uri($"url(#composition-diamond-{idPrefix})", UriKind.Relative);
                    break;
                case AggregationKind.Shared:
                    svgPath.MarkerStart = new Uri($"url(#aggregation-diamond-{idPrefix})", UriKind.Relative);
                    break;
            }

            var group = new SvgGroup();

            var hitArea = new SvgPath
            {
                Stroke = new SvgColourServer(System.Drawing.Color.Transparent),
                Fill = SvgPaintServer.None,
                PathData = segments,
                StrokeWidth = 12
            };

            group.Children.Add(hitArea);
            group.Children.Add(svgPath);

            var multiplicity = property.QueryFormattedMultiplicity();

            var tooltipText = $"Source: {assocEdge.OwnerClass.Name}\n" +
                              $"Target: {assocEdge.TypeClass.Name}\n" +
                              $"Property: {(string.IsNullOrEmpty(property.Name) ? "(unnamed)" : property.Name)}\n" +
                              $"Multiplicity: {(string.IsNullOrEmpty(multiplicity) ? "(unspecified)" : multiplicity)}\n" +
                              $"Aggregation: {property.Aggregation}";

            var title = new SvgTitle
            {
                Content = tooltipText
            };

            group.Children.Add(title);
            var endPoint = curve.End;
            var penultimatePoint = this.GetPenultimatePoint(curve);
            var (labelOffsetX, labelOffsetY, anchor) = this.ComputeLabelOffset(endPoint, penultimatePoint);

            if (!string.IsNullOrEmpty(multiplicity))
            {
                var multiplicityLabel = new SvgText(multiplicity)
                {
                    X = { (float)(endPoint.X + labelOffsetX) },
                    Y = { (float)(endPoint.Y + labelOffsetY - 10) },
                    TextAnchor = anchor,
                    FontSize = 10,
                    FontFamily = "sans-serif",
                    Fill = new SvgColourServer(System.Drawing.Color.DarkBlue)
                };

                group.Children.Add(multiplicityLabel);
            }

            if (!string.IsNullOrEmpty(property.Name))
            {
                var roleLabel = new SvgText(property.Name)
                {
                    X = { (float)(endPoint.X + labelOffsetX) },
                    Y = { (float)(endPoint.Y + labelOffsetY + 4) },
                    TextAnchor = anchor,
                    FontSize = 10,
                    FontFamily = "sans-serif",
                    Fill = new SvgColourServer(System.Drawing.Color.DarkGray)
                };

                group.Children.Add(roleLabel);
            }

            return group;
        }

        /// <summary>
        /// Adds a segment to the given <see cref="SvgPathSegmentList"/> based on the specified MSAGL curve segment
        /// </summary>
        /// <param name="segments">
        /// The <see cref="SvgPathSegmentList"/> to which the SVG path segment will be added
        /// </param>
        /// <param name="segment">
        /// The MSAGL <see cref="ICurve"/> segment to convert into an SVG path segment
        /// </param>
        private void AddSegment(SvgPathSegmentList segments, ICurve segment)
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

        /// <summary>
        /// Gets the penultimate point on the curve (the point just before the end),
        /// used to determine the direction the edge approaches its target
        /// </summary>
        /// <param name="curve">
        /// The <see cref="ICurve"/> from which to extract the penultimate point
        /// </param>
        /// <returns>
        /// The penultimate <see cref="Microsoft.Msagl.Core.Geometry.Point"/>
        /// </returns>
        private Microsoft.Msagl.Core.Geometry.Point GetPenultimatePoint(ICurve curve)
        {
            switch (curve)
            {
                case Curve compound when compound.Segments.Count > 0:
                    return compound.Segments[compound.Segments.Count - 1].Start;

                case Polyline polyline:
                    var points = polyline.ToArray();
                    return points.Length >= 2 ? points[points.Length - 2] : curve.Start;

                default:
                    return curve.Start;
            }
        }

        /// <summary>
        /// Computes the label offset and text anchor based on the direction the edge
        /// approaches the target node, ensuring labels are placed away from the class box
        /// </summary>
        /// <param name="endPoint">
        /// The endpoint of the edge curve
        /// </param>
        /// <param name="penultimatePoint">
        /// The point just before the endpoint on the curve
        /// </param>
        /// <returns>
        /// A tuple of (offsetX, offsetY, textAnchor) for positioning the label
        /// </returns>
        private (double OffsetX, double OffsetY, SvgTextAnchor Anchor) ComputeLabelOffset(
            Microsoft.Msagl.Core.Geometry.Point endPoint,
            Microsoft.Msagl.Core.Geometry.Point penultimatePoint)
        {
            var dx = endPoint.X - penultimatePoint.X;
            var dy = endPoint.Y - penultimatePoint.Y;

            if (Math.Abs(dx) > Math.Abs(dy))
            {
                if (dx > 0)
                {
                    return (-20, -14, SvgTextAnchor.End);
                }

                return (20, -14, SvgTextAnchor.Start);
            }

            if (dy > 0)
            {
                return (10, -24, SvgTextAnchor.Start);
            }

            return (10, 28, SvgTextAnchor.Start);
        }

        /// <summary>
        /// Represents an association edge between two classes via a property
        /// </summary>
        private class AssociationEdgeInfo
        {
            /// <summary>
            /// Initializes a new instance of the <see cref="AssociationEdgeInfo"/> class
            /// </summary>
            /// <param name="ownerClass">
            /// The class that owns the property
            /// </param>
            /// <param name="typeClass">
            /// The class that is the type of the property
            /// </param>
            /// <param name="property">
            /// The property that defines the relationship
            /// </param>
            public AssociationEdgeInfo(IClass ownerClass, IClass typeClass, IProperty property)
            {
                this.OwnerClass = ownerClass;
                this.TypeClass = typeClass;
                this.Property = property;
            }

            /// <summary>
            /// Gets the class that owns the property
            /// </summary>
            public IClass OwnerClass { get; }

            /// <summary>
            /// Gets the class that is the type of the property
            /// </summary>
            public IClass TypeClass { get; }

            /// <summary>
            /// Gets the property that defines the relationship
            /// </summary>
            public IProperty Property { get; }
        }
    }
}
