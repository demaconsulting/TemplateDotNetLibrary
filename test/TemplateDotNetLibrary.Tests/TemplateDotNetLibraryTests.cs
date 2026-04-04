namespace TemplateDotNetLibrary.Tests;

/// <summary>
///     System-level integration tests for the TemplateDotNetLibrary system.
/// </summary>
[TestClass]
public class TemplateDotNetLibraryTests
{
    /// <summary>
    ///     Proves that the system can be instantiated and provides expected functionality
    ///     when integrated with all components.
    /// </summary>
    [TestMethod]
    public void TemplateDotNetLibrary_SystemIntegration_ProvidesExpectedFunctionality()
    {
        // Arrange: set up system-level integration test
        var demo = new Demo();
        const string testName = "System";

        // Act: exercise system functionality end-to-end
        var result = demo.DemoMethod(testName);

        // Assert: system produces expected integrated behavior
        Assert.AreEqual("Hello, System!", result);
    }

    /// <summary>
    ///     Proves that the system handles configuration and customization properly
    ///     across all integrated components.
    /// </summary>
    [TestMethod]
    public void TemplateDotNetLibrary_SystemCustomization_HandlesConfigurationProperly()
    {
        // Arrange: set up system with custom configuration
        const string customPrefix = "Welcome";
        var demo = new Demo(customPrefix);
        const string testName = "Integration";

        // Act: exercise system with custom configuration
        var result = demo.DemoMethod(testName);

        // Assert: system respects configuration across components
        Assert.AreEqual("Welcome, Integration!", result);
    }

    /// <summary>
    ///     Proves that the system properly validates input parameters and rejects
    ///     invalid arguments with appropriate exceptions at the system level.
    /// </summary>
    [TestMethod]
    public void TemplateDotNetLibrary_SystemValidation_RejectsInvalidInput()
    {
        // Arrange: set up system components
        var demo = new Demo();

        // Act & Assert: system validates DemoMethod null input properly
        Assert.ThrowsExactly<ArgumentNullException>(() => demo.DemoMethod(null!));

        // Act & Assert: system validates DemoMethod empty input properly
        Assert.ThrowsExactly<ArgumentException>(() => demo.DemoMethod(string.Empty));

        // Act & Assert: system validates constructor null prefix properly
        Assert.ThrowsExactly<ArgumentNullException>(() => new Demo(null!));

        // Act & Assert: system validates constructor empty prefix properly
        Assert.ThrowsExactly<ArgumentException>(() => new Demo(string.Empty));
    }
}
