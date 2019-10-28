using System;
using System.Text.RegularExpressions;
using Projeto.teste.Util;

namespace Projeto.teste.Entidades
{
    public abstract class Pessoa
    {
        public string Nome { get; set; }
        public int Idade { get; set; }
        public string Sexo { get; set; }
        public int NumeroMatricula { get; set; }

        public  Pessoa Cadastro()
        {
            while (string.IsNullOrEmpty(Nome) || new Regex(@"[0-9]").IsMatch(Nome))
            {
                Console.WriteLine($"Digite o nome do {GetType().Name} Ou pressione Enter para voltar");
                Nome = Console.ReadLine().Trim();
                if (Nome == "") return null;
            } 

            while (Sexo!="M" && Sexo != "F")
            {
                Console.WriteLine($"Digite o Sexo de {Nome} (M/F)");
                Sexo = Console.ReadLine().Trim().ToUpper();
            }

            return this;
        }

        protected void ValidarIdade(int IdadeMin,int IdadeMax)
        {
            while (Idade < IdadeMin || Idade > IdadeMax)
            {
                try
                {
                    Console.WriteLine($"Digite a Idade de {Nome}");
                    Idade = Convert.ToInt32(Console.ReadLine());
                    if (Idade < IdadeMin || Idade > IdadeMax)
                    {
                        Console.WriteLine("Idade Invalida");
                        Console.WriteLine($"Idade deve ser entre {IdadeMin} e {IdadeMax}");
                    }
                }
                catch (Exception)
                {
                    Console.WriteLine("Digite um numero valido");
                }
            }
        }        
    }
}
