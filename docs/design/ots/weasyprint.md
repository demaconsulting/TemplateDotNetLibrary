## WeasyPrint

### Purpose

DemaConsulting.WeasyPrintTool is used to convert HTML documents to PDF as part of the
documentation build pipeline. It was chosen as a standards-compliant HTML/CSS-to-PDF renderer
that produces consistent, printable PDF/A release artifacts from the same HTML that Pandoc
generates.

### Features Used

- HTML-to-PDF conversion for Build Notes, Code Quality, Review Plan, Review Report, Design,
  Verification, and User Guide documents
- PDF page-count and content rendering suitable for FileAssert validation of rendered text

### Integration Pattern

WeasyPrint is invoked as a `dotnet tool` (`dotnet weasyprint`) from
`.github/workflows/build.yaml` immediately after each corresponding Pandoc HTML-conversion step,
producing the final PDF release artifacts. It is a stateless CLI invocation — each run reads one
HTML file, writes one PDF file, and exits; there is no initialization, configuration object, or
disposal step beyond the input/output file paths supplied on each invocation.
