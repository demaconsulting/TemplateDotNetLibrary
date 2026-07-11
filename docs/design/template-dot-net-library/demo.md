## Demo

![Template DotNet Library Structure](TemplateDotNetLibraryView.svg)

The `Demo` class is the sole software unit in the Template DotNet Library. It serves as a
demonstration of how a DEMA Consulting .NET library class should be structured, documented,
and tested.

### Purpose

`Demo` is a simple greeting class that constructs a greeting string by combining a configurable
prefix with a caller-supplied name. It has no external dependencies and performs no I/O. Instances
are immutable after construction and are therefore safe for concurrent access.

### Data Model

| Field           | Type           | Description                                      |
|-----------------|----------------|--------------------------------------------------|
| `_prefix`       | `string`       | The greeting prefix stored at construction time. |
| `DefaultPrefix` | `const string` | The default greeting prefix (`"Hello"`).         |

### Key Methods

#### Demo()

Default constructor. Delegates to `Demo(string prefix)` with `DefaultPrefix` as the argument.

#### Demo(string prefix)

Custom-prefix constructor. Validates that `prefix` is non-null and non-empty using
`ArgumentException.ThrowIfNullOrEmpty`, then stores it in `_prefix`.

**Throws:**

- `ArgumentNullException` — when `prefix` is `null`
- `ArgumentException` — when `prefix` is an empty string

#### DemoMethod(string name)

Returns a greeting string in the format `"{prefix}, {name}!"`. Validates that `name` is
non-null and non-empty using `ArgumentException.ThrowIfNullOrEmpty`.

**Throws:**

- `ArgumentNullException` — when `name` is `null`
- `ArgumentException` — when `name` is an empty string

**Returns:** A `string` in the format `"{prefix}, {name}!"`.

#### Prefix

Read-only property that exposes `_prefix` to callers.

### Error Handling

Both the custom-prefix constructor and `DemoMethod` validate their string arguments using
`ArgumentException.ThrowIfNullOrEmpty`, which throws `ArgumentNullException` when the argument is
`null` and `ArgumentException` when the argument is an empty string. `Demo` performs no local
error handling or recovery — validation failures are detected at the point of entry and the
resulting exception propagates directly to the caller uncaught. There is no internal state to
roll back because invalid arguments are rejected before any field is assigned.

### Dependencies

N/A - Demo has no dependencies beyond the .NET base class library.

### Callers

`Demo` has no interactions with other units. It is a self-contained leaf class with no
dependencies beyond the .NET base class library. It is a public API entry point: it is invoked
externally by consumers of the Template DotNet Library package, not by any other unit within
this system.
