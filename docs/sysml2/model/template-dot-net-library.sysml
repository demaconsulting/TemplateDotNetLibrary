package TemplateDotNetLibrary {
    doc
    /*
     * TemplateDotNetLibrary is a .NET library template demonstrating DEMA Consulting
     * best practices for structuring, documenting, and testing a DotNet library.
     */

    part def TemplateDotNetLibrarySystem {
        doc /* The Template DotNet Library system as a whole. */

        comment testRef /* Test: test/DemaConsulting.TemplateDotNetLibrary.Tests/TemplateDotNetLibraryTests.cs */
        comment designRef /* Design: docs/design/template-dot-net-library.md */
        comment verificationRef /* Verification: docs/verification/template-dot-net-library.md */
        comment reqRef /* Requirements: docs/reqstream/template-dot-net-library.yaml */

        part demo : Demo;
    }
}
