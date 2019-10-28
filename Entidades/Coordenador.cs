using System;
using System.Linq;
using Projeto.teste.Util;

namespace Projeto.teste.Entidades
{
    public class Coordenador:Pessoa
    {

        public Coordenador CadastroCoordenador(Escola Escola)
        {
            if (Cadastro()==null) return null;
            ValidarIdade(25, 80);
            while (NumeroMatricula == 0 || Escola.Coordenadores.Any(x => x.NumeroMatricula == NumeroMatricula)||Escola.Turmas.Any(x=>x.Professor.NumeroMatricula==NumeroMatricula))
                NumeroMatricula = new Random().Next(100000, 999999);

            return this;
        }

        public override string ToString() => $"Nome:{Nome} ,Idade:{Idade} ,Sexo:{Sexo} ,N° de Registro:{NumeroMatricula}";
    }
}
