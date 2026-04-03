# Demo

<!-- TODO: This is an example design section for the Demo class. Replace with your own unit design. -->

The `Demo` class is the sole software unit in the Template DotNet Library. It serves as a
demonstration of how a DEMA Consulting .NET library class should be structured, documented,
and tested.

## Overview

<!-- TODO: Fill in for your project -->

`Demo` is a simple greeting class that constructs a greeting string by combining a configurable
prefix with a caller-supplied name. It has no external dependencies and performs no I/O.

## Data Model

<!-- TODO: Fill in for your project -->

| Field           | Type           | Description                                      |
|-----------------|----------------|--------------------------------------------------|
| `_prefix`       | `string`       | The greeting prefix stored at construction time. |
| `DefaultPrefix` | `const string` | The default greeting prefix (`"Hello"`).         |

## Methods

<!-- TODO: Fill in for your project -->

### Demo()

Default constructor. Delegates to `Demo(string prefix)` with `DefaultPrefix` as the argument.

### Demo(string prefix)

Custom-prefix constructor. Validates that `prefix` is non-null and non-empty using
`ArgumentException.ThrowIfNullOrEmpty`, then stores it in `_prefix`.

**Throws:**

- `ArgumentNullException` — when `prefix` is `null`
- `ArgumentException` — when `prefix` is an empty string

### DemoMethod(string name)

Returns a greeting string in the format `"{prefix}, {name}!"`. Validates that `name` is
non-null and non-empty using `ArgumentException.ThrowIfNullOrEmpty`.

**Throws:**

- `ArgumentNullException` — when `name` is `null`
- `ArgumentException` — when `name` is an empty string

**Returns:** A `string` in the format `"{prefix}, {name}!"`.

### Prefix

Read-only property that exposes `_prefix` to callers.

## Interactions

<!-- TODO: Fill in for your project -->

`Demo` has no interactions with other units. It is a self-contained leaf class with no
dependencies beyond the .NET base class library.
