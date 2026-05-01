namespace TemplateDotNetLibrary.Tests;

/// <summary>
///     System-level integration tests for the TemplateDotNetLibrary system.
/// </summary>
public class TemplateDotNetLibraryTests
{
    /// <summary>
    ///     Proves that the system can be instantiated and provides expected functionality
    ///     when integrated with all components.
    /// </summary>
    [Fact]
    public void TemplateDotNetLibrary_SystemIntegration_DefaultConstruction_ReturnsExpectedGreeting()
    {
        // Arrange: set up system-level integration test
        var demo = new Demo();
        const string testName = "System";

        // Act: exercise system functionality end-to-end
        var result = demo.DemoMethod(testName);

        // Assert: system produces expected integrated behavior
        Assert.Equal("Hello, System!", result);
    }

    /// <summary>
    ///     Proves that the system handles configuration and customization properly
    ///     across all integrated components.
    /// </summary>
    [Fact]
    public void TemplateDotNetLibrary_SystemCustomization_CustomPrefix_ReturnsExpectedGreeting()
    {
        // Arrange: set up system with custom configuration
        const string customPrefix = "Welcome";
        var demo = new Demo(customPrefix);
        const string testName = "Integration";

        // Act: exercise system with custom configuration
        var result = demo.DemoMethod(testName);

        // Assert: system respects configuration across components
        Assert.Equal("Welcome, Integration!", result);
    }

    /// <summary>
    ///     Proves that the system rejects null input passed to DemoMethod
    ///     with the expected exception at the system level.
    /// </summary>
    [Fact]
    public void TemplateDotNetLibrary_SystemValidation_DemoMethodNullInput_ThrowsArgumentNullException()
    {
        // Arrange: set up system components
        var demo = new Demo();

        // Act & Assert: system validates DemoMethod null input properly
        Assert.Throws<ArgumentNullException>(() => demo.DemoMethod(null!));
    }

    /// <summary>
    ///     Proves that the system rejects empty input passed to DemoMethod
    ///     with the expected exception at the system level.
    /// </summary>
    [Fact]
    public void TemplateDotNetLibrary_SystemValidation_DemoMethodEmptyInput_ThrowsArgumentException()
    {
        // Arrange: set up system components
        var demo = new Demo();

        // Act & Assert: system validates DemoMethod empty input properly
        Assert.Throws<ArgumentException>(() => demo.DemoMethod(string.Empty));
    }

    /// <summary>
    ///     Proves that the system rejects a null constructor prefix
    ///     with the expected exception at the system level.
    /// </summary>
    [Fact]
    public void TemplateDotNetLibrary_SystemValidation_ConstructorNullPrefix_ThrowsArgumentNullException()
    {
        // Act & Assert: system validates constructor null prefix properly
        Assert.Throws<ArgumentNullException>(() => new Demo(null!));
    }

    /// <summary>
    ///     Proves that the system rejects an empty constructor prefix
    ///     with the expected exception at the system level.
    /// </summary>
    [Fact]
    public void TemplateDotNetLibrary_SystemValidation_ConstructorEmptyPrefix_ThrowsArgumentException()
    {
        // Act & Assert: system validates constructor empty prefix properly
        Assert.Throws<ArgumentException>(() => new Demo(string.Empty));
    }
}
