# Design decisions

This document records deliberate choices in uml4net that can look surprising at first. Each one gives the reason
and, where applicable, the issue that discusses it.

## Object model (`uml4net`)

### Single-valued composite properties are `IContainerList<T>`

A composite property is generated as `IContainerList<T>` even when its upper bound is 1. Examples are
`Constraint::specification [1..1]` and `Property::defaultValue [0..1]`; 86 properties in all.

`ContainerList<T>` is what sets the owner of an element that is added to it. Owner ends (#432), the readers, the
writers and the reference closure all handle containment through this one type. A separate single-valued type would
need a second ownership mechanism, and changing it now would break the API of 86 properties.

The list of a single-valued composite enforces the upper bound: adding a second value throws an
`InvalidOperationException` that names the property. A document that repeats the value is reported by the reader, an
`XmiReadException` in strict mode, an error log otherwise, and the first value is kept (#480).

### `UnlimitedNatural` is a `string`

Values of type `UnlimitedNatural`, such as `LiteralUnlimitedNatural::value` and `MultiplicityElement::upper`, are
strings, with `"*"` for unlimited. The string keeps the XMI representation, so a value is written exactly as it was
read.

For calculations, the extension methods return an `int`. `QueryUpperValue()`, for example, returns `int.MaxValue`
for `*`.

The typed tagged values of a stereotype application follow that convention: an `UnlimitedNatural` tagged value is an
`int`, with `int.MaxValue` for `*` (#465).

### `Classifier::useCase` is exposed as `UseCases`

A C# member cannot have the name of its enclosing type (CS0542), and `UseCase` is itself a `Classifier`. When the name
of a property equals the name of the class, the code generator adds an `s` to the property name.

### The opposite ends of non-composite associations are stored independently

The two ends of a non-composite association are separate properties: setting one does not set the other. Examples are
`Association::memberEnd` and `Property::association`, and `ActivityEdge::source` and `ActivityNode::outgoing`.

A model that is read is consistent, because the tools write both ends. A model built in code can be one-sided.
Keeping the ends in sync is tracked in #479.

Owner ends, the opposites of composite properties, are different: they are set on containment (#432).

## Writing XMI (`uml4net.xmi`)

### Write as read

Unless Canonical XMI is requested, the writer writes the model as it was read:
- the `xmi:id`s and `xmi:uuid`s are not changed;
- the document-level content is written back: documentation, extensions, MOF tags, stereotype applications, and the
  content captured without being processed.

### Properties in alphabetical order

The properties of an element are written in alphabetical order, not superclass first as in the OMG documents. XMI
2.5.1 rule 9.5.2 2a allows any order under the default schema, and byte-comparability with the OMG documents is not a
goal (#380).

### `xmi:type` on `href` reference elements

A reference to an element of another document is written as `<type xmi:type="uml:Class" href="..."/>`. Rule 9.5.2 2c
leaves `xmi:type` out of a reference element, but the Eclipse UML2 and Enterprise Architect exports, and several OMG
documents (StandardProfile, UMLDI, DD), write it. An EMF-based tool needs it to create the proxy of a reference typed
by an abstract metaclass (#380).

### Owner ends are not written

The opposite of a composite property, such as `Type::package` or `Property::class`, is implied by the nesting of the
XML elements. It is not written, as XMI 2.5.1 clause 9 prescribes and the OMG documents do (#380). On reading, it is
set from the nesting (#432).

### `xmi:documentation` and `xmi:extension` in lowercase

Inside `xmi:XMI`, in model elements and in the documentation, the lowercase elements are written, with their
`xmi:type`. XMI 2.5.1 clause 7.5.3 reserves the uppercase forms for the root element of a document (#377).

### `exporterID` is kept

Enterprise Architect writes `exporterID` in the documentation of every export. It is not part of the XMI 2.5.1
Documentation class, but it is read and written back so that the documentation of an Enterprise Architect model
survives a read-write cycle (#379).

### Unprocessed content is captured as raw XML

Document-level content that uml4net does not model, such as UML Diagram Interchange, is captured verbatim and written
back unchanged (#370, #466). A typed Diagram Interchange model is #470.

### Stereotype applications are regenerated

Stereotype applications are resolved against their profile and written from that resolved state, so that an
application created or changed in code is written. A tagged value that cannot be typed is written as it was read
(#465).

## Conformance

### XML Schema validity is not a requirement

The documents that are read and written are not validated against the XMI XML Schema. Neither the OMG documents nor
the tool exports are all schema-valid, and no reader validates them either. A finding that concerns only the schema
is not a defect (decision of 2026-09-28).

### XMI differences are not supported

`xmi:difference` elements (Add, Replace, Delete) are skipped with an information log. They are an optional
compliance point, no sample document uses them, and the example of the specification is inconsistent (#384).

## Dependencies

### `Microsoft.Extensions.Logging.Abstractions` is kept at a low floor

`Microsoft.Extensions.Logging.Abstractions` is referenced at 6.0.0 so that uml4net does not force its users to
upgrade their Microsoft.Extensions stack. NuGet unifies to the highest version in the consumer's graph. The nightly
NuGet reference check ignores the package, and Dependabot does not manage NuGet (#327, #477).
