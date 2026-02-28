namespace TemplateDotNetLibrary;

/// <summary>
///     Demonstration class for the template library.
/// </summary>
public class DemoClass
{
    private readonly string _prefix;

    /// <summary>
    ///     Initializes a new instance of the <see cref="DemoClass"/> class with default prefix.
    /// </summary>
    public DemoClass()
        : this("Hello")
    {
    }

    /// <summary>
    ///     Initializes a new instance of the <see cref="DemoClass"/> class with a custom prefix.
    /// </summary>
    /// <param name="prefix">The prefix to use in greetings.</param>
    public DemoClass(string prefix)
    {
        _prefix = prefix ?? throw new ArgumentNullException(nameof(prefix));
    }

    /// <summary>
    ///     Demo method that returns a greeting message.
    /// </summary>
    /// <param name="name">The name to greet.</param>
    /// <returns>A greeting message.</returns>
    public string DemoMethod(string name)
    {
        _ = name ?? throw new ArgumentNullException(nameof(name));
        return $"{_prefix}, {name}!";
    }
}
