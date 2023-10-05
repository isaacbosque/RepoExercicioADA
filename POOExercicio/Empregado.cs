using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



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
                    salario = SalarioMinimo;
                }

            }
        }

        public DateTime DataDeContratacao { get; }
        public double SalarioMensal { get; }

        public Empregado(string pNome, string sobrenome, string matricula, int idade, DateTime dataNascimento, DateTime dataContratacao, double salario)
        {
            PNome = pNome;
            Sobrenome = sobrenome;
            Matricula = matricula;
            Idade = idade;
            DataNascimento = dataNascimento;
            DataContratacao = dataContratacao;
            Salario = salario;
        }

        public Empregado(string pNome, string sobrenome, int idade, DateTime dataNascimento)
        {
            PNome = pNome;
            Sobrenome = sobrenome;
            Idade = idade;
            DataNascimento = dataNascimento;
        }

        public void ImprimirEmpregado()
        {
            Console.WriteLine($"Meu nome é {PNome} {Sobrenome} e recebo {Salario}");
        }

        public void ReceberAumento()
        {
            salario *=  1.1;
        }

       
    }
}
