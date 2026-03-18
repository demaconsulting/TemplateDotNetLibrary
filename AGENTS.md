# Agent Quick Reference

Project-specific guidance for agents working on Template DotNet Library - a reference
implementation demonstrating best practices for DEMA Consulting .NET libraries.

## Available Specialized Agents

- **requirements** agent - Develops requirements and ensures test coverage linkage
- **technical-writer** agent - Creates accurate documentation following regulatory best practices
- **software-developer** agent - Writes production code in literate style
- **test-developer** agent - Creates unit tests following AAA pattern
- **code-quality** agent - Enforces linting, static analysis, and security standards
- **code-review** agent - Assists in performing formal file reviews
- **repo-consistency** agent - Ensures downstream repositories remain consistent with template patterns

## Agent Selection Guide

- Fix a bug → call the @software-developer agent with the **request** to fix the bug and the **context** of the
  bug details
- Add a new feature → call the @requirements agent with the **request** to define the feature requirements, then
  the @software-developer agent to implement, then the @test-developer agent to add tests
- Write a test → call the @test-developer agent with the **request** to write the test and the **context** of
  what needs to be tested
- Fix linting or static analysis issues → call the @code-quality agent with the **request** to fix the issues
  and the **context** of the errors encountered
- Update documentation → call the @technical-writer agent with the **request** to update the documentation and
  the **context** of what needs to change
- Add or update requirements → call the @requirements agent with the **request** to add or update requirements
  and the **context** of the feature details
- Ensure test coverage linkage in `requirements.yaml` → call the @requirements agent with the **request** to
  ensure test coverage linkage and the **context** of the current coverage gaps
- Run security scanning or address CodeQL alerts → call the @code-quality agent with the **request** to address
  security scanning or CodeQL alerts and the **context** of the alerts found
- Perform a formal file review → call the @code-review agent with the **request** to perform a formal review and
  the **context** of the review-set name
- Propagate template changes → call the @repo-consistency agent with the **request** to propagate template
  changes and the **context** of the downstream repository

## Tech Stack

- C# 12, .NET 8.0/9.0/10.0, dotnet CLI, NuGet

## Key Files

- **`requirements.yaml`** - All requirements with test linkage (enforced via `dotnet reqstream --enforce`)
- **`.editorconfig`** - Code style (file-scoped namespaces, 4-space indent, UTF-8, LF endings)
- **`.cspell.json`, `.markdownlint-cli2.jsonc`, `.yamllint.yaml`** - Linting configs

## Requirements

- All requirements MUST be linked to tests
- Not all tests need to be linked to requirements (tests may exist for corner cases, design testing, failure-testing, etc.)
- Enforced in CI: `dotnet reqstream --requirements requirements.yaml --tests "test-results/**/*.trx" --enforce`
- When adding features: add requirement + link to test

## Test Source Filters

Test links in `requirements.yaml` can include a source filter prefix to restrict which test results count as
evidence. This is critical for platform and framework requirements - **do not remove these filters**.

- `windows@TestName` - proves the test passed on a Windows platform
- `ubuntu@TestName` - proves the test passed on a Linux (Ubuntu) platform
- `net8.0@TestName` - proves the test passed under the .NET 8 runtime
- `net9.0@TestName` - proves the test passed under the .NET 9 runtime
- `net10.0@TestName` - proves the test passed under the .NET 10 runtime

Without the source filter, a test result from any platform/framework satisfies the requirement. Adding the filter
ensures the CI evidence comes specifically from the required environment.

## Testing

- **Test Naming**: `ClassName_MethodUnderTest_Scenario_ExpectedBehavior` for unit tests
- **Test Framework**: Uses MSTest for unit testing
- **Code Coverage**: Maintain high code coverage for library APIs

## Code Style

- **XML Docs**: On ALL members (public/internal/private) with spaces after `///` in summaries
- **Namespace**: File-scoped namespaces only
- **Using Statements**: Top of file only (no nested using declarations except for IDisposable)
- **String Formatting**: Use interpolated strings ($"") for clarity

## Project Structure

- **DemoClass.cs**: Example library class demonstrating API patterns
- **TemplateDotNetLibrary.csproj**: Project configuration with NuGet package settings

## Build and Test

```bash
# Build the project
dotnet build --configuration Release

# Run unit tests
dotnet test --configuration Release

# Use convenience scripts
./build.sh    # Linux/macOS
build.bat     # Windows
```

## Documentation

- **User Guide**: `docs/guide/guide.md`
- **Requirements**: `requirements.yaml` -> auto-generated docs
- **Build Notes**: Auto-generated via BuildMark
- **Code Quality**: Auto-generated via CodeQL and SonarMark
- **Trace Matrix**: Auto-generated via ReqStream
- **CHANGELOG.md**: Not present - changes are captured in the auto-generated build notes

## Markdown Link Style

- **AI agent markdown files** (`.github/agents/*.agent.md`): Use inline links `[text](url)` so URLs are
  visible in agent context
- **README.md**: Use absolute URLs (shipped in NuGet package)
- **All other markdown files**: Use reference-style links `[text][ref]` with `[ref]: url` at document end

## CI/CD

- **Quality Checks**: Markdown lint, spell check, YAML lint
- **Build**: Multi-platform (Windows/Linux/macOS)
- **CodeQL**: Security scanning
- **Documentation**: Auto-generated via Pandoc + Weasyprint

## Common Tasks

```bash
# Format code
dotnet format

# Run all linters
./lint.sh     # Linux/macOS
lint.bat      # Windows

# Pack as NuGet tool
dotnet pack --configuration Release
```

## Agent Report Files

When agents need to write report files to communicate with each other or the user, follow these guidelines:

- **Naming Convention**: Use the pattern `AGENT_REPORT_xxxx.md` (e.g., `AGENT_REPORT_analysis.md`, `AGENT_REPORT_results.md`)
- **Purpose**: These files are for temporary inter-agent communication and should not be committed
- **Exclusions**: Files matching `AGENT_REPORT_*.md` are automatically:
  - Excluded from git (via .gitignore)
  - Excluded from markdown linting
  - Excluded from spell checking
