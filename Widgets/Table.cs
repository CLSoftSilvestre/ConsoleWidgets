using System;
using System.Collections.Generic;

namespace Widgets
{
    public class Table : Widget
    {
        public int NumColumns { get; set; }
        public int NumRows { get; set; }

        private readonly Screen _parentScreen = new Screen();

        private List<Row> TableRows { get; set; }
        public Header TableHeaders { get; set; } = new Header();

        public Table(int width, int height, Screen e)
        {
            //Por defeito fica no centro do ecra
            X = (e.Width / 2) - (width / 2);
            Y = (e.Height / 2) - (height / 2);

            Lenght = width;
            Height = height;
            _parentScreen = e;

        }

        public void AddColumn(int size, string text)
        {
            TableHeaders.AddColumn(size, text);
        }

        public override void Draw(Screen e)
        {
            //Desenhar os rebordos da tabela
            // Desenhar os contornos da form
            e.DrawBackground(X, Y, Lenght, Height, BackgroundColor, BackgroundType.Space);
            e.DrawBox(X, Y, Lenght, Height, FontColor, BorderType.Single, BackgroundColor);

            //Desenhar Linha
            e.DrawSepLine(X, Y+2, Lenght, FontColor, BorderType.Single, BackgroundColor);

            int posx = 1;

            foreach(var col in TableHeaders.Columns)
            {
                //Centrar o texto no centro da "celula"
                int tempx = ((X + posx) + (col.Size / 2)) - (col.Title.Length / 2);

                e.DrawText(X + posx, Y + 1, col.Title, FontColor, BackgroundColor);
                posx += col.Size;
            }


        }

    }

    public class Column
    {
        public int Size { get; set; }
        public string Title { get; set; }

        public Column()
        {

        }

        public Column(int size, string title)
        {
            Size = size;
            Title = title;
        }

    }

    public class Row
    {
        public List<Column> Columns { get; set; } = new List<Column>();

        public virtual void AddColumn(int size, string text)
        {
            Column col = new Column(size, text);
            Columns.Add(col);
        }
    }

    public class Header : Row
    {
        private int Size { get; set; }
        private string Title { get; set; }

        public Header()
        {

        }

        public Header(int size, string title)
        {
            Size = size;
            Title = title;
        }

        public override void AddColumn(int size, string text)
        {
            base.AddColumn(size, text);
        }



    }

}
