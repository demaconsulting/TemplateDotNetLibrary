namespace TemplateDotNetLibrary.Tests;

/// <summary>
/// Unit tests for the DemoClass.
/// </summary>
[TestClass]
public class DemoClassTests
{
    /// <summary>
    /// Test that DemoMethod returns the expected greeting with default prefix.
    /// </summary>
    [TestMethod]
    public void DemoMethod_ReturnsGreeting_WithDefaultPrefix()
    {
        // Arrange
        var demo = new DemoClass();
        const string name = "World";

        // Act
        var result = demo.DemoMethod(name);

        // Assert
        Assert.AreEqual("Hello, World!", result);
    }

    /// <summary>
    /// Test that DemoMethod returns the expected greeting with custom prefix.
    /// </summary>
    [TestMethod]
    public void DemoMethod_ReturnsGreeting_WithCustomPrefix()
    {
        // Arrange
        var demo = new DemoClass("Hi");
        const string name = "Alice";

        // Act
        var result = demo.DemoMethod(name);

        // Assert
        Assert.AreEqual("Hi, Alice!", result);
    }

    /// <summary>
    /// Test that DemoMethod throws ArgumentNullException for null input.
    /// </summary>
    [TestMethod]
    public void DemoMethod_ThrowsArgumentNullException_ForNullInput()
    {
        // Arrange
        var demo = new DemoClass();

        // Act & Assert
        _ = Assert.Throws<ArgumentNullException>(() => demo.DemoMethod(null!));
    }

    /// <summary>
    /// Test that constructor throws ArgumentNullException for null prefix.
    /// </summary>
    [TestMethod]
    public void Constructor_ThrowsArgumentNullException_ForNullPrefix()
    {
        // Act & Assert
        _ = Assert.Throws<ArgumentNullException>(() => new DemoClass(null!));
    }
}
