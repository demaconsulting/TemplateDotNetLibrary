namespace TemplateDotNetLibrary;

/// <summary>
/// Demonstration class for the template library.
/// </summary>
public class DemoClass
{
    private readonly string _prefix;

    /// <summary>
    /// Initializes a new instance of the <see cref="DemoClass"/> class with default prefix.
    /// </summary>
    public DemoClass()
        : this("Hello")
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="DemoClass"/> class with a custom prefix.
    /// </summary>
    /// <param name="prefix">The prefix to use in greetings.</param>
    public DemoClass(string prefix)
    {
        ArgumentNullException.ThrowIfNull(prefix);
        _prefix = prefix;
    }

    /// <summary>
    /// Demo method that returns a greeting message.
    /// </summary>
    /// <param name="name">The name to greet.</param>
    /// <returns>A greeting message.</returns>
    public string DemoMethod(string name)
    {
        ArgumentNullException.ThrowIfNull(name);
        return $"{_prefix}, {name}!";
    }
}
