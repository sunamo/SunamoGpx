namespace SunamoGpx._sunamo;

internal class ThrowEx
{
    internal static void Custom(string message)
    {
        throw new Exception(message);
    }
}
