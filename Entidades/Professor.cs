using Projeto.teste.Util;
using System;
using System.Linq;

namespace Projeto.teste.Entidades
{
    public class Professor : Pessoa
    {
        public Coordenador Coordenador { get; set; }

        public Professor CadastroProfessor(Escola Escola)
        {

            if (Cadastro() == null) return null;

            while (NumeroMatricula == 0 || Escola.Professores.Any(x => x.NumeroMatricula == NumeroMatricula))
                NumeroMatricula = new Random().Next(100000, 999999);

            ValidarIdade(22, 80);

            while (Coordenador == null)
            {
                try
                {
                    Console.WriteLine("Coordenadores");
                    Escola.Coordenadores.ForEach(c => Console.WriteLine($"Nome do Coordenador:{c.Nome} N°:{c.NumeroMatricula}"));
                    Console.WriteLine("Digite o Numero do Coordenador:");
                    Coordenador = Escola.Coordenadores.First(x => x.NumeroMatricula == Convert.ToInt32(Console.ReadLine()));
                }
                catch (Exception)
                {
                    Console.WriteLine("Digite os Valores validos!!!");
                }
            }
            
            return this;
        }
        

        public override string ToString()=> $"Nome:{Nome}  Idade:{Idade}  Sexo:{Sexo}  N° de Registro:{NumeroMatricula} Nome do Coordenador:{Coordenador.Nome}";
        
    }
}
