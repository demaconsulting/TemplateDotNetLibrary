# Introduction

## Purpose

This document is the user guide for the Template DotNet Library, a demonstration project that
showcases best practices for DEMA Consulting DotNet Libraries.

## Scope

This user guide covers:

- Installation of the library
- Basic usage and examples
- API reference

# Continuous Compliance

This template follows the
[Continuous Compliance](https://github.com/demaconsulting/ContinuousCompliance) methodology, which ensures
compliance evidence is generated automatically on every CI run.

## Key Practices

- **Requirements Traceability**: Every requirement is linked to passing tests, and a trace matrix is
  auto-generated on each release
- **Linting Enforcement**: markdownlint, cspell, and yamllint are enforced before any build proceeds
- **Automated Audit Documentation**: Each release ships with generated requirements, justifications,
  trace matrix, and quality reports
- **CodeQL and SonarCloud**: Security and quality analysis runs on every build

# Installation

Install the library using the .NET CLI:

```bash
dotnet add package TemplateDotNetLibrary
```

# Usage

## Basic Usage

```csharp
using TemplateDotNetLibrary;

var demo = new Demo();
var result = demo.DemoMethod("World");
Console.WriteLine(result); // Output: Hello, World!
```

## API Reference

### Demo

The `Demo` class provides demonstration functionality for the template library.

#### Constants

##### DefaultPrefix

```csharp
public const string DefaultPrefix = "Hello";
```

The greeting prefix used when no custom prefix is specified.

#### Constructors

##### Demo()

```csharp
public Demo()
```

Initializes a new instance of the `Demo` class with the default prefix "Hello".

##### Demo(string prefix)

```csharp
public Demo(string prefix)
```

Initializes a new instance of the `Demo` class with a custom prefix.

**Parameters:**

- `prefix` (string): The prefix to use in greetings. Must not be null or empty.

**Exceptions:**

- `ArgumentNullException`: Thrown when `prefix` is null.
- `ArgumentException`: Thrown when `prefix` is an empty string.

#### Properties

##### Prefix

```csharp
public string Prefix { get; }
```

Gets the greeting prefix used by this instance.

#### Methods

##### DemoMethod

```csharp
public string DemoMethod(string name)
```

Returns a greeting message for the specified name.

**Parameters:**

- `name` (string): The name to greet. Must not be null or empty.

**Returns:**

A string containing the greeting message in the format "{prefix}, {name}!".

**Exceptions:**

- `ArgumentNullException`: Thrown when `name` is null.
- `ArgumentException`: Thrown when `name` is an empty string.

**Example:**

```csharp
var demo = new Demo();
var greeting = demo.DemoMethod("World");
// greeting = "Hello, World!"
```

# Examples

## Example 1: Basic Greeting

```csharp
using TemplateDotNetLibrary;

var demo = new Demo();
var result = demo.DemoMethod("Alice");
Console.WriteLine(result);
// Output: Hello, Alice!
```

## Example 2: Custom Prefix

```csharp
using TemplateDotNetLibrary;

var demo = new Demo("Hi");
var result = demo.DemoMethod("Alice");
Console.WriteLine(result);
// Output: Hi, Alice!
```

## Example 3: Error Handling

```csharp
using TemplateDotNetLibrary;

var demo = new Demo();
try
{
    var result = demo.DemoMethod(null);
}
catch (ArgumentNullException ex)
{
    Console.WriteLine("Name cannot be null");
}
```

## References

- [REF-1] Continuous Compliance Methodology (<https://github.com/demaconsulting/ContinuousCompliance>)
