using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Widgets
{
    public class MsgBox : Widget
    {
        public string Value { get; set; }
        private string Text { get; set; }
        private string Title { get; set; }

        public MsgBox(string title, string text)
        {
            X = 15;
            Y = 10;
            Lenght = 90;
            Height = 10;
            Text = text;
            Title = title;
        }

        public override void Draw(Screen e)
        {
            e.DrawBackground(X, Y, Lenght, Height, BackgroundColor, BackgroundType.Space);
            e.DrawBox(X, Y, Lenght, Height, FontColor, BorderType.Double, BackgroundColor);
            e.DrawText(X + 2, Y, " " + Title + " ", FontColor, BackgroundColor);
            //centrar o texto na MsgBox
            int tempx = (X + (Lenght / 2)) - (Text.Length / 2);
            int tempy = (Y + (Height / 2) - 1);
            e.DrawText(tempx, tempy, " " + Text + " ", FontColor, BackgroundColor);
        }

        public override string Select()
        {
            Console.ReadKey();
            return null;
        }

        public void Show(Screen e)
        {
            e.SaveScreen();
            e.Add(this);
            e.Render();
            Select();
            Dispose(e);
            e.ReturnScreen();
            e.Render();
        }
    }
}
