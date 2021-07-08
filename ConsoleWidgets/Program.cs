using System;
using System.Collections.Generic;
using Widgets;

namespace ConsoleWidgets
{
    class Program
    {

        static void Main(string[] args)
        {
            Screen e = new Screen(120, 30);

            e.Clear();

            //Desenhar o background geral no ecra todo
            Background bg1 = new Background(0, 0, 120, 30, ConsoleColor.DarkBlue, BackgroundType.Light);
            e.Add(bg1);

            //Lista de items do menu (neste momento limitado a um máximo 4 opcoes)
            List<string> menuItems = new List<string>();
            menuItems.Add("Novo cliente");
            menuItems.Add("Visualizar clientes");
            menuItems.Add("Opção 3");
            menuItems.Add("Sair da aplicação");

            //Criar um menu e adicionar ao ecra
            Menu mnu = new Menu("Menu de teste", menuItems);
            mnu.SetColors(ConsoleColor.White, ConsoleColor.DarkBlue);
            e.Add(mnu);

            e.Render();

            //Efetuar a derivação para os metodos correspondentes de acordo com a escolha do menu
            string selecionado = new string("");
            while (selecionado != null)
            {
                selecionado = mnu.Select();

                switch (selecionado)
                {
                    case "Novo cliente":
                        NovoUtilizador(e);
                        break;
                    case "Visualizar clientes":
                        VerUtilizadores(e);
                        break;
                    case "Opção 3":
                        VerOpcao3(e);
                        break;
                    case "Sair da aplicação":
                        return;
                    default:
                        break;
                }

            }

            //Fim da aplicação
        }

        static void NovoUtilizador(Screen e)
        {
            //Criar uma Form e adicionar controlos a esta Form
            Form frm1 = new Form(100, 20, "Novo cliente", e);
            frm1.SetColors(ConsoleColor.White, ConsoleColor.DarkBlue);

            //Adicionar TextBox 1 ao Form
            TextBox tb1 = new TextBox(12, 7, 50, "Insira o seu nome:");
            tb1.SetColors(ConsoleColor.White, ConsoleColor.DarkBlue);
            frm1.Add(tb1);

            //Adicionar TextBox 2 ao Form
            TextBox tb2 = new TextBox(12, 12, 95, "Insira o sua morada:");
            tb2.SetColors(ConsoleColor.White, ConsoleColor.DarkBlue);
            frm1.Add(tb2);

            //Adicionar TextBox 3 ao Form
            TextBox tb3 = new TextBox(12, 17, 95, "Insira o seu numero de telefone:");
            tb3.SetColors(ConsoleColor.White, ConsoleColor.DarkBlue);
            frm1.Add(tb3);

            //Adicionar o Botao Guardar
            Button btn1 = new Button("Guardar", e);
            btn1.SetColors(ConsoleColor.White, ConsoleColor.DarkBlue);
            btn1.SetLocation(35, 21);
            frm1.Add(btn1);

            //Adicionar o Botao Cancelar
            Button btn2 = new Button("Cancelar", e);
            btn2.SetColors(ConsoleColor.White, ConsoleColor.DarkBlue);
            btn2.SetLocation(65, 21);
            frm1.Add(btn2);

            e.Add(frm1);
            e.Render();

            //Mover cursor para o input dos componentes e retorna o Valor do componente
            string Nome = tb1.Select();
            string Morada = tb2.Select();
            string Telefone = tb3.Select();

            //Mover cursor entre botoes e devolve o valor do botao selecionado
            string resp = new string("");
            while (resp != "Guardar" && resp != "Cancelar")
            {
                resp = btn1.Select();
                if (resp != "Guardar")
                    resp = btn2.Select();
            }

            if (resp == "Guardar")
            {
                //Apresentar uma MsgBox (No caso das MsgBox não necessita de adicionar ao Screen. O processo é feito automaticamente pelo metodo Show)
                MsgBox mb2 = new MsgBox("Foi registado um novo utilizador!", $"O utilizador {Nome} mora em {Morada} e tem o numero {Telefone}.");
                mb2.SetColors(ConsoleColor.White, ConsoleColor.DarkBlue);
                mb2.Show(e);
            }

            frm1.Dispose(e);
            e.Render();
        }

        static void VerUtilizadores(Screen e)
        {
            //Criar uma Form e adicionar controlos a esta Form
            Form frm1 = new Form(110, 25, "Visualizar clientes", e);
            frm1.BackgroundColor = ConsoleColor.DarkBlue;
            frm1.FontColor = ConsoleColor.White;

            Button btn1 = new Button("OK", e);
            btn1.SetColors(ConsoleColor.White, ConsoleColor.DarkBlue);
            btn1.SetLocation(30, 20);
            frm1.Add(btn1);

            Button btn2 = new Button("Cancelar", e);
            btn2.SetColors(ConsoleColor.White, ConsoleColor.DarkBlue);
            btn2.SetLocation(60, 20);
            frm1.Add(btn2);

            e.Add(frm1);
            e.Render();

            string resp = new string("");
            while(resp != "OK" && resp != "Cancelar")
            {
                resp = btn1.Select();
                if(resp != "OK")
                    resp = btn2.Select();
            }


            //Console.ReadKey();

            frm1.Dispose(e);
            e.Render();
        }

        static void VerOpcao3(Screen e)
        {
            //Apresentar uma MsgBox (No caso das MsgBox não necessita de adicionar ao Screen. O processo é feito automaticamente pelo metodo Show)
            //MsgBox mb1 = new MsgBox("Atenção!", "A opção 3 ainda não está definida!");
            //mb1.SetColors(ConsoleColor.White, ConsoleColor.DarkBlue);
            //mb1.Show(e);

            Table tbl1 = new Table(80, 20, e);
            tbl1.SetColors(ConsoleColor.White, ConsoleColor.DarkBlue);
            tbl1.AddColumn(20, "Nome");
            tbl1.AddColumn(40, "Morada");
            tbl1.AddColumn(20, "Telefone");

            e.Add(tbl1);
            e.Render();

            Console.ReadKey();

            tbl1.Dispose(e);
            e.Render();

        }
    }
}
