using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Widgets
{
    public class Form : Widget
    {
        private readonly Screen _parentScreen = new Screen();

        private List<Widget> _widgetsList = new List<Widget>();
        public string Title { get; set; }

        public Form(int width, int height, string title, Screen e)
        {
            //A form será colocada centrada no ecra
            _parentScreen = e;
            X = (e.Width / 2) - (width / 2);
            Y = (e.Height / 2) - (height / 2);
            Lenght = width;
            Height = height;
            Title = title;
        }

        public void Add(Widget widget)
        {
            _widgetsList.Add(widget);
        }

        public override void Draw(Screen e)
        {
            // Desenhar os contornos da form
            e.DrawBackground(X, Y, Lenght, Height, BackgroundColor, BackgroundType.Space);
            e.DrawBox(X, Y, Lenght, Height, FontColor, BorderType.Double, BackgroundColor);

            //Desenhar o titulo da form do centro da mesma
            int tempx = (X + (Lenght / 2 ))- ((Title.Length + 4) / 2);
            e.DrawText(tempx, Y,  " [" + Title.ToUpper() + "] ", FontColor, BackgroundColor);

            // Desenhar os componentes no buffer
            foreach (Widget widget in _widgetsList)
            {
                widget.Draw(e);
            }
        }

    }
}
