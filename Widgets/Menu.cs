using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Widgets
{
    public class Menu : Widget
    {
        public string Title { get; set; }
        //public List<string> Items { get; set; }
        public List<MenuItem> Itens { get; set; } 

        private int _selPos = 1;

        private Screen parentScreen = new Screen();

        public Menu(string title, List<MenuItem> itens)
        {
            Title = title;
            Itens = itens;

            //Hard Coded position
            X = 35;
            Y = 10;
            Lenght = 50;
            Height = 10;
        }

        public override void Draw(Screen e)
        {
            parentScreen = e;
            e.DrawBackground(X, Y, Lenght, Height, BackgroundColor, BackgroundType.Space);
            e.DrawBox(X, Y, Lenght, Height, FontColor, BorderType.Double, BackgroundColor);
            //Desenhar barra de item selecionado
            e.DrawBackground(X+5, Y + 2 + _selPos, Lenght - 10, 1, FontColor, BackgroundType.Space);
            e.DrawSepLine(X, Y+2, Lenght, FontColor, BorderType.Double, BackgroundColor);
            //Desenhar titulo do menu (Vai ser alterado para componente Widget)
            int tempx = (X + (Lenght / 2)) - ((Title.Length) / 2);
            e.DrawText(tempx, Y+1, Title.ToUpper(), FontColor, BackgroundColor);

            //Desenhar opções do menu (Vai ser alterado para componente Widget)
            int pos = 12;
            foreach (var item in Itens)
            {
                pos += 1;
                if (pos-12 == _selPos)
                    e.DrawText(45, pos, item.Text, BackgroundColor, FontColor);
                else
                    e.DrawText(45, pos, item.Text, FontColor, BackgroundColor);
            }

            e.DrawText(38, 18, "Utilize as setas ↑↓ e selecione com <Enter>", FontColor, BackgroundColor);
        }

        public override string Select()
        {
            while(true)
            {
                var key = Console.ReadKey(false).Key;
                switch (key)
                {
                    case ConsoleKey.DownArrow:
                        if (_selPos < Itens.Count)
                            _selPos += 1;
                        break;
                    case ConsoleKey.UpArrow:
                        if (_selPos > 1)
                            _selPos -= 1;
                        break;
                    case ConsoleKey.Enter:
                        //Retorna o valor selecionado
                        Itens[_selPos - 1].Select();
                        break;
                        //return Itens[_selPos - 1].Text;
                }

                Draw(parentScreen);
                parentScreen.Render();
                
            }
        }
    }

    public class MenuItem
    {
        public string Text { get; set; }

        public event EventHandler Selected;

        public MenuItem(string text)
        {
            Text = text;
        }

        public void Select()
        {
            OnSelectedItem(EventArgs.Empty);
        }

        protected virtual void OnSelectedItem(EventArgs e)
        {
            Selected?.Invoke(this, e);
        }

    }
}
