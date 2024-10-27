namespace SunamoGpx._sunamo;
internal class ThrowEx
{
    public static void Custom(string message)
    {
#if DEBUG
        Debugger.Break();
#endif
        throw new Exception(message);
    }
}