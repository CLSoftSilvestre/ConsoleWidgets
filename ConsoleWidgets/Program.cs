using System;
using System.Collections.Generic;
using Widgets;

namespace ConsoleWidgets
{
    class Program
    {
        static Screen e;

        static void Main(string[] args)
        {
            // Cria um novo ecra de dimensoes 120 colunas x 30 linhas (Tamanho standard e limpa o mesmo)
            // Isto faz com que a escrita no ecra seja controlada por uma classe que contem um duplo buffer para
            // permitir voltar atraz no desenho (por exemplo quando aparece e depois desaparece uma MsgBox.
            e = new Screen(120, 30);
            e.Clear();

            // Desenhar o background geral no ecra todo
            // Pode ser selecionado vários tipos de fundo do tipo BackgroundType: Hard, Medium, Light, Solid, Space
            Background bg1 = new Background(0, 0, 120, 30, ConsoleColor.DarkBlue, BackgroundType.Light);
            e.Add(bg1);

            // Lista de items do menu (TODO: neste momento limitado a um máximo 4 opcoes)
            List<MenuItem> menuItens = new List<MenuItem>();

            // Cria um novo MenuItem
            MenuItem NovoCliente = new MenuItem("Novo cliente");
            // Adiciona o método correspondente ao Evento Selected
            NovoCliente.Selected += NovoCliente_OnSelectedItem;
            // Adiciona o MenuItem à lista de Itens que irá ser adicionada ao Menu
            menuItens.Add(NovoCliente);

            // Criar item de menu e adicionar à lista e atribuir evento
            MenuItem VisualizarCliente = new MenuItem("Visualizar clientes");
            VisualizarCliente.Selected += VisualizarCliente_OnSelectedItem;
            menuItens.Add(VisualizarCliente);

            // Criar item de menu e adicionar à lista e atribuir evento
            MenuItem Opcao3 = new MenuItem("Opção 3");
            Opcao3.Selected += Opcao3_OnSelectedItem;
            menuItens.Add(Opcao3);

            // Criar item de menu e adicionar à lista e atribuir evento
            MenuItem Sair = new MenuItem("Sair da aplicação");
            Sair.Selected += Sair_OnSelectedItem;
            menuItens.Add(Sair);

            // Criar um menu adicionar a lista de items.
            Menu mnu = new Menu("Menu de teste da aplicação", menuItens);
            // Define as cores a utilizar pelo Menu
            mnu.SetColors(ConsoleColor.White, ConsoleColor.DarkBlue);
            // Adiciona o Menu criado ao objecto Screen geral
            e.Add(mnu);

            // Efectua o desenho do conteudo do buffer do Screen no ecrã.
            // Terá de ser chamado sempre que haja necessidade de atualizar as imagens no ecra
            // Excepto em situações em que o proprio componente (Widget) o faz (por exemplo os métodos Select ou MsgBox.Show())
            e.Render();

            // Ativa o menu para podermos selecionar o item.
            // A partir daqui será chamado o evento do MenuItem chamará o método correspondente
            mnu.Select();
        }

        //Event Handlers
        public static void NovoCliente_OnSelectedItem(object sender, EventArgs ev)
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

        public static void VisualizarCliente_OnSelectedItem(object sender, EventArgs ev)
        {
            //Criar uma Form e adicionar controlos a esta Form
            Form frm1 = new Form(110, 25, "Visualizar clientes", e);
            frm1.BackgroundColor = ConsoleColor.DarkBlue;
            frm1.FontColor = ConsoleColor.White;

            //Criar uma nova tabela
            Table tbl1 = new Table(90, 19, e);
            tbl1.SetColors(ConsoleColor.White, ConsoleColor.DarkBlue);

            //Posicionar a tabela ligeiramente mais acima (por defeito aparece no centro do ecra)
            tbl1.Y -= 1;

            //Adicionar as colunas à tabela (Headers)
            tbl1.AddColumn(30, "Nome");
            tbl1.AddColumn(38, "Morada");
            tbl1.AddColumn(20, "Telefone");

            //Adicionar as linhas à tabela
            for (int x = 0; x < 20; x++)
            {
                Row linha = new Row();
                linha.AddColumn(30, "Celso " + x);
                linha.AddColumn(38, "Alameda de Belém " + x);
                linha.AddColumn(20, "91215232" + x);
                tbl1.AddRow(linha);
            }

            //Adicionar a tabela ao Form
            frm1.Add(tbl1);

            //Criar o botao OK
            Button btn1 = new Button("OK", e);
            btn1.SetColors(ConsoleColor.White, ConsoleColor.DarkBlue);
            btn1.SetLocation(35, 24);
            frm1.Add(btn1);

            //Criar o botao Cancelar
            Button btn2 = new Button("Cancelar", e);
            btn2.SetColors(ConsoleColor.White, ConsoleColor.DarkBlue);
            btn2.SetLocation(65, 24);
            frm1.Add(btn2);

            e.Add(frm1);
            e.Render();

            tbl1.Select();

            // Gestão da alternação entre botoes e resposta
            string resp = new string("");
            while (resp != "OK" && resp != "Cancelar")
            {
                resp = btn1.Select();
                if (resp != "OK")
                    resp = btn2.Select();
            }

            frm1.Dispose(e);
            e.Render();
        }

        public static void Opcao3_OnSelectedItem(object sender, EventArgs ev)
        {
            //Apresentar uma MsgBox (No caso das MsgBox não necessita de adicionar ao Screen. O processo é feito automaticamente pelo metodo Show)
            MsgBox mb1 = new MsgBox("Atenção!", "A opção 3 ainda não está definida!");
            mb1.SetColors(ConsoleColor.White, ConsoleColor.DarkBlue);
            mb1.Show(e);
        }

        public static void Sair_OnSelectedItem(object sender, EventArgs ev)
        {
            //Termina a aplicação
            Environment.Exit(0); 
        }
    }
}
