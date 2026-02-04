namespace SunamoGpx._sunamo;

/// <summary>
/// Provides exception throwing utilities with optional debugger break in debug mode.
/// </summary>
internal class ThrowEx
{
    /// <summary>
    /// Throws a custom exception with the specified message. In debug mode, triggers a debugger break before throwing.
    /// </summary>
    /// <param name="message">The exception message to throw.</param>
    internal static void Custom(string message)
    {
#if DEBUG
        Debugger.Break();
#endif
        throw new Exception(message);
    }
}