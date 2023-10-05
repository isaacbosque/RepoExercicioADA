static void ImprimirMenu()
{
    Dictionary<int, string> opcoes = new Dictionary<int, string>();
    int posicaoYMenu = Console.BufferHeight / 2;
    int posicaoXMenu = Console.BufferWidth / 2;
    int itemSelecionado = 0;

    opcoes.Add(0, "Iniciar Jogo");
    opcoes.Add(1, "Como jogar?");
    opcoes.Add(2, "Sair");

    Console.OutputEncoding = System.Text.Encoding.UTF8;
    Console.CursorVisible = false;

    while (true)
    {
        Console.Clear();
        int posicao = CentralizarTexto("     __                    __       ____                 ");

        EscreverNaPosicao(@"    ___   __                       __          
   /   | / /_____ __________ _____/ /___ _____ 
  / /| |/ __/ __ `/ ___/ __ `/ __  / __ `/ __ \
 / ___ / /_/ /_/ / /__/ /_/ / /_/ / /_/ / /_/ /
/_/  |_\__/\__,_/\___/\__,_/\__,_/\__,_/\____/ 
                                               ",
         posicao,
         5);

        ImprimirControlesMenu();

        Console.SetCursorPosition(Console.BufferWidth / 2, Console.BufferHeight / 2);
        for (int i = 0; i < opcoes.Count; i++)
        {
            Console.SetCursorPosition(CentralizarTexto(opcoes[i]), (Console.BufferHeight / 2 - opcoes.Count + i));
            if (itemSelecionado == i)
            {
                Console.BackgroundColor = ConsoleColor.White;
                Console.ForegroundColor = ConsoleColor.Black;

                Console.WriteLine(opcoes[i]);

                Console.ForegroundColor = ConsoleColor.White;
                Console.BackgroundColor = ConsoleColor.Black;

            }
            else
            {
                Console.WriteLine(opcoes[i]);
            }
        }


        switch (Console.ReadKey(true).Key)
        {
            case ConsoleKey.UpArrow:
                itemSelecionado--;

                if (itemSelecionado < 0)
                    itemSelecionado = opcoes.Count - 1;

                break;
            case ConsoleKey.DownArrow:
                itemSelecionado++;
                if (itemSelecionado == opcoes.Count)
                    itemSelecionado = 0;
                break;
            case ConsoleKey.Enter:
                if (itemSelecionado == 0)
                    return;

                if (itemSelecionado == 1)
                    ImprimirComoJogar();

                if (itemSelecionado == 2)
                    System.Environment.Exit(1);
                break;
            default:
                break;
        }
    }
}





static void EscreverNaPosicao(string texto, int left, int top)
{
    Console.SetCursorPosition(left, top);
    Console.WriteLine(texto);
}


static int CentralizarTexto(string labelOpcao)
{
    int posicao = (Console.BufferWidth / 2) - labelOpcao.Length / 2;

    return posicao;
}


static void ImprimirControlesMenu()
{
    Console.SetCursorPosition(3, Console.BufferHeight - 1);
    Console.WriteLine("< \u2191 / \u2193 > Selecionar opção         <ENTER> Confirmar");
}

