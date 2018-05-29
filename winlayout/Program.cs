using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Win32Interop.WinHandles;

namespace winlayout
{
    class Program
    {
        static void Main(string[] args)
        {
            //TopLevelWindowUtils.FindWindows(wh => wh.IsValid && wh.IsVisible())
            //    //.Where(wh => wh.GetClassName().Contains("ConsoleWindowClass"))
            //    .Where(wh => wh.GetWindowText().Contains("Command"))
            //    .ToList().ForEach(wh =>
            //{
            //    Console.WriteLine(wh.GetWindowText());
            //    Console.WriteLine($"\tClass name: {wh.GetClassName()}");
            //    Console.WriteLine($"\tHash code: {wh.GetHashCode()}");
            //    Console.WriteLine($"\tExec: {wh.GetWindowExec()}");
            //    WindowHandleExtensions.WINDOWPLACEMENT placement = new WindowHandleExtensions.WINDOWPLACEMENT();
            //    if (wh.GetWindowPlacement(ref placement))
            //    {
            //        Console.WriteLine($"\tPlacement:");
            //        Console.WriteLine($"\t\tPlacement ptMinPosition: {placement.ptMinPosition.x} {placement.ptMinPosition.y}");
            //        Console.WriteLine($"\t\tPlacement ptMaxPosition: {placement.ptMaxPosition.x} {placement.ptMaxPosition.y}");
            //        Console.WriteLine($"\t\tPlacement rcNormalPosition: {placement.rcNormalPosition.left} {placement.rcNormalPosition.top} {placement.rcNormalPosition.right} {placement.rcNormalPosition.bottom}");
            //        Console.WriteLine($"\t\tPlacement flags: {placement.flags}");
            //        Console.WriteLine($"\t\tPlacement length: {placement.length}");
            //        Console.WriteLine($"\t\tPlacement showCmd: {placement.showCmd}");
            //    }
            //    WindowHandleExtensions.Rect rect = new WindowHandleExtensions.Rect();
            //    if (wh.GetWindowRect(ref rect))
            //    {
            //        Console.WriteLine($"\tRECT: {rect.left} {rect.top} {rect.right} {rect.bottom}");
            //    }

            //});
            if (args.Length == 2 && args[0] == "/s")
            {
                Console.WriteLine($"Storing to {args[1]}");
                StorePositions.Run(args[1]);
                Console.WriteLine("Done.");
            }
            else if (args.Length == 2 && args[0] == "/r")
            {
                Console.WriteLine($"Restoring from {args[1]}");
                RestorePositions.Run(args[1]);
                Console.WriteLine("Done.");
            }
            else
            {
                Console.WriteLine("Usage: winlayout [switch]");
                Console.WriteLine("/s filepath     Store current window position to file");
                Console.WriteLine("/r filepath     Restore window positions from file");
            }
            //Console.ReadKey();
        }
    }
}
