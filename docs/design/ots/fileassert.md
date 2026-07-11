## FileAssert

### Purpose

DemaConsulting.FileAssert is used to validate generated documents (HTML and PDF) produced during
the documentation build, asserting that each document exists and contains expected content. It
was chosen because it provides a single declarative mechanism for confirming that Pandoc and
WeasyPrint produced meaningful, correctly formed output at every stage of the pipeline.

### Features Used

- File-existence assertions (glob-pattern based)
- Text-content assertions (`contains`) against generated HTML and PDF files
- TRX test-results generation (`--results`) so FileAssert's own self-validation and its
  document-assertion runs both feed ReqStream traceability

### Integration Pattern

FileAssert is invoked as a `dotnet tool` (`dotnet fileassert`) from
`.github/workflows/build.yaml` after each Pandoc/WeasyPrint conversion step (Build Notes, Code
Quality, Review Plan, Review Report, Design, Verification, and User Guide documents), and via
`.fileassert.yaml` for its self-validation configuration. It is a stateless CLI invocation —
each run reads a configuration/target file, asserts, and exits with a pass/fail code; there is
no initialization, long-lived configuration object, or disposal step.
