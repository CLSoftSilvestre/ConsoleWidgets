using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Widgets
{
    public class Background : Widget
    {
        public BackgroundType Border { get; set; }
        public Background(int x, int y, int l, int h, ConsoleColor color, BackgroundType border)
        {
            X = x;
            Y = y;
            Lenght = l;
            Height = h;
            BackgroundColor = color;
            Border = border;
        }
        public override void Draw(Screen e)
        {
            e.DrawBackground(X, Y, Lenght, Height, BackgroundColor, Border);
        }
    }
}
