using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using Win32Interop.WinHandles;

namespace winlayout
{
    public static class RestorePositions
    {
        public static void Run(string filepath)
        {
            List<RestoreWindowProps> windows = JsonConvert.DeserializeObject<List<RestoreWindowProps>>(File.ReadAllText(filepath));

            Utils.GetWindows()
                .ForEach(wh =>
                {
                    WindowProps props = WindowProps.CreateFromHandle(wh);
                    if (props == null) return;

                    RestoreWindowProps storedProps = windows.FirstOrDefault(p => p.Matches(props));
                    if (storedProps != null)
                    {
                        Console.WriteLine($"Restoring {props.Caption} to");
                        Console.WriteLine(JsonConvert.SerializeObject(storedProps.Rect, Formatting.Indented));
                        wh.SetWindowRect(storedProps.Rect);
                        if (storedProps.ZOrder != null)
                        {
                            wh.SetZPosition(storedProps.ZOrder.Value);
                        }
                    }
                });
        }
    }
}
