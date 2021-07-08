using System;

namespace Widgets
{
    public abstract class Widget
    {
        public int X { get; set; }
        public int Y { get; set; }
        public int Lenght { get; set; }
        public int Height { get; set; }
        public ConsoleColor BackgroundColor { get; set; }
        public ConsoleColor FontColor { get; set; }

        public virtual string Select()
        {
            // Mover o cursor para o local do widget
            return null;
        }

        public virtual void Draw(Screen e)
        {
            //desenhar o componente no ecrã
        }

        public virtual void Dispose(Screen e)
        {
            e.Remove(this);
        }

        public virtual void SetLocation(int x, int y)
        {
            X = x;
            Y = y;
        }

        public virtual void SetColors(ConsoleColor fgColor, ConsoleColor bgColor)
        {
            FontColor = fgColor;
            BackgroundColor = bgColor;
        }
    }

}
