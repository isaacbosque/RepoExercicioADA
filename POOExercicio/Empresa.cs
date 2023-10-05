using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace POOExercicio
{
    internal class Empresa
    {
            public List<Empregado> empregados = new List<Empregado>();
            public string Nome { get; set; } = "";

            public string PorteEmpresa { get; set; } = "";

            public string Setor { get; set; } = "";

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
            public void ContratarEmpregado()
            {
                string pNome = "", sobrenome = "", matricula = "";
                int idade = 0;
                DateTime dataDeNascimento = DateTime.MinValue, dataDeContratacao = DateTime.MinValue;
                double salarioMensal = 0;

                try
                {
                    Console.WriteLine("Digite o primeiro nome do empregado");
                    pNome = Console.ReadLine();
                    Console.WriteLine("Digite o sobrenome do empregado");
                    sobrenome = Console.ReadLine();
                    Console.WriteLine("Digite a matrícula do empregado");
                    matricula = Console.ReadLine();
                    Console.WriteLine("Digite a idade do empregado");
                    idade = int.TryParse(Console.ReadLine(), out idade) ? idade : 0;
                    Console.WriteLine("Digite a data de nascimento do empregado");
                    dataDeNascimento = DateTime.Parse(Console.ReadLine());
                    dataDeContratacao = DateTime.Now;
                    Console.WriteLine("Digite o salário do empregado");
                    salarioMensal = double.Parse(Console.ReadLine());
                    Console.WriteLine("Aperte enter para finalizar o cadastro!");
                }
                catch(Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

                if(salarioMensal != 0 && dataDeNascimento != DateTime.MinValue)
                    empregados.Add(new Empregado(pNome, sobrenome, matricula, idade, dataDeNascimento, dataDeContratacao, salarioMensal));
                else
                    empregados.Add(new Empregado(pNome, sobrenome, idade, dataDeNascimento));
            }

            public void ListarEmpregados()
            {
                foreach (Empregado empregado in empregados)
                    empregado.ImprimirEmpregado();
            }

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

            public Empregado? BuscarEmpregado(string pNome, string sobrenome)
            {
                foreach (Empregado empregado in empregados)
                    if (empregado.PNome == pNome && empregado.Sobrenome == sobrenome)
                        return empregado;
                return null;       
            }

        }
}
