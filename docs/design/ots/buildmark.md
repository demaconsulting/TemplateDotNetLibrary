## BuildMark

### Purpose

DemaConsulting.BuildMark is used to generate build-notes documentation from GitHub Actions
metadata. It was chosen because it queries the GitHub API directly, giving the pipeline a
single source of truth for workflow-run details (commits, issues, pull requests) without
requiring hand-maintained release notes.

### Features Used

- Markdown build-notes report generation from GitHub Actions workflow-run metadata
- Git integration for reading version tags and commit history
- Issue tracking integration for including linked GitHub issues and pull requests
- Rules-based routing of items into report sections
- Known-issues reporting (inclusion of open bugs in the generated report)

### Integration Pattern

BuildMark is invoked as a `dotnet tool` (`dotnet buildmark`) from the `.github/workflows/build.yaml`
CI workflow during the build-docs job to produce
`docs/build_notes/generated/build_notes.md`. It is a stateless CLI invocation — each run reads
its inputs, writes its markdown output, and exits; there is no initialization, configuration
object, or disposal step beyond the command-line arguments supplied on each invocation.
