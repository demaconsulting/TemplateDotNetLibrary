# Agent Quick Reference

Project-specific guidance for agents working on Template DotNet Tool - a reference
implementation demonstrating best practices for DEMA Consulting .NET CLI tools.

## Available Specialized Agents

- **Requirements Agent** - Develops requirements and ensures test coverage linkage
- **Technical Writer** - Creates accurate documentation following regulatory best practices
- **Software Developer** - Writes production code and self-validation tests in literate style
- **Test Developer** - Creates unit and integration tests following AAA pattern
- **Code Quality Agent** - Enforces linting, static analysis, and security standards
- **Repo Consistency Agent** - Ensures downstream repositories remain consistent with template patterns

## Tech Stack

- C# 12, .NET 8.0/9.0/10.0, dotnet CLI, NuGet

## Key Files

- **`requirements.yaml`** - All requirements with test linkage (enforced via `dotnet reqstream --enforce`)
- **`.editorconfig`** - Code style (file-scoped namespaces, 4-space indent, UTF-8+BOM, LF endings)
- **`.cspell.json`, `.markdownlint-cli2.jsonc`, `.yamllint.yaml`** - Linting configs

## Requirements

- All requirements MUST be linked to tests (prefer `TemplateTool_*` self-validation tests)
- Not all tests need to be linked to requirements (tests may exist for corner cases, design testing, failure-testing, etc.)
- Enforced in CI: `dotnet reqstream --requirements requirements.yaml --tests "test-results/**/*.trx" --enforce`
- When adding features: add requirement + link to test

## Testing

- **Test Naming**: `TemplateTool_MethodUnderTest_Scenario` for self-validation tests
- **Self-Validation**: All tests run via `--validate` flag and can output TRX/JUnit format
- **Test Framework**: Uses DemaConsulting.TestResults library for test result generation

## Code Style

- **XML Docs**: On ALL members (public/internal/private) with spaces after `///` in summaries
- **Errors**: `ArgumentException` for parsing, `InvalidOperationException` for runtime issues
- **Namespace**: File-scoped namespaces only
- **Using Statements**: Top of file only (no nested using declarations except for IDisposable)
- **String Formatting**: Use interpolated strings ($"") for clarity

## Project Structure

- **Context.cs**: Handles command-line argument parsing, logging, and output
- **Program.cs**: Main entry point with version/help/validation routing
- **Validation.cs**: Self-validation tests with TRX/JUnit output support

## Build and Test

```bash
# Build the project
dotnet build --configuration Release

# Run unit tests
dotnet test --configuration Release

# Run self-validation
dotnet run --project src/DemaConsulting.TemplateDotNetTool \
  --configuration Release --framework net10.0 --no-build -- --validate

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

- **AI agent markdown files** (`.github/agents/*.md`): Use inline links `[text](url)` so URLs are visible in agent context
- **README.md**: Use absolute URLs (shipped in NuGet package)
- **All other markdown files**: Use reference-style links `[text][ref]` with `[ref]: url` at document end

## CI/CD

- **Quality Checks**: Markdown lint, spell check, YAML lint
- **Build**: Multi-platform (Windows/Linux)
- **CodeQL**: Security scanning
- **Integration Tests**: .NET 8/9/10 on Windows/Linux
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
