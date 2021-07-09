using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Widgets
{
    public class Screen
    {
        private ScreenUnit[,] _scrBuffer;
        private ScreenUnit[,] _oldscrBuffer;
        private List<Widget> _widgetsList = new List<Widget>();
        public int Width;
        public int Height;

        public Screen(int width = 120, int height = 30)
        {
            _scrBuffer = new ScreenUnit[width, height];
            Width = width;
            Height = height;
        }

        private void Position(int x, int y, ScreenUnit value)
        {
            if( x <= Width && y <= Height)
            {
                _scrBuffer[x, y] = value;
            } 
        }

        public void DrawBox(int x, int y, int l, int h, ConsoleColor color, BorderType border, ConsoleColor backcolor)
        {

            for (int a = x; a < x + l; a++)
            {
                for (int b = y; b < y + h; b++)
                {
                    ScreenUnit tmp = new ScreenUnit('\0', ConsoleColor.Black);
                    switch (border)
                    {
                        case BorderType.None:
                            tmp.Text = ' ';
                            tmp.TextColor = color;
                            tmp.BackColor = backcolor;
                            Position(a, b, tmp);
                            break;
                        case BorderType.Single:
                            if ((a == x) && (b == y))
                            {

                                tmp.Text = '┌';
                                tmp.TextColor = color;
                                tmp.BackColor = backcolor;
                                Position(a, b, tmp);
                                break;
                            }
                            else if ((a == (x + l - 1)) && (b == y))
                            {
                                tmp.Text = '┐';
                                tmp.TextColor = color;
                                tmp.BackColor = backcolor;
                                Position(a, b, tmp);
                                break;

                            }
                            else if (a == x && b > y && b < y + h - 1)
                            {
                                tmp.Text = '│';
                                tmp.TextColor = color;
                                tmp.BackColor = backcolor;
                                Position(a, b, tmp);
                                break;
                            }
                            else if (a == (x + l - 1) && b > y && b < y + h - 1)
                            {
                                tmp.Text = '│';
                                tmp.TextColor = color;
                                tmp.BackColor = backcolor;
                                Position(a, b, tmp);
                                break;
                            }
                            else if ((a == x) && (b == y + h - 1))
                            {
                                tmp.Text = '└';
                                tmp.TextColor = color;
                                tmp.BackColor = backcolor;
                                Position(a, b, tmp);
                                break;
                            }
                            else if ((a == x + l - 1) && (b == y + h - 1))
                            {
                                tmp.Text = '┘';
                                tmp.TextColor = color;
                                tmp.BackColor = backcolor;
                                Position(a, b, tmp);
                                break;
                            }
                            else if ((a > x && a < x + l - 1) && (b == y || b == y + h - 1))
                            {
                                tmp.Text = '─';
                                tmp.TextColor = color;
                                tmp.BackColor = backcolor;
                                Position(a, b, tmp);
                                break;
                            }
                            else
                            {
                                break;
                            }
                        case BorderType.Double:
                            if ((a == x) && (b == y))
                            {

                                tmp.Text = '╔';
                                tmp.TextColor = color;
                                tmp.BackColor = backcolor;
                                Position(a, b, tmp);
                                break;
                            }
                            else if ((a == (x + l - 1)) && (b == y))
                            {
                                tmp.Text = '╗';
                                tmp.TextColor = color;
                                tmp.BackColor = backcolor;
                                Position(a, b, tmp);
                                break;

                            }
                            else if (a == x && b > y && b < y + h - 1)
                            {
                                tmp.Text = '║';
                                tmp.TextColor = color;
                                tmp.BackColor = backcolor;
                                Position(a, b, tmp);
                                break;
                            }
                            else if (a == (x + l - 1) && b > y && b < y + h - 1)
                            {
                                tmp.Text = '║';
                                tmp.TextColor = color;
                                tmp.BackColor = backcolor;
                                Position(a, b, tmp);
                                break;
                            }
                            else if ((a == x) && (b == y + h - 1))
                            {
                                tmp.Text = '╚';
                                tmp.TextColor = color;
                                tmp.BackColor = backcolor;
                                Position(a, b, tmp);
                                break;
                            }
                            else if ((a == x + l - 1) && (b == y + h - 1))
                            {
                                tmp.Text = '╝';
                                tmp.TextColor = color;
                                tmp.BackColor = backcolor;
                                Position(a, b, tmp);
                                break;
                            }
                            else if ((a > x && a < x + l - 1) && (b == y || b == y + h - 1))
                            {
                                tmp.Text = '═';
                                tmp.TextColor = color;
                                tmp.BackColor = backcolor;
                                Position(a, b, tmp);
                                break;
                            }
                            else
                            {
                                break;
                            }

                        default:
                            tmp.Text = '█';
                            break;
                    }
                }
            }
        }

        public void DrawBackground(int x, int y, int l, int h, ConsoleColor color, BackgroundType border)
        {
            ScreenUnit tmp = new ScreenUnit('\0', ConsoleColor.Black);

            for (int a = x; a < x + l; a++)
            {
                for (int b = y; b < y + h; b++)
                {
                    switch (border)
                    {
                        case BackgroundType.Solid:
                            tmp.Text = '█';
                            break;
                        case BackgroundType.Hard:
                            tmp.Text = '▓';
                            break;
                        case BackgroundType.Medium:
                            tmp.Text = '▒';
                            break;
                        case BackgroundType.Light:
                            tmp.Text = '░';
                            break;
                        case BackgroundType.Space:
                            tmp.Text = ' ';
                            tmp.BackColor = color;
                            break;
                        default:
                            tmp.Text = '█';
                            break;
                    }

                    tmp.TextColor = color;
                    Position(a, b, tmp);
                }
            }
        }

        public void DrawText(int x, int y, string text, ConsoleColor textColor, ConsoleColor backColor)
        {
            int pos = x;
            foreach (char letter in text)
            {
                ScreenUnit tmp = new ScreenUnit('\0', ConsoleColor.Black);
                tmp.Text = letter;
                tmp.BackColor = backColor;
                tmp.TextColor = textColor;

                Position(pos, y, tmp);
                pos++;
            }
        }

        public void DrawSepLine(int x, int y, int l, ConsoleColor color, BorderType border, ConsoleColor backcolor)
        {
            switch (border)
            {
                case BorderType.Single:
                    for(int a = x; a < x + l; a++)
                    {
                        ScreenUnit tmp = new ScreenUnit('\0', ConsoleColor.Black);
                        if (a == x)
                        {
                            tmp.Text = '├';
                            tmp.TextColor = color;
                            tmp.BackColor = backcolor;
                            Position(a, y, tmp);
                        } else if( a == x + l -1)
                        {
                            tmp.Text = '┤';
                            tmp.TextColor = color;
                            tmp.BackColor = backcolor;
                            Position(a, y, tmp);
                        } else
                        {
                            tmp.Text = '─';
                            tmp.TextColor = color;
                            tmp.BackColor = backcolor;
                            Position(a, y, tmp);
                        }
                    }
                    break;
                case BorderType.Double:
                    for (int a = x; a < x + l; a++)
                    {
                        ScreenUnit tmp = new ScreenUnit('\0', ConsoleColor.Black);
                        if (a == x)
                        {
                            tmp.Text = '╟';
                            tmp.TextColor = color;
                            tmp.BackColor = backcolor;
                            Position(a, y, tmp);
                        }
                        else if (a == x + l -1)
                        {
                            tmp.Text = '╢';
                            tmp.TextColor = color;
                            tmp.BackColor = backcolor;
                            Position(a, y, tmp);
                        }
                        else
                        {
                            tmp.Text = '─';
                            tmp.TextColor = color;
                            tmp.BackColor = backcolor;
                            Position(a, y, tmp);
                        }
                    }
                    break;
                default:
                    break;
            }
        }

        public void DrawVertSepLine(int x, int y, int h, ConsoleColor color, BorderType border, ConsoleColor backcolor)
        {
            switch (border)
            {
                case BorderType.Single:
                    for (int a = y; a < y + h; a++)
                    {
                        ScreenUnit tmp = new ScreenUnit('\0', ConsoleColor.Black);
                        if (a == y)
                        {
                            tmp.Text = '┬';
                            tmp.TextColor = color;
                            tmp.BackColor = backcolor;
                            Position(x, a, tmp);
                        }
                        else if (a == y + h - 1)
                        {
                            tmp.Text = '┴';
                            tmp.TextColor = color;
                            tmp.BackColor = backcolor;
                            Position(x, a, tmp);
                        }
                        else if ( a == y + 2)
                        {
                            tmp.Text = '┼';
                            tmp.TextColor = color;
                            tmp.BackColor = backcolor;
                            Position(x, a, tmp);
                        }
                        else
                        {
                            tmp.Text = '│';
                            tmp.TextColor = color;
                            tmp.BackColor = backcolor;
                            Position(x, a, tmp);
                        }
                    }
                    break;
                default:
                    break;
            }
        }

        public void Clear()
        {
            for (int x = 0; x < Width; x++)
            {
                for (int y = 0; y < Height; y++)
                {
                    _scrBuffer[x, y] = new ScreenUnit(' ', ConsoleColor.White, ConsoleColor.Black);
                }
            }
            Render();
        }

        public void Render()
        {
            Console.CursorVisible = false;
            // Desenhar os componentes no buffer
            foreach (Widget widget in _widgetsList)
            {
                widget.Draw(this);
            }

            // Escrever o buffer no ecra
            for (int x = 0; x < Width; x++)
            {
                for (int y = 0; y < Height; y++)
                {
                    if (_scrBuffer[x, y] != null)
                    {
                        Console.SetCursorPosition(x, y);
                        Console.ForegroundColor = _scrBuffer[x, y].TextColor;
                        Console.BackgroundColor = _scrBuffer[x, y].BackColor;
                        Console.Write(_scrBuffer[x, y].Text);
                    }
                }
            }
        }

        public void ReturnScreen()
        {
            ScreenUnit[,] tmpBuffer;
            tmpBuffer = _oldscrBuffer;
            _oldscrBuffer = _scrBuffer;
            _scrBuffer = tmpBuffer;
        }

        public void SaveScreen()
        {
            _oldscrBuffer = _scrBuffer;
        }

        public void Add(Widget widget)
        {
            _widgetsList.Add(widget);
        }

        public void Remove(Widget widget)
        {
            _widgetsList.Remove(widget);
        }
    }
}
