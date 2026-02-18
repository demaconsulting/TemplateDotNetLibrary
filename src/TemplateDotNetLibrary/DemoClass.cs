namespace TemplateDotNetLibrary;

/// <summary>
/// Demonstration class for the template library.
/// </summary>
public class DemoClass
{
    /// <summary>
    /// Demo method that returns a greeting message.
    /// </summary>
    /// <param name="name">The name to greet.</param>
    /// <returns>A greeting message.</returns>
    public string DemoMethod(string name)
    {
        ArgumentNullException.ThrowIfNull(name);
        return $"Hello, {name}!";
    }
}
