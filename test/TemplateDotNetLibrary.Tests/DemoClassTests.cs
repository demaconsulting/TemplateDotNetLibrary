namespace TemplateDotNetLibrary.Tests;

/// <summary>
/// Unit tests for the DemoClass.
/// </summary>
[TestClass]
public class DemoClassTests
{
    /// <summary>
    /// Test that DemoMethod returns the expected greeting.
    /// </summary>
    [TestMethod]
    public void DemoMethod_ReturnsGreeting()
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
    /// Test that DemoMethod throws ArgumentNullException for null input.
    /// </summary>
    [TestMethod]
    public void DemoMethod_ThrowsArgumentNullException_ForNullInput()
    {
        // Arrange
        var demo = new DemoClass();

        // Act & Assert
        Assert.ThrowsException<ArgumentNullException>(() => demo.DemoMethod(null!));
    }
}
