using System;
using System.Collections.Generic;
using System.Linq;
using Win32Interop.WinHandles;

namespace winlayout
{
    public static class Utils
    {
        public static List<WindowHandle> GetWindows()
        {
            WindowHandle current = TopLevelWindowUtils.GetForegroundWindow();
            return TopLevelWindowUtils.FindWindows(wh => wh.IsValid && wh.IsVisible() && wh.RawPtr != current.RawPtr).ToList();
        }
    }
}
