# Copilot instructions for uml4net

## Build, test, and validate

Run from the repository root. CI uses the .NET 10 SDK (`actions/setup-dotnet` `10.0.x`); test and tool projects target `net10.0`, libraries target `netstandard2.0`. Tests use NUnit with central package management (`Directory.Packages.props`).

```bash
dotnet restore uml4net.sln
dotnet build uml4net.sln --no-restore
dotnet test uml4net.sln --no-restore --no-build --verbosity normal
```

Single project or single test:

```bash
dotnet test uml4net.xmi.Tests/uml4net.xmi.Tests.csproj --no-restore --no-build --verbosity normal
dotnet test uml4net.sln --no-restore --no-build --filter "FullyQualifiedName~TestClassName.TestMethodName"
```

CI build uses `dotnet build --no-restore --no-incremental /p:ContinuousIntegrationBuild=true`. Local coverage:

```bash
dotnet test uml4net.sln --no-restore --no-build --verbosity normal /p:CollectCoverage=true /p:CoverletOutput="../CoverageResults/" /p:MergeWith="../CoverageResults/coverage.json" /p:CoverletOutputFormat=\"opencover,json\"
```

CI analyses coverage with SonarCloud; the quality gate expects at least 80% coverage on new code. There is no separate lint command; `.editorconfig` and `uml4net.sln.DotSettings` carry style rules.

Do not use Python to verify the correctness of the implementation; this is a C# codebase.

## Architecture

uml4net reads and writes UML 2.5.1 models in XMI 2.5.1 and exposes them as an in-memory object graph. Downstream libraries use that graph for template-based code generation.

- `uml4net`: UML metamodel interfaces and classes. Most of it is generated. `IElement` is the root interface for all UML elements, and `IContainerList<T>` manages owned element collections. Namespaces mirror UML 2.5.1 packages (`uml4net.CommonStructure`, `uml4net.Classification`, `uml4net.StructuredClassifiers`, `uml4net.Packages`, `uml4net.StateMachines`, ...).
- `uml4net.xmi`: XMI reader and writer. Entry points are `XmiReaderBuilder.Create().Build()` returning `IXmiReader`, and `XmiWriterBuilder.Create().Build()` returning `IXmiWriter`. Both configure Autofac containers.
- `uml4net.xmi.Extensions.EnterpriseArchitect`: Enterprise Architect-specific reader extension.
- `uml4net.Extensions`, `uml4net.HandleBars`, `uml4net.CodeGenerator` (Roslyn): code generation support, Handlebars helpers, and the generation engine.
- `uml4net.Reporting`: HTML, Excel and SVG reports.
- `uml4net.Tools`: System.CommandLine CLI.

Reading is strict by default: invalid XMI throws with element, property and line position. Otherwise problems are logged and reading continues. Stereotype applications are resolved against their profile, and uncaptured content (for example UML Diagram Interchange) is kept so documents survive read-write cycles. `IXmiWriterSettings.ExternalReferenceResolution` chooses href or include for external references. `IXmiWriterSettings.UseCanonicalXmi` switches to Canonical XMI (Annex B), which uses a two-pass write in `XmiWriter`. `IXmiElementCache` provides lookup by XMI ID.

### Generated code: do not hand-edit

These directories are generated from the UML 2.5.1 metamodel and carry an "AUTOMATICALLY GENERATED" header:

- `uml4net/AutoGenClasses/`, `uml4net/AutoGenInterfaces/`, `uml4net/AutoGenEnumeration/`
- `uml4net.xmi/AutoGenXmiReaders/`, `uml4net.xmi/AutoGenXmiWriters/`

Regenerate the writers with the `[Explicit]` test `XmiWriterGeneratorTestFixture.Regenerate_AutoGenXmiWriters_of_uml4net_xmi`. Fix generator inputs or the hand-written code around them instead.

Metamodel attributes `[Class]`, `[Property]` and `[SubsettedProperty]` carry UML metadata on generated code.

## Conventions

Rules from `CLAUDE.md` and `.github/CONTRIBUTING.md`:

- 4 spaces, no tabs. No `_` prefix on members; use `this.` for instance members.
- Use `var` unless the type is unclear. Use C# aliases (`int`, `string`).
- Always use braces, even for single-line blocks.
- `using` directives go inside the namespace, `System.*` first, then alphabetical.
- No `#region` directives.
- All public members need `///` XML documentation.
- Every `.cs` file starts with this Apache 2.0 header:

```csharp
// -------------------------------------------------------------------------------------------------
// <copyright file="FileName.cs" company="Starion Group S.A.">
//
//   Copyright (C) 2019-2026 Starion Group S.A.
//
//   Licensed under the Apache License, Version 2.0 (the "License");
//   ...
// </copyright>
// ------------------------------------------------------------------------------------------------
```
- Add or update NUnit tests for new code.

Git: the default branch is `development`. Never commit to `master` or `development` directly. Branch from `development`, rebase before opening a PR, and use `.github/PULL_REQUEST_TEMPLATE.md`.

`design-decisions.md` explains deliberate choices that look surprising, such as single-valued composites exposed as `IContainerList<T>`, `UnlimitedNatural` as `string`, and the writer's property order. Read it before "fixing" these.
