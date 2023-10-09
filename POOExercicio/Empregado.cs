namespace POOExercicio
{

    internal class Empregado
    {
        public string PNome { get; set; }
        public string Sobrenome { get; set; }
        public string Matricula { get; set; } = "";
        public int Idade { get; set; }
        public DateTime DataNascimento { get; set; }
        public DateTime DataContratacao { get;}

        private const double SalarioMinimo = 1320;

        public string Cargo { get; set; }

        private double salario;
        public double Salario
        {
            get
            {
                return salario;
            }
            private set
            {
                if(value < SalarioMinimo)
                {
                    salario = SalarioMinimo; //Garante que o valor do salário não seja menor que o salário mínimo
                }
                else
                {
                    salario = value;
                }

            }
        }

        public DateTime DataDeContratacao { get; }
        public double SalarioMensal { get; }

        // Construtor para caso todos os valores sejam fornecidos
        public Empregado(string pNome, string sobrenome, string matricula, int idade, DateTime dataNascimento, DateTime dataContratacao, double salario, string cargo)
        {
            PNome = pNome;
            Sobrenome = sobrenome;
            Matricula = matricula;
            Idade = idade;
            DataNascimento = dataNascimento;
            DataContratacao = dataContratacao;
            Salario = salario;
            Cargo = cargo;
        }

        // Construtor para caso sejam fornecidos apenas dados básicos
        public Empregado(string pNome, string sobrenome, int idade, DateTime dataNascimento)
        {
            PNome = pNome;
            Sobrenome = sobrenome;
            Idade = idade;
            DataNascimento = dataNascimento;
            Salario = 0; //Define salário como 0 por padrão
        }

        public void ImprimirEmpregado()
        {
            Console.WriteLine($"Meu nome é {PNome} {Sobrenome} e recebo {salario} meu cargo é {Cargo}");
        }

        public void ReceberAumento()
        {
            salario *=  1.1;
            salario = Math.Round(salario,2);
        }

       
    }
}
