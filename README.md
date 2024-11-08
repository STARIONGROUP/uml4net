## Introduction

Uml4net is a suite of dotnet core libraries and tools that are used to deserialize (read) a UML version 2.5.1 model in XMI form. Uml4net is typically used to support opinionated template based code-generation and i a part of modeltopia. Uml4net porivdes a number of libraries that are described in the following sections.

# uml4net

The core library that contains all the class definitions as they appear in the UML 2.5.1 specification. Together with uml4net.xmi it provides the capability to to read UML models and make them available as an in-memory object graph.

# uml4net.Extensions

The **uml4net.Extensions** library provides extensions methods to the uml4net library to support code generation. This library is part of the uml4net ecosystem.

# uml4net.HandleBars

The **uml4net.HandleBars** library provides [HandleBars](https://github.com/Handlebars-Net/Handlebars.Net) helpers to support code generation. This library is part of the uml4net ecosystem.

# uml4net.Reporting

The **uml4net.Reporting** library contains reporting generators. This library is part of the uml4net ecosystem.

## uml4net.Tools

The **uml4net.Tools** commandline application is used to generate reports on the content of the UML model. Find the documentation [here](https://github.com/STARIONGROUP/uml4net/wiki/uml4net.Tools).

## Code Quality

[![Quality Gate Status](https://sonarcloud.io/api/project_badges/measure?project=STARIONGROUP_uml4net&metric=alert_status)](https://sonarcloud.io/summary/new_code?id=STARIONGROUP_uml4net)
[![Code Smells](https://sonarcloud.io/api/project_badges/measure?project=STARIONGROUP_uml4net&metric=code_smells)](https://sonarcloud.io/summary/new_code?id=STARIONGROUP_uml4net)
[![Coverage](https://sonarcloud.io/api/project_badges/measure?project=STARIONGROUP_uml4net&metric=coverage)](https://sonarcloud.io/summary/new_code?id=STARIONGROUP_uml4net)
[![Duplicated Lines (%)](https://sonarcloud.io/api/project_badges/measure?project=STARIONGROUP_uml4net&metric=duplicated_lines_density)](https://sonarcloud.io/summary/new_code?id=STARIONGROUP_uml4net)
[![Lines of Code](https://sonarcloud.io/api/project_badges/measure?project=STARIONGROUP_uml4net&metric=ncloc)](https://sonarcloud.io/summary/new_code?id=STARIONGROUP_uml4net)
[![Maintainability Rating](https://sonarcloud.io/api/project_badges/measure?project=STARIONGROUP_uml4net&metric=sqale_rating)](https://sonarcloud.io/summary/new_code?id=STARIONGROUP_uml4net)
[![Reliability Rating](https://sonarcloud.io/api/project_badges/measure?project=STARIONGROUP_uml4net&metric=reliability_rating)](https://sonarcloud.io/summary/new_code?id=STARIONGROUP_uml4net)
[![Security Rating](https://sonarcloud.io/api/project_badges/measure?project=STARIONGROUP_uml4net&metric=security_rating)](https://sonarcloud.io/summary/new_code?id=STARIONGROUP_uml4net)
[![Technical Debt](https://sonarcloud.io/api/project_badges/measure?project=STARIONGROUP_uml4net&metric=sqale_index)](https://sonarcloud.io/summary/new_code?id=STARIONGROUP_uml4net)
[![Vulnerabilities](https://sonarcloud.io/api/project_badges/measure?project=STARIONGROUP_uml4net&metric=vulnerabilities)](https://sonarcloud.io/summary/new_code?id=STARIONGROUP_uml4net)

## Installation

The package are available on Nuget at:

  - [uml4net](https://www.nuget.org/packages/uml4net): ![NuGet Version](https://img.shields.io/nuget/v/uml4net)
  - [uml4net.Extensions](https://www.nuget.org/packages/uml4net.Extensions): ![NuGet Version](https://img.shields.io/nuget/v/uml4net.Extensions)
  - [uml4net.xmi](https://www.nuget.org/packages/uml4net.xmi): ![NuGet Version](https://img.shields.io/nuget/v/uml4net.xmi)
  - [uml4net.HandleBars](https://www.nuget.org/packages/uml4net.HandleBars): ![NuGet Version](https://img.shields.io/nuget/v/uml4net.HandleBars)
  - [uml4net.Reporting](https://www.nuget.org/packages/uml4net.Reporting): ![NuGet Version](https://img.shields.io/nuget/v/uml4net.Reporting)
  - [uml4net.Tools](https://www.nuget.org/packages/uml4net.Tools): ![NuGet Version](https://img.shields.io/nuget/v/uml4net.Tools)

## Build Status

GitHub actions are used to build and test the uml4net libraries

Branch | Build Status
------- | :------------
Master | ![Build Status](https://github.com/STARIONGROUP/uml4net/actions/workflows/CodeQuality.yml/badge.svg?branch=master)
Development | ![Build Status](https://github.com/STARIONGROUP/uml4net/actions/workflows/CodeQuality.yml/badge.svg?branch=development)

## UML Documentation

The Object Management Gr1oup (OMG) is an international technology standards consortium. It was founded in 1989 with the goal of creating and maintaining vendor-neutral, interoperable, and portable standards for distributed computing. UML is one of the standards provided by OMG at http://www.omg.org/spec/UML/

# License

The uml4net libraries are provided to the community under the Apache License 2.0.

# Contributions

Contributions to the code-base are welcome. However, before we can accept your contributions we ask any contributor to sign the Contributor License Agreement (CLA) and send this digitaly signed to s.gerene@stariongroup.eu. You can find the CLA's in the CLA folder.

[Contribution guidelines for this project](.github/CONTRIBUTING.md)