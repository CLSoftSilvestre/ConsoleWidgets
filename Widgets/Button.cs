using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Widgets
{
    public class Button : Widget
    {
        public string Text { get; set; }

        private bool _selected = false;

        private readonly Screen _parentScreen = new Screen();

        public Button(string text, Screen e)
        {
            Text = text;
            Lenght = 14;
            Height = 3;
            _parentScreen = e;
        }

        public override void Draw(Screen e)
        {
            // Desenhar contronos do Button
            e.DrawBackground(X, Y, Lenght, Height, BackgroundColor, BackgroundType.Space);
            if(_selected == true)
                e.DrawBox(X, Y, Lenght, Height, FontColor, BorderType.Double, BackgroundColor);
            else
                e.DrawBox(X, Y, Lenght, Height, FontColor, BorderType.Single, BackgroundColor);
            // Desenhar texto no centro do Button
            int tempx = (X + (Lenght / 2)) - (Text.Length / 2);
            e.DrawText(tempx, Y+1,Text.ToUpper(), FontColor, BackgroundColor);
        }

        public override string Select()
        {
            _selected = true;
            Draw(_parentScreen);
            _parentScreen.Render();
            while (true)
            {
                var key = Console.ReadKey(false).Key;
                switch (key)
                {
                    case ConsoleKey.Enter:
                        _selected = false;
                        Draw(_parentScreen);
                        _parentScreen.Render();
                        return Text;
                    default:
                        _selected = false;
                        Draw(_parentScreen);
                        _parentScreen.Render();
                        return null;
                }
            }
        }
    }
}
