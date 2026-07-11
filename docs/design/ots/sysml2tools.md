## SysML2Tools

### Purpose

DemaConsulting.SysML2Tools is used to lint and render the repository's SysML2 architecture
model. It was chosen because it is the reference implementation for the SysML v2 subset used by
this project's Continuous Compliance methodology, and it integrates directly with the same
dotnet-tool restore and CI pipeline used by the other pipeline tools.

### Features Used

- Model validation via `dotnet sysml2tools lint 'docs/sysml2/**/*.sysml'`, which reports syntax
  errors and unresolved references without producing output files
- View rendering via `dotnet sysml2tools render`, which renders every `view` declared in
  `docs/sysml2/views/design-views.sysml` to an SVG file named after the view (for example
  `SoftwareStructureView.svg`)
- Self-validation mode (`--validate`), which exercises `lint` and `render` against known fixtures

### Integration Pattern

SysML2Tools is invoked as a `dotnet tool` from two places: `lint.ps1` runs
`dotnet sysml2tools lint 'docs/sysml2/**/*.sysml'` as an early-detection lint gate, and
`.github/workflows/build.yaml` runs
`dotnet sysml2tools render --output docs/design/generated --format svg 'docs/sysml2/model/**/*.sysml' 'docs/sysml2/views/design-views.sysml'`
immediately before Pandoc compiles the Design document. It is a stateless CLI invocation — each
run reads the SysML2 source files and writes its output, and exits; there is no initialization,
configuration object, or disposal step beyond the command-line arguments supplied on each
invocation.
