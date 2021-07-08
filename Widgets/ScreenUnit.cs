using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Widgets
{
    public class ScreenUnit
    {
        public char Text { get; set; }
        public ConsoleColor TextColor { get; set; }
        public ConsoleColor BackColor { get; set; }
        public ScreenUnit(char Text = '\0', ConsoleColor textcolor = ConsoleColor.White, ConsoleColor backcolor = ConsoleColor.Black)
        {
        }
    }
}
