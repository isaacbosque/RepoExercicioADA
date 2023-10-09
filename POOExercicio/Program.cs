using POOExercicio;

internal class Program
{
    private static void Main(string[] args)
    {
        Empresa empresa = new Empresa("Ataccadão", "Grande", "Atacado / Varejo");
        Console.SetWindowPosition(0, 0);
        Console.CursorVisible = false;
        Console.SetWindowSize(120, 30);
        ImprimirMenu(empresa);
        
    }

    // Imprime um menu interativo
    static void ImprimirMenu( Empresa empresa)
    {
        Dictionary<int, string> opcoes = new Dictionary<int, string>();
        int posicaoYMenu = Console.BufferHeight / 2;
        int posicaoXMenu = Console.BufferWidth / 2;
        int itemSelecionado = 0;

        opcoes.Add(0, "Cadastrar empregado");
        opcoes.Add(1, "Listar todos os empregados cadastrados");
        opcoes.Add(2, "Promover um empregado");
        opcoes.Add(3, "Demitir um empregado");
        opcoes.Add(4, "Listar o salário anual de um empregado");
        opcoes.Add(5, "Fechar programa");

        Console.OutputEncoding = System.Text.Encoding.UTF8;
        Console.CursorVisible = false;

        while (true)
        {
            
            Console.Clear();
            int posicao = CentralizarTexto("    ___   __                       __          ");
            // Imprime uma imagem em ASCII - porém não está operando corretamente em resoluções diferentes de 1920x1080.
            EscreverNaPosicao(@"    ___   __                       __          
                                        /   | / /_____ __________ _____/ /___ _____ 
                                       / /| |/ __/ __ `/ ___/ __ `/ __  / __ `/ __ \
                                      / ___ / /_/ /_/ / /__/ /_/ / /_/ / /_/ / /_/ /
                                     /_/  |_\__/\__,_/\___/\__,_/\__,_/\__,_/\____/ 
                                               ",
             posicao,
             2);

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
                case ConsoleKey.Enter: // Ativa a opção selecionada
                    switch (itemSelecionado)
                    {
                        case 0:
                            empresa.ContratarEmpregado();
                            Console.ReadKey();
                            break;

                        case 1:
                            empresa.ListarEmpregados();
                            Console.ReadKey();
                            break;
                        
                        case 2:
                            try
                            {
                                string pNome = "", sobrenome = "", cargo = "";
                                Console.WriteLine("Digite o primeiro nome do empregado");
                                pNome = Console.ReadLine();
                                Console.WriteLine("Digite o sobrenome do empregado");
                                sobrenome = Console.ReadLine();
                                Console.WriteLine("Digite o novo cargo do empregado");
                                cargo = Console.ReadLine();
                                empresa.PromoverEmpregado(pNome, sobrenome, cargo);
                                Console.WriteLine("Promoção realizada!");
                                Console.WriteLine("Aperte uma tecla para continuar.");
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine(ex.Message);
                            }
                            Console.ReadKey();
                            break;

                        case 3:
                            try
                            {
                                string pNome = "", sobrenome = "", cargo = "";
                                Console.WriteLine("Digite o primeiro nome do empregado");
                                pNome = Console.ReadLine();
                                Console.WriteLine("Digite o sobrenome do empregado");
                                sobrenome = Console.ReadLine();
                                empresa.DemitirEmpregado(pNome, sobrenome);
                                Console.WriteLine("Demissão realizada!");
                                Console.WriteLine("Aperte uma tecla para continuar.");
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine(ex.Message);
                            }
                            Console.ReadKey();
                            break;

                        case 4:
                            try
                            {
                                string pNome = "", sobrenome = "", cargo = "";
                                Console.WriteLine("Digite o primeiro nome do empregado");
                                pNome = Console.ReadLine();
                                Console.WriteLine("Digite o sobrenome do empregado");
                                sobrenome = Console.ReadLine();
                                empresa.CalcularSalarioAnual(pNome, sobrenome);
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine(ex.Message);
                            }
                            Console.ReadKey();
                            break;
                        
                        case 5:
                            System.Environment.Exit(1);
                            break;
                    }
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
}