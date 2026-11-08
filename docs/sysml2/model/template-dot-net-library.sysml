package TemplateDotNetLibrary {
    private import SoftwareItemMetadata::*;

    doc
    /*
     * TemplateDotNetLibrary is a .NET library template demonstrating DEMA Consulting
     * best practices for structuring, documenting, and testing a DotNet library.
     */

    part def TemplateDotNetLibrarySystem {
        doc /* The Template DotNet Library system as a whole. */

        metadata info : SoftwareInfo {
            description = "The Template DotNet Library system as a whole.";
            testFiles = ("test/DemaConsulting.TemplateDotNetLibrary.Tests/TemplateDotNetLibraryTests.cs");
            designFiles = ("docs/design/template-dot-net-library.md");
            verificationFiles = ("docs/verification/template-dot-net-library.md");
            requirementFiles = ("docs/reqstream/template-dot-net-library.yaml");
        }

        part demo : Demo;
    }
}
