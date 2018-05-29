using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace winlayout
{
    public class RestoreWindowProps : WindowProps
    {
        public class Range
        {
            public int from { get; set; }
            public int to { get; set; }

            public bool Matches(int value)
            {
                return (from <= value) && (value <= to);
            }
        }

        public Range Width { get; set; }
        public Range Height { get; set; }

        public int? ZOrder { get; set; }

        public bool Matches(WindowProps props)
        {
            if (Caption != null && !Regex.IsMatch(props.Caption, Caption)) return false;
            if (Class != null && !Regex.IsMatch(props.Class, Class)) return false;
            if (Exec != null && !Regex.IsMatch(props.Exec, Exec)) return false;
            if (Width != null && !Width.Matches(props.Rect.right - props.Rect.left)) return false;
            if (Height != null && !Height.Matches(props.Rect.bottom - props.Rect.top)) return false;
            return true;
        }

    }
}
