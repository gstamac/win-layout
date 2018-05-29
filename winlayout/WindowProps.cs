using System;
using System.Collections.Generic;
using System.Linq;
using Win32Interop.WinHandles;

namespace winlayout
{
    public class WindowProps
    {
        public string Caption { get; set; }
        public string Class { get; set; }
        public string Exec { get; set; }
        public WindowHandleExtensions.Rect Rect { get; set; }

        public static WindowProps CreateFromHandle(WindowHandle handle)
        {
            WindowProps props = new WindowProps();
            props.Caption = handle.GetWindowText();
            if (!string.IsNullOrEmpty(props.Caption))
            {
                props.Class = handle.GetClassName();
                props.Exec = handle.GetWindowExec();
                WindowHandleExtensions.Rect rect = new WindowHandleExtensions.Rect();
                if (handle.GetWindowRect(ref rect))
                {
                    props.Rect = rect;
                    return props;
                }
            }
            return null;
        }
    }
}
