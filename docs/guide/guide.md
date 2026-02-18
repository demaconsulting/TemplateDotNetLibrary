# Introduction

This is the Template DotNet Library, a demonstration project that showcases best practices for
DEMA Consulting DotNet Libraries.

## Installation

Install the library using the .NET CLI:

```bash
dotnet add package TemplateDotNetLibrary
```

## Usage

### Basic Usage

```csharp
using TemplateDotNetLibrary;

var demo = new DemoClass();
var result = demo.DemoMethod("World");
Console.WriteLine(result); // Output: Hello, World!
```

### API Reference

#### DemoClass

The `DemoClass` provides demonstration functionality for the template library.

##### Methods

###### DemoMethod

```csharp
public string DemoMethod(string name)
```

Returns a greeting message for the specified name.

**Parameters:**

- `name` (string): The name to greet. Must not be null.

**Returns:**

A string containing the greeting message in the format "Hello, {name}!".

**Exceptions:**

- `ArgumentNullException`: Thrown when `name` is null.

**Example:**

```csharp
var demo = new DemoClass();
var greeting = demo.DemoMethod("World");
// greeting = "Hello, World!"
```

## Examples

### Example 1: Basic Greeting

```csharp
using TemplateDotNetLibrary;

var demo = new DemoClass();
var result = demo.DemoMethod("Alice");
Console.WriteLine(result);
// Output: Hello, Alice!
```

### Example 2: Error Handling

```csharp
using TemplateDotNetLibrary;

var demo = new DemoClass();
try
{
    var result = demo.DemoMethod(null);
}
catch (ArgumentNullException ex)
{
    Console.WriteLine("Name cannot be null");
}
```
