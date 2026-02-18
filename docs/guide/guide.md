# Introduction

This is the Template DotNet Tool, a demonstration project that showcases best practices for
DEMA Consulting DotNet Tools.

## Installation

Install the tool globally using the .NET CLI:

```bash
dotnet tool install -g DemaConsulting.TemplateDotNetTool
```

## Usage

### Display Version

Display the tool version:

```bash
templatetool --version
```

### Display Help

Display usage information:

```bash
templatetool --help
```

### Run Self-Validation

Run self-validation tests:

```bash
templatetool --validate
```

Save validation results to a file:

```bash
templatetool --validate --results results.trx
```

### Silent Mode

Suppress console output:

```bash
templatetool --silent
```

### Logging

Write output to a log file:

```bash
templatetool --log output.log
```

## Command-Line Options

The following command-line options are supported:

| Option               | Description                                                  |
| -------------------- | ------------------------------------------------------------ |
| `-v`, `--version`    | Display version information                                  |
| `-?`, `-h`, `--help` | Display help message                                         |
| `--silent`           | Suppress console output                                      |
| `--validate`         | Run self-validation                                          |
| `--results <file>`   | Write validation results to file (TRX or JUnit format)       |
| `--log <file>`       | Write output to log file                                     |

## Examples

### Example 1: Basic Usage

```bash
templatetool
```

### Example 2: Self-Validation with Results

```bash
templatetool --validate --results validation-results.trx
```

### Example 3: Silent Mode with Logging

```bash
templatetool --silent --log tool-output.log
```
