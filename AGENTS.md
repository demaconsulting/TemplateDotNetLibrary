# Agent Quick Reference

Comprehensive guidance for AI agents working on repositories following Continuous Compliance practices.

## Available Specialized Agents

- **requirements** - Develops requirements and ensures test coverage linkage
- **technical-writer** - Creates accurate documentation following regulatory best practices
- **software-developer** - Writes production code and self-validation tests with emphasis on design-for-testability
- **test-developer** - Creates unit tests following AAA pattern
- **code-quality** - Enforces linting, static analysis, and security standards; maintains lint scripts infrastructure
- **code-review** - Assists in performing formal file reviews
- **repo-consistency** - Ensures downstream repositories remain consistent with template patterns

## Agent Selection

- To fix a bug, call the @software-developer agent with the **context** of the bug details and **goal** of resolving
  the issue while maintaining code quality.
- To add a new feature, call the @requirements agent with the **request** to define feature requirements and **context**
  of business needs and **goal** of comprehensive requirement specification.
- To write or fix tests, call the @test-developer agent with the **context** of the functionality to be tested and
  **goal** of achieving comprehensive test coverage.
- To update documentation, call the @technical-writer agent with the **context** of changes requiring documentation and
  **goal** of maintaining current and accurate documentation.
- To manage requirements and traceability, call the @requirements agent with the **context** of requirement changes and
  **goal** of maintaining compliance traceability.
- To resolve quality or linting issues, call the @code-quality agent with the **context** of quality gate failures and
  **goal** of achieving compliance standards.
- To update linting tools or scripts, call the @code-quality agent with the **context** of tool requirements and
  **goal** of maintaining quality infrastructure.
- To address security alerts or scanning issues, call the @code-quality agent with the **context** of security findings
  and **goal** of resolving vulnerabilities.
- To perform file reviews, call the @code-review agent with the **context** of files requiring review and **goal** of
  compliance verification.
- To ensure template consistency, call the @repo-consistency agent with the **context** of downstream repository
  and **goal** of maintaining template alignment.

## Quality Gate Enforcement (ALL Agents Must Verify)

Configuration files and scripts are self-documenting with their design intent and
modification policies in header comments.

1. **Linting Standards**: `./lint.sh` (Unix) or `lint.bat` (Windows) - comprehensive linting suite
2. **Build Quality**: Zero warnings (`TreatWarningsAsErrors=true`)
3. **Static Analysis**: SonarQube/CodeQL passing with no blockers
4. **Requirements Traceability**: `dotnet reqstream --enforce` passing
5. **Test Coverage**: All requirements linked to passing tests
6. **Documentation Currency**: All docs current and generated
7. **File Review Status**: All reviewable files have current reviews

## Continuous Compliance Overview

This repository follows the
[DEMA Consulting Continuous Compliance](https://github.com/demaconsulting/ContinuousCompliance)
approach, which enforces quality and compliance gates on every CI/CD run instead of as a last-mile activity.

### Core Principles

- **Requirements Traceability**: Every requirement MUST link to passing tests
- **Quality Gates**: All quality checks must pass before merge
- **Documentation Currency**: All docs auto-generated and kept current
- **Automated Evidence**: Full audit trail generated with every build

## Required Compliance Tools

### Linting Tools (ALL Must Pass)

- **markdownlint-cli2**: Markdown style and formatting enforcement
- **cspell**: Spell-checking across all text files (use `.cspell.yaml` for technical terms)
- **yamllint**: YAML structure and formatting validation
- **Language-specific linters**: Based on repository technology stack

### Quality Analysis

- **SonarQube/SonarCloud**: Code quality and security analysis
- **CodeQL**: Security vulnerability scanning (produces SARIF output)
- **Static analyzers**: Microsoft.CodeAnalysis.NetAnalyzers, SonarAnalyzer.CSharp, etc.

### Requirements & Compliance

- **ReqStream**: Requirements traceability enforcement (`dotnet reqstream --enforce`)
- **ReviewMark**: File review status enforcement
- **BuildMark**: Tool version documentation
- **VersionMark**: Version tracking across CI/CD jobs

## Project Structure Template

- `docs/` - Documentation and compliance artifacts
  - `reqstream/` - Subsystem requirements YAML files (included by root requirements.yaml)
  - `.reviewmark.yaml` - File review definitions and tracking
  - Auto-generated reports (requirements, justifications, trace matrix)
- `src/` - Source code files
- `test/` - Test files
- `pipelines/` - CI/CD pipeline definitions
- Configuration files: `.editorconfig`, `.clang-format`, `nuget.config`, etc.

## Key Configuration Files

### Essential Files (Repository-Specific)

- **`lint.sh` / `lint.bat`** - Cross-platform comprehensive linting scripts
- **`.editorconfig`** - Code formatting rules
- **`.clang-format`** - C/C++ formatting (if applicable)
- **`.cspell.yaml`** - Spell-check configuration and technical term dictionary
- **`.markdownlint-cli2.yaml`** - Markdown linting rules
- **`.yamllint.yaml`** - YAML linting configuration
- **`nuget.config`** - NuGet package sources (if .NET)
- **`package.json`** - Node.js dependencies for linting tools

### Compliance Files

- **`requirements.yaml`** - Root requirements file with includes
- **`.reviewmark.yaml`** - File review definitions and tracking
- CI/CD pipeline files with quality gate enforcement

## Continuous Compliance Workflow

### CI/CD Pipeline Stages (Standard)

1. **Lint**: `./lint.sh` or `lint.bat` - comprehensive linting suite
2. **Build**: Compile with warnings as errors
3. **Analyze**: SonarQube/SonarCloud, CodeQL security scanning
4. **Test**: Execute all tests, generate coverage reports
5. **Validate**: Tool self-validation tests
6. **Document**: Generate requirements reports, trace matrix, build notes
7. **Enforce**: Requirements traceability, file review status
8. **Publish**: Generate final documentation (Pandoc → PDF)

### Quality Gate Enforcement

All stages must pass before merge. Pipeline fails immediately on:

- Any linting errors
- Build warnings or errors
- Security vulnerabilities (CodeQL)
- Requirements without test coverage
- Outdated file reviews
- Missing documentation

## Continuous Compliance Requirements

This repository follows continuous compliance practices from
[DemaConsulting/ContinuousCompliance](https://github.com/demaconsulting/ContinuousCompliance).

### Core Requirements Traceability Rules

- **ALL requirements MUST be linked to tests** - Enforced in CI via `dotnet reqstream --enforce`
- **NOT all tests need requirement links** - Tests may exist for corner cases, design validation, failure scenarios  
- **Source filters are critical** - Platform/framework requirements need specific test evidence

For detailed requirements format, test linkage patterns, and ReqStream integration, call the @requirements agent.

## Agent Report Files

When agents need to write report files to communicate with each other or the user, follow these guidelines:

- **Naming Convention**: Use the pattern `AGENT_REPORT_xxxx.md` (e.g., `AGENT_REPORT_analysis.md`,
  `AGENT_REPORT_results.md`)
- **Purpose**: These files are for temporary inter-agent communication and should not be committed
- **Exclusions**: Files matching `AGENT_REPORT_*.md` are automatically:
  - Excluded from git (via .gitignore)
  - Excluded from markdown linting
  - Excluded from spell checking
