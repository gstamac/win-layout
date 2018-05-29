using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Win32Interop.WinHandles;

namespace winlayout
{
    public static class StorePositions
    {
        public static void Run(string filepath)
        {
            List<WindowProps> windows = Utils.GetWindows().Select(wh => WindowProps.CreateFromHandle(wh)).Where(p => p != null).ToList();

            File.WriteAllText(filepath, JsonConvert.SerializeObject(windows, Formatting.Indented));
        }
    }
}
