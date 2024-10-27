namespace SunamoGpx._sunamo;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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