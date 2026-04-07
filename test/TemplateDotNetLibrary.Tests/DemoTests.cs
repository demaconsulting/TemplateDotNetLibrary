namespace TemplateDotNetLibrary.Tests;

/// <summary>
///     Unit tests for the Demo class.
/// </summary>
[TestClass]
public class DemoTests
{
    /// <summary>
    ///     Proves that DemoMethod produces the expected "{prefix}, {name}!" format
    ///     when the default constructor is used.
    /// </summary>
    [TestMethod]
    public void Demo_DemoMethod_DefaultPrefix_ReturnsGreeting()
    {
        // Arrange: set up Demo with default constructor and test name
        var demo = new Demo();
        const string name = "World";

        // Act: call DemoMethod with test name
        var result = demo.DemoMethod(name);

        // Assert: greeting must be exactly "Hello, World!"
        Assert.AreEqual("Hello, World!", result);
    }

    /// <summary>
    ///     Proves that DemoMethod uses the custom prefix supplied at construction
    ///     time instead of the default.
    /// </summary>
    [TestMethod]
    public void Demo_DemoMethod_CustomPrefix_ReturnsGreeting()
    {
        // Arrange: set up Demo with custom prefix and test name
        var demo = new Demo("Hi");
        const string name = "Alice";

        // Act: call DemoMethod with test name
        var result = demo.DemoMethod(name);

        // Assert: greeting must use the custom prefix "Hi"
        Assert.AreEqual("Hi, Alice!", result);
    }

    /// <summary>
    ///     Proves that DemoMethod throws ArgumentNullException (not a base
    ///     ArgumentException) when a null name is supplied.
    /// </summary>
    [TestMethod]
    public void Demo_DemoMethod_NullInput_ThrowsArgumentNullException()
    {
        // Arrange: set up Demo with default constructor
        var demo = new Demo();

        // Act & Assert: exact exception type proves null is explicitly rejected
        Assert.ThrowsExactly<ArgumentNullException>(() => demo.DemoMethod(null!));
    }

    /// <summary>
    ///     Proves that DemoMethod throws ArgumentException (not ArgumentNullException)
    ///     when an empty string name is supplied.
    /// </summary>
    [TestMethod]
    public void Demo_DemoMethod_EmptyInput_ThrowsArgumentException()
    {
        // Arrange: set up Demo with default constructor
        var demo = new Demo();

        // Act & Assert: ArgumentException (not the null sub-type) must be thrown
        Assert.ThrowsExactly<ArgumentException>(() => demo.DemoMethod(string.Empty));
    }

    /// <summary>
    ///     Proves that the custom-prefix constructor throws ArgumentNullException
    ///     (not a base ArgumentException) when a null prefix is supplied.
    /// </summary>
    [TestMethod]
    public void Demo_Constructor_NullPrefix_ThrowsArgumentNullException()
    {
        // Act & Assert: exact exception type proves null is explicitly rejected
        Assert.ThrowsExactly<ArgumentNullException>(() => new Demo(null!));
    }

    /// <summary>
    ///     Proves that the custom-prefix constructor throws ArgumentException
    ///     (not ArgumentNullException) when an empty string prefix is supplied.
    /// </summary>
    [TestMethod]
    public void Demo_Constructor_EmptyPrefix_ThrowsArgumentException()
    {
        // Act & Assert: ArgumentException (not the null sub-type) must be thrown
        Assert.ThrowsExactly<ArgumentException>(() => new Demo(string.Empty));
    }

    /// <summary>
    ///     Proves that the DefaultPrefix constant exposes the value "Hello",
    ///     which is the expected default greeting prefix.
    /// </summary>
    [TestMethod]
    public void Demo_DefaultPrefix_IsHello()
    {
        // Arrange: set expected value
        const string expected = "Hello";

        // Act: read the public constant directly
        var actual = Demo.DefaultPrefix;

        // Assert: constant value must not silently change
        Assert.AreEqual(expected, actual);
    }

    /// <summary>
    ///     Proves that the Prefix property returns the custom value provided to
    ///     the constructor, confirming the property reflects what was stored.
    /// </summary>
    [TestMethod]
    public void Demo_Prefix_WithCustomConstruction_ReturnsCustomPrefix()
    {
        // Arrange: set up Demo with custom prefix
        const string customPrefix = "Greetings";
        var demo = new Demo(customPrefix);

        // Act: read the Prefix property
        var actual = demo.Prefix;

        // Assert: Prefix must exactly match the value passed at construction
        Assert.AreEqual(customPrefix, actual);
    }

    /// <summary>
    ///     Proves that the default constructor stores DefaultPrefix in the Prefix
    ///     property, tying the constant and the property together explicitly.
    /// </summary>
    [TestMethod]
    public void Demo_DefaultConstructor_WithNoArgs_SetsDefaultPrefix()
    {
        // Arrange: set up Demo with default constructor
        var demo = new Demo();

        // Act: read the Prefix property
        var actual = demo.Prefix;

        // Assert: default constructor must yield exactly Demo.DefaultPrefix
        Assert.AreEqual(Demo.DefaultPrefix, actual);
    }
}
