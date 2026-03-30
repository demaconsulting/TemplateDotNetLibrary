namespace TemplateDotNetLibrary;

/// <summary>
///     Demonstration class for the template library.
/// </summary>
public class Demo
{
    /// <summary>
    ///     The greeting prefix used when no custom prefix is specified.
    /// </summary>
    public const string DefaultPrefix = "Hello";

    /// <summary>
    ///     The prefix prepended to every greeting produced by this instance.
    /// </summary>
    private readonly string _prefix;

    /// <summary>
    ///     Initializes a new instance of the <see cref="Demo"/> class with the default prefix.
    /// </summary>
    /// <remarks>
    ///     The prefix is set to <see cref="DefaultPrefix"/>.
    /// </remarks>
    public Demo()
        : this(DefaultPrefix)
    {
    }

    /// <summary>
    ///     Initializes a new instance of the <see cref="Demo"/> class with a custom prefix.
    /// </summary>
    /// <param name="prefix">The prefix to use in greetings.</param>
    /// <exception cref="ArgumentNullException">
    ///     Thrown when <paramref name="prefix"/> is <see langword="null"/>.
    /// </exception>
    /// <exception cref="ArgumentException">
    ///     Thrown when <paramref name="prefix"/> is an empty string.
    /// </exception>
    public Demo(string prefix)
    {
        // Validate that the prefix is non-null and non-empty before storing it
        ArgumentException.ThrowIfNullOrEmpty(prefix);
        _prefix = prefix;
    }

    /// <summary>
    ///     Gets the greeting prefix used by this instance.
    /// </summary>
    public string Prefix => _prefix;

    /// <summary>
    ///     Returns a greeting message that combines the instance prefix with the given name.
    /// </summary>
    /// <param name="name">The name to include in the greeting.</param>
    /// <returns>
    ///     A greeting string in the format <c>{prefix}, {name}!</c>,
    ///     for example <c>Hello, World!</c>.
    /// </returns>
    /// <exception cref="ArgumentNullException">
    ///     Thrown when <paramref name="name"/> is <see langword="null"/>.
    /// </exception>
    /// <exception cref="ArgumentException">
    ///     Thrown when <paramref name="name"/> is an empty string.
    /// </exception>
    public string DemoMethod(string name)
    {
        // Validate that the name is non-null and non-empty before building the greeting
        ArgumentException.ThrowIfNullOrEmpty(name);

        // Combine the prefix and name into the standard greeting format
        return $"{_prefix}, {name}!";
    }
}
