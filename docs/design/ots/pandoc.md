## Pandoc

### Purpose

Pandoc (via DemaConsulting.PandocTool) is used to convert Markdown source documentation to HTML
as part of the documentation build pipeline. It was chosen as a widely adopted, well-tested
document converter that reliably renders Markdown, tables, and diagrams into standards-compliant
HTML.

### Features Used

- Markdown-to-HTML conversion for Build Notes, Code Quality, Review Plan, Review Report, Design,
  Verification, and User Guide documents
- Table-of-contents generation (`table-of-contents: true`)
- Section numbering (`number-sections: true`)
- Custom HTML templating (`template.html`) and resource-path resolution for embedded images

### Integration Pattern

Pandoc is invoked as a `dotnet tool` (`dotnet pandoc`) from `.github/workflows/build.yaml`,
driven by the `definition.yaml` manifest files under each `docs/*` folder (e.g.
`docs/design/definition.yaml`, `docs/verification/definition.yaml`) that list the ordered
`input-files` to concatenate and convert. It is a stateless CLI invocation per document type —
each run reads a manifest, produces one HTML file, and exits; there is no initialization,
configuration object, or disposal step beyond the manifest file supplied on each invocation.
