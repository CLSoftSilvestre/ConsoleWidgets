using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Widgets
{
    public class TextBox:Widget
    {
        public string Value { get; set; } = "";
        private int PosX { get; set; }
        private int PosY { get; set; }
        private string Text { get; set; }

        public TextBox(int x, int y, int lenght, string text)
        {
            X = x;
            Y = y;
            Lenght = lenght;
            Height = 3;
            Text = text;
            PosX = X + 1;
            PosY = Y + 1;
        }
  
        public override void Draw(Screen e)
        {
            e.DrawBackground(X, Y, Lenght, Height, BackgroundColor, BackgroundType.Space);
            e.DrawBox(X, Y, Lenght, Height, FontColor, BorderType.Single, BackgroundColor);
            e.DrawText(X + 1, Y, " " + Text + " ", FontColor, BackgroundColor);
            //Escrever o conteudo do TextBox (necessário quando redesenha o ecra)
            e.DrawText(X + 1, Y + 1 , Value, FontColor, BackgroundColor);
        }

        public override string Select()
        {
            Console.SetCursorPosition(PosX, PosY);
            Console.BackgroundColor = BackgroundColor;
            Console.ForegroundColor = FontColor;
            Console.CursorVisible = true;
            Value = Console.ReadLine();
            Console.CursorVisible = false;
            return Value;
        }
 
    }
}
