using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Widgets
{
    public class Label : Widget
    {
        private string Text { get; set; }

        public Label(string text)
        {
            Text = text;
        }

        public Label(int x, int y, string text)
        {
            X = x;
            Y = y;
            Text = text;
        }

        public Label(int x, int y, string text, ConsoleColor font, ConsoleColor back)
        {
            X = x;
            Y = y;
            Text = text;
            FontColor = font;
            BackgroundColor = back;
        }

        public override void Draw(Screen e)
        {
            e.DrawText(X, Y, Text, FontColor, BackgroundColor);
        }
    }
}
