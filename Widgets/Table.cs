using System;
using System.Collections.Generic;

namespace Widgets
{
    public class Table : Widget
    {
        public int NumColumns { get; set; }
        public int NumRows { get; set; }

        private readonly Screen _parentScreen = new Screen();

        private int _selPos = 1;
        private int _maxItems = 1;
        private int _actualPag = 1;
        private int _totalPag = 1;

        public List<Row> TableRows { get; set; } = new List<Row>();
        public Header TableHeaders { get; set; } = new Header();

        public Table(int width, int height, Screen e)
        {
            //Por defeito fica no centro do ecra
            X = (e.Width / 2) - (width / 2);
            Y = (e.Height / 2) - (height / 2);

            Lenght = width;
            Height = height;
            _parentScreen = e;

            //Definir o maximo de item em simultaneo na tabela (sem contar com paginação)
            _maxItems = Height - 4;

        }

        public void AddColumn(int size, string text)
        {
            TableHeaders.AddColumn(size, text);
        }

        public void AddRow(Row data)
        {
            TableRows.Add(data);
            _totalPag = (TableRows.Count / _maxItems) + 1;
        }

        public override void Draw(Screen e)
        {
            //Desenhar os rebordos da tabela
            // Desenhar os contornos da form
            e.DrawBackground(X, Y, Lenght, Height, BackgroundColor, BackgroundType.Space);
            e.DrawBox(X, Y, Lenght, Height, FontColor, BorderType.Single, BackgroundColor);

            //Desenhar Linha
            e.DrawSepLine(X, Y+2, Lenght, FontColor, BorderType.Single, BackgroundColor);

            //Desenhar dados pa paginação
            e.DrawText(X + Lenght - 20, Y + Height - 1, $"[ Pagina {_actualPag} de {_totalPag}. ]", ConsoleColor.White, ConsoleColor.DarkBlue);

            int posx = 0;
            int count = 1;
            int linhaTab = 1;

            foreach(var col in TableHeaders.Columns)
            {
                //Centrar o texto no centro da "celula"
                int tempx = ((X + posx) + (col.Size / 2)) - (col.Title.Length / 2);
                e.DrawText(tempx, Y + 1, col.Title, FontColor, BackgroundColor);
                //Desenhar as linhas verticais de separação das colunas, contudo não pode desenhar a última linha porque é o rebordo da tabela
                if (count < TableHeaders.Columns.Count)
                {
                    e.DrawVertSepLine(X + posx + col.Size, Y, Height, FontColor, BorderType.Single, BackgroundColor);
                }  
                posx += col.Size;
                count += 1;
            }

            posx = 0;

            //Desenhar as linhas de dados da tabela (Mas apenas as linhas que cabem na tabela)
            for (int linha = 0; linha < TableRows.Count; linha++)
            {
                if(linha < Height - 4)
                {
                    //Desenhar linha de selecao de item
                    if(linhaTab == _selPos)
                    {
                        e.DrawBackground(X+1, Y+2 + _selPos, Lenght -2 , 1, FontColor, BackgroundType.Space);
                    }

                    for (int coluna = 0; coluna < TableRows[linha].Columns.Count; coluna++)
                    {
                        if (linhaTab == _selPos)
                        {
                            //Escrever cada campo de texto (Célula) na cor invertida
                            if (((_actualPag - 1) * _maxItems) + linha < TableRows.Count)
                            {
                                e.DrawText(X + 2 + posx, Y + 3 + linha, TableRows[((_actualPag - 1) * _maxItems) + linha].Columns[coluna].Title, BackgroundColor, FontColor);

                            }
                        }
                        else
                        {
                            //Escrever cada campo de texto (Célula) na cor normal
                            if (((_actualPag - 1) * _maxItems) + linha < TableRows.Count)
                            {
                                e.DrawText(X + 2 + posx, Y + 3 + linha, TableRows[((_actualPag - 1) * _maxItems) + linha].Columns[coluna].Title, FontColor, BackgroundColor);
                            }
                        }
                            
                        posx += TableRows[linha].Columns[coluna].Size;
                    }
                    posx = 0;
                    linhaTab += 1;
                }
                
            }
        }

        public override string Select()
        {
            while (true)
            {
                var key = Console.ReadKey(false).Key;
                switch (key)
                {
                    case ConsoleKey.DownArrow:
                        if (_selPos < _maxItems)
                            _selPos += 1;
                        break;
                    case ConsoleKey.UpArrow:
                        if (_selPos > 1)
                            _selPos -= 1;
                        break;
                    case ConsoleKey.PageDown:
                        //Next page of pagination
                        if(_actualPag < _totalPag)
                        {
                            _actualPag += 1;
                        }
                        break;
                    case ConsoleKey.PageUp:
                        // Previous page of pagination
                        if (_actualPag > 1)
                        {
                            _actualPag -= 1;
                        }
                        break;
                    case ConsoleKey.Enter:
                        //Retorna o valor da primeira coluna do objecto selecionado.
                        return TableRows[((_actualPag - 1) * _maxItems) + _selPos - 1].Columns[0].Title;
                    case ConsoleKey.Tab:
                        //Sai e avança para proximo controlo
                        return null;
                    case ConsoleKey.Escape:
                        //Sai e avança para proximo controlo
                        return null;
                }

                Draw(_parentScreen);
                _parentScreen.Render();

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
