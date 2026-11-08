package TemplateDotNetLibrary {
    private import SoftwareItemMetadata::*;

    part def Demo {
        doc /* Demonstration greeting class showing how a DEMA Consulting .NET library class should be structured, documented, and tested. */

        metadata info : SoftwareInfo {
            description = "Demonstration greeting class showing how a DEMA Consulting .NET library class should be structured, documented, and tested.";
            sourceFiles = ("src/DemaConsulting.TemplateDotNetLibrary/Demo.cs");
            testFiles = ("test/DemaConsulting.TemplateDotNetLibrary.Tests/DemoTests.cs");
            designFiles = ("docs/design/template-dot-net-library/demo.md");
            verificationFiles = ("docs/verification/template-dot-net-library/demo.md");
            requirementFiles = ("docs/reqstream/template-dot-net-library/demo.yaml");
        }
    }
}
