using Projeto.teste.Util;
using System;
using System.Linq;

namespace Projeto.teste.Entidades
{
    public class Aluno :Pessoa
    {
        public bool Bolsista { get; set; }

        public Aluno CadastroAluno(Escola Escola)
        {
            if (Cadastro() == null) return null;

            ValidarIdade(6, 19);

            while (NumeroMatricula == 0 || Escola.Alunos.Any(x => x.NumeroMatricula == NumeroMatricula))
                NumeroMatricula = new Random().Next(100000, 999999);

            string bolsa=null;
            while (bolsa != "S" && bolsa != "N")
            {
                Console.WriteLine($"O aluno {Nome} é bolsista(S/N)");
                bolsa = Console.ReadLine().Trim().ToUpper();
            }
            Bolsista = bolsa == "S";
            return this;
        }

        public override string ToString()=> $"Nome:{Nome} Idade:{Idade} Sexo:{Sexo} RA:{NumeroMatricula}";
        
    }
}
