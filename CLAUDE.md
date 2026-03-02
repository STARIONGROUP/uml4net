# CLAUDE.md

This file provides guidance to Claude Code (claude.ai/code) when working with code in this repository.

## Project Overview

uml4net is a suite of .NET libraries for deserializing UML 2.5.1 models from XMI format and supporting template-based code generation. Licensed under Apache 2.0 by Starion Group S.A.

## Build & Test Commands

```bash
# Restore, build, test
dotnet restore uml4net.sln
dotnet build uml4net.sln
dotnet test uml4net.sln --no-restore --no-build --verbosity normal

# Run a single test project
dotnet test uml4net.xmi.Tests/uml4net.xmi.Tests.csproj --no-restore --no-build --verbosity normal

# Run a single test by name
dotnet test uml4net.sln --no-restore --no-build --filter "FullyQualifiedName~TestClassName.TestMethodName"

# Build with CI flag (used in GitHub Actions)
dotnet build --no-restore /p:ContinuousIntegrationBuild=true

# Test with coverage
dotnet test uml4net.sln --no-restore --no-build --verbosity normal /p:CollectCoverage=true /p:CoverletOutput="../CoverageResults/" /p:MergeWith="../CoverageResults/coverage.json" /p:CoverletOutputFormat=\"opencover,json\"
```

**Test framework**: NUnit 4.x. Target: .NET 9.0. Libraries target .NET Standard 2.0.

## Architecture

### Project Structure

| Project | Purpose |
|---------|---------|
| **uml4net** | Core UML 2.5.1 class/interface definitions (mostly auto-generated) |
| **uml4net.xmi** | XMI reader: deserializes UML models from XMI files |
| **uml4net.Extensions** | Extension methods for code generation support |
| **uml4net.xmi.Extensions.EnterpriseArchitect** | Enterprise Architect-specific XMI handling |
| **uml4net.HandleBars** | Handlebars template helpers for code generation |
| **uml4net.CodeGenerator** | Code generation engine (uses Roslyn) |
| **uml4net.Reporting** | Report generation (HTML, Excel, SVG) |
| **uml4net.Tools** | CLI application (uses System.CommandLine) |

### Auto-Generated Code

The `uml4net` core project is predominantly auto-generated from the UML 2.5.1 specification metamodel. These directories contain generated files and **should not be manually edited**:

- `uml4net/AutoGenClasses/` — concrete UML element classes
- `uml4net/AutoGenInterfaces/` — UML element interfaces
- `uml4net/AutoGenEnumeration/` — UML enumerations
- `uml4net.xmi/AutoGenXmiReaders/` — XMI element reader classes

Generated files contain the marker: `THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!`

### Key Types & Patterns

- **Entry point**: `XmiReaderBuilder.Create().Build()` returns an `IXmiReader`
- **IElement** is the root interface for all UML elements
- **IContainerList\<T\>** manages owned element collections
- **IXmiElementCache** provides element lookup by XMI ID
- **Dependency injection**: Autofac containers configured via `XmiReaderBuilder`
- **Decorators**: Custom attributes (`[Class]`, `[Property]`, `[SubsettedProperty]`) annotate generated code with UML metamodel metadata
- Namespaces mirror UML 2.5.1 packages: `uml4net.CommonStructure`, `uml4net.Classification`, `uml4net.StructuredClassifiers`, `uml4net.Packages`, `uml4net.StateMachines`, etc.

## Code Style

- 4 spaces indentation, no tabs
- No `_` prefix on member names; use `this.` for instance members
- Use `var` unless the type is ambiguous
- Use C# type aliases (`int`, `string`, not `Int32`, `String`)
- Always wrap blocks in curly braces, even single-line
- `using` statements go inside the namespace
- **No `#region` directives**
- All public members require XML documentation (`///`)

### File Header

Every `.cs` file must have the Apache 2.0 copyright header:
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

## Git Workflow

- Default branch: `development` (never work directly on master)
- Create feature branches from `development`
- Rebase before submitting PRs
