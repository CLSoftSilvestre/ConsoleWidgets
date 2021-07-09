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
        public List<string> Items { get; set; }

        private int _selPos = 1;

        private Screen parentScreen = new Screen();

        public Menu(string title, List<string> items)
        {
            Title = title;
            Items = items;
        }

        public override void Draw(Screen e)
        {
            parentScreen = e;
            e.DrawBackground(35, 10, 50, 10, BackgroundColor, BackgroundType.Space);
            e.DrawBox(35, 10, 50, 10, FontColor, BorderType.Double, BackgroundColor);
            //Desenhar barra de item selecionado
            e.DrawBackground(40, 12 + _selPos, 40, 1, FontColor, BackgroundType.Space);
            e.DrawSepLine(35, 12, 50, FontColor, BorderType.Double, BackgroundColor);
            //Desenhar titulo do menu (Vai ser alterado para componente Widget)
            e.DrawText(55, 11, Title.ToUpper(), FontColor, BackgroundColor);
            //Desenhar opções do menu (Vai ser alterado para componente Widget)
            int pos = 12;
            foreach (var item in Items)
            {
                pos += 1;
                if (pos-12 == _selPos)
                    e.DrawText(45, pos, item, BackgroundColor, FontColor);
                else
                    e.DrawText(45, pos, item, FontColor, BackgroundColor);
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
                        if (_selPos < Items.Count)
                            _selPos += 1;
                        break;
                    case ConsoleKey.UpArrow:
                        if (_selPos > 1)
                            _selPos -= 1;
                        break;
                    case ConsoleKey.Enter:
                        //Retorna o valor selecionado
                        return Items[_selPos - 1];
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
