namespace POOExercicio
{
    internal class Empresa
    {
            public List<Empregado> empregados = new List<Empregado>();
            public string Nome { get; set; } = "";

            public string PorteEmpresa { get; set; } = "";

            public string Setor { get; set; } = "";

            
            internal Empresa(string nome, string porteEmpresa, string setor) {
                this.empregados = new();
                Nome = nome;
                PorteEmpresa = porteEmpresa;
                Setor = setor;
            }
        
            /// <summary>
            /// Concede um aumento de 10% a um funcionário específico
            /// </summary>
            /// <param name="pNome"></param>
            /// <param name="sobrenome"></param>
            public void AumentarSalario(string pNome, string sobrenome)
            {
                Empregado empregadoFeliz = BuscarEmpregado(pNome, sobrenome);
                if (empregadoFeliz == null)
                {
                    Console.WriteLine("Empregado não encontrado");
                    return;
                }
                empregadoFeliz.ReceberAumento();
            }


            /// <summary>
            /// Retorna o salário anual de um empregado (incluindo 13 salário)
            /// </summary>
            /// <param name="pNome"></param>
            /// <param name="sobrenome"></param>
            public void CalcularSalarioAnual(string pNome, string sobrenome)
            {
            
                Empregado empregado = BuscarEmpregado(pNome, sobrenome);
                if (empregado == null)
                {
                    Console.WriteLine("Empregado não encontrado");
                    return;
                }
                Console.WriteLine($"Salário anual do empregado: {empregado.PNome} {empregado.Sobrenome} é {empregado.Salario*13}");
            }

            /// <summary>
            /// Realiza o cadastro de um novo funcionário e inclui o mesmo na relação de funcuinários da empresa.
            /// </summary>
            public void ContratarEmpregado()
            {
                string pNome = "", sobrenome = "", matricula = "", cargo = "";
                int idade = 0;
                DateTime dataDeNascimento = DateTime.MinValue, dataDeContratacao = DateTime.MinValue;
                double salarioMensal = 0;

                try
                {   //Recebe os dados de cadastro do empregado
                    Console.WriteLine("Digite o primeiro nome do empregado");
                    pNome = Console.ReadLine();

                    Console.WriteLine("Digite o sobrenome do empregado");
                    sobrenome = Console.ReadLine();

                    Console.WriteLine("Digite a matrícula do empregado");
                    matricula = Console.ReadLine();

                    Console.WriteLine("Digite a idade do empregado");
                    idade = int.TryParse(Console.ReadLine(), out idade) ? idade : 0; //Caso seja digitado um valor inválido para a idade, é utilizado 0 por padrão.

                    Console.WriteLine("Digite a data de nascimento do empregado");
                    dataDeNascimento = DateTime.Parse(Console.ReadLine());
                    dataDeContratacao = DateTime.Now;

                    Console.WriteLine("Digite o cargo do empregado");
                    cargo = Console.ReadLine();

                    Console.WriteLine("Digite o salário do empregado");
                    salarioMensal = double.TryParse(Console.ReadLine(), out salarioMensal) ? salarioMensal : 0; //Caso seja digitado um valor inválido para o salário, é utilizado 0 por padrão.
                Console.WriteLine("Aperte enter para finalizar o cadastro!");
                }
                catch(Exception ex)
                {   
                    Console.WriteLine(ex.Message);
                }

                // Decide qual construtor utilizar dado a existência de valores para salário e data de nascimento
                if(salarioMensal != 0 && dataDeNascimento != DateTime.MinValue)
                {
                    empregados.Add(new Empregado(pNome, sobrenome, matricula, idade, dataDeNascimento, dataDeContratacao, salarioMensal, cargo));
                }  
                else
                    empregados.Add(new Empregado(pNome, sobrenome, idade, dataDeNascimento));
            }

            /// <summary>
            /// Imprime os dados de todos os empregados cadastrados.
            /// </summary>
            public void ListarEmpregados()
            {
                if (empregados.Count == 0)
                {
                    Console.WriteLine("Empresa não possui empreados.");
                    return;
                }

                foreach (Empregado empregado in empregados)
                    empregado.ImprimirEmpregado();
            }

            /// <summary>
            /// Realiza a promoção de um funcionário, incluindo um aumento de salário.
            /// </summary>
            /// <param name="pNome"></param>
            /// <param name="sobrenome"></param>
            /// <param name="cargo"></param>
            public void PromoverEmpregado(string pNome, string sobrenome, string cargo)
            {
                Empregado promovido = BuscarEmpregado(pNome, sobrenome);
                if (promovido == null)
                {
                    Console.WriteLine("Empregado não encontrado");
                    return;
                }
                promovido.Cargo = cargo;
                promovido.ReceberAumento();

            }
            

            /// <summary>
            /// Realiza a demissão de um funcionário removendo o mesmo da lista de empregados da empresa.
            /// </summary>
            /// <param name="pNome"></param>
            /// <param name="sobrenome"></param>
            public void DemitirEmpregado(string pNome, string sobrenome)
            {
                Empregado demitido = BuscarEmpregado(pNome, sobrenome);
                if (demitido == null)
                {
                    Console.WriteLine("Empregado não encontrado");
                    return;
                }
                empregados.Remove(demitido);

            }

            /// <summary>
            /// Retorna um determinado empregado, caso não seja encontrado, retorna nulo.
            /// </summary>
            /// <param name="pNome"></param>
            /// <param name="sobrenome"></param>
            /// <returns></returns>
            public Empregado? BuscarEmpregado(string pNome, string sobrenome)
            {
                foreach (Empregado empregado in empregados)
                    if (empregado.PNome == pNome && empregado.Sobrenome == sobrenome)
                        return empregado;
                return null;       
            }

        }
}
