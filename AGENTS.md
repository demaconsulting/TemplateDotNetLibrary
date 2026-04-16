# Project Structure

```text
├── docs/
│   ├── build_notes/
│   ├── code_quality/
│   ├── code_review_plan/
│   ├── code_review_report/
│   ├── design/
│   ├── requirements_doc/
│   ├── requirements_report/
│   └── reqstream/
├── src/
│   └── {project}/
└── test/
    └── {test-project}/
```

# Codebase Navigation (ALL Agents)

When working with source code, design, or requirements artifacts, read
`docs/design/introduction.md` first. It provides the software structure,
folder layout, and companion artifact locations. Use it as the primary map
before searching the filesystem.

# Key Configuration Files

- **`.config/dotnet-tools.json`** - Local tool manifest for Continuous Compliance tools
- **`.editorconfig`** - Code formatting rules
- **`.clang-format`** - C/C++ formatting (if applicable)
- **`.cspell.yaml`** - Spell-check configuration and technical term dictionary
- **`.markdownlint-cli2.yaml`** - Markdown linting rules
- **`.yamllint.yaml`** - YAML linting configuration
- **`.reviewmark.yaml`** - File review definitions and tracking
- **`nuget.config`** - NuGet package sources (if .NET)
- **`package.json`** - Node.js dependencies for linting tools
- **`requirements.yaml`** - Root requirements file with includes
- **`pip-requirements.txt`** - Python dependencies for yamllint and yamlfix
- **`lint.sh` / `lint.bat`** - Cross-platform comprehensive linting scripts

# Standards Application (ALL Agents Must Follow)

Before performing any work, agents must read and apply the relevant standards
from `.github/standards/`. Use this matrix to determine which to load:

| Work involves...     | Load these standards                                                         |
|----------------------|------------------------------------------------------------------------------|
| Any code             | `coding-principles.md`                                                       |
| C# code              | `coding-principles.md`, `csharp-language.md`                                 |
| Any tests            | `testing-principles.md`                                                      |
| C# tests             | `testing-principles.md`, `csharp-testing.md`                                 |
| Requirements         | `software-items.md`, `reqstream-usage.md`                                    |
| Design docs          | `software-items.md`, `design-documentation.md`, `technical-documentation.md` |
| Review configuration | `software-items.md`, `reviewmark-usage.md`                                   |
| Any documentation    | `technical-documentation.md`                                                 |

Load only the standards relevant to your specific task scope.

# Agent Delegation Guidelines

The default agent should handle simple, straightforward tasks directly.
Delegate to specialized agents only for specific scenarios:

- **Light development work** (small fixes, simple features) → Call the developer agent
- **Light quality checking** (linting, basic validation) → Call the quality agent
- **Formal feature implementation** (complex, multi-step) → Call the implementation agent
- **Formal bug resolution** (complex debugging, systematic fixes) → Call the implementation agent
- **Formal reviews** (compliance verification, detailed analysis) → Call the formal-review agent
- **Template consistency** (downstream repository alignment) → Call the repo-consistency agent

## Available Specialized Agents

- **developer** - General-purpose software development agent that applies appropriate
  standards based on the work being performed
- **formal-review** - Agent for performing formal reviews using standardized review processes
- **implementation** - Orchestrator agent that manages quality implementations
  through a formal state machine workflow
- **quality** - Quality assurance agent that grades developer work against project
  standards and Continuous Compliance practices
- **repo-consistency** - Ensures downstream repositories remain consistent with
  the TemplateDotNetLibrary template patterns and best practices

# Agent Reporting (Specialized Agents Must Follow)

Specialized agents (developer, quality, implementation, code-review,
repo-consistency) MUST generate a completion report:

1. Save to `.agent-logs/{agent-name}-{subject}-{unique-id}.md`
   where `{subject}` is a kebab-case task summary (max 5 words) and
   `{unique-id}` is a short unique suffix (e.g., 8-char hex or timestamp)
2. Start with `**Result**: (SUCCEEDED|FAILED)` as the first metadata field
3. Include the agent-specific report sections defined in each agent's prompt
4. Return the summary to the caller

Result semantics for orchestrator decision-making:

- **SUCCEEDED**: Work completed and all applicable quality gates met
- **FAILED**: Work could not be completed or quality gates not met
- **INCOMPLETE**: Work cannot proceed without information only the user can
  provide (implementation agent only)

# Linting (Required Before Quality Gates)

1. **Language auto-fix**: Run language-appropriate auto-formatters
   (e.g., `dotnet format` for .NET)
2. **Markdown auto-fix**: `npx markdownlint-cli2 --fix **/*.md`
3. **YAML auto-fix**: `yamlfix .`
4. **Run full check**: `lint.bat` (Windows) or `lint.sh` (Unix)
5. **Fix remaining**: Address line length, spelling, YAML syntax manually
6. **Verify clean**: Re-run until 0 errors before quality validation

## Linting Tools (ALL Must Pass)

- **markdownlint-cli2**: Markdown style and formatting enforcement
- **cspell**: Spell-checking across all text files (use `.cspell.yaml` for technical terms)
- **yamlfix**: YAML auto-formatter (run before lint.bat to auto-fix common issues)
- **yamllint**: YAML structure and formatting validation
- **Language-specific linters**: Based on repository technology stack

# Quality Gate Enforcement (ALL Agents Must Verify)

Configuration files and scripts are self-documenting with their design intent and
modification policies in header comments.

1. **Build Quality**: Zero warnings (`TreatWarningsAsErrors=true`)
2. **Static Analysis**: SonarQube/CodeQL passing with no blockers (when configured)
3. **Test Coverage**: All requirements linked to passing tests
4. **Documentation Currency**: All docs current and generated
5. **File Review Status**: All reviewable files have current reviews

# Scope Discipline (ALL Agents Must Follow)

- **Minimum necessary changes**: Only modify files directly required by the task
- **No speculative refactoring**: Do not refactor code adjacent to the change
  unless the task explicitly requests it
- **No drive-by fixes**: If you discover pre-existing issues in files you are
  reading but not modifying, document them in the report but do not fix them
- **Declare scope upfront**: Before making changes, determine which files will be
  modified. Any file outside this scope requires explicit justification.

# Protected Configuration Files

These files contain carefully designed configuration with documented intent
in header comments. Agents MUST NOT modify them unless the task explicitly
requires it and the modification preserves the documented design intent:

- `.reviewmark.yaml`, `.cspell.yaml`, `.editorconfig`
- `.markdownlint-cli2.yaml`, `.yamllint.yaml`
- `requirements.yaml`, `lint.sh` / `lint.bat`

# Continuous Compliance Overview

This repository follows the Continuous Compliance
<https://github.com/demaconsulting/ContinuousCompliance> approach, which enforces quality and
compliance gates on every CI/CD run instead of as a last-mile activity.

## Core Principles

- **Requirements Traceability**: Every requirement MUST link to passing tests
- **Quality Gates**: All quality checks must pass before merge
- **Documentation Currency**: All docs auto-generated and kept current
- **Automated Evidence**: Full audit trail generated with every build

## Requirements & Compliance

- **ReqStream**: Requirements traceability enforcement (`dotnet reqstream --enforce`)
- **ReviewMark**: File review status enforcement
- **BuildMark**: Tool version documentation
- **VersionMark**: Version tracking across CI/CD jobs
