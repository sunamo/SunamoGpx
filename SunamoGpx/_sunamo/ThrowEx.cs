namespace SunamoGpx._sunamo;

// EN: Variable names have been checked and replaced with self-descriptive names
// CZ: Názvy proměnných byly zkontrolovány a nahrazeny samopopisnými názvy
internal class ThrowEx
{
    internal static void Custom(string message)
    {
#if DEBUG
        Debugger.Break();
#endif
        throw new Exception(message);
    }
}