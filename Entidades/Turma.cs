using Projeto.teste.Util;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Projeto.teste.Entidades
{
    public class Turma
    {
        public int NumTurma { get; set; }
        public Professor Professor { get; set; }
        public Coordenador Coordenador { get; set; }
        public List<Aluno> Alunos { get; set; }
        private int MaxAlunos {get;set;}
        public Turma CriarTurma(Escola Escola)
        {
            while (NumTurma == 0 || Escola.Turmas.Any(x => x.NumTurma == NumTurma))
                NumTurma = new Random().Next(100000, 999999);

            while (Alunos == null)
            {
                try
                {
                    Console.WriteLine($"Quantos Alunos a turma terá? Ou pressione Enter para voltar");
                    string temp = Console.ReadLine();
                    if (temp == "") return null;
                    Alunos = new List<Aluno>(MaxAlunos=Convert.ToInt32(temp));
                }
                catch (Exception)
                {
                    Console.WriteLine("Digite um valor valido!!!!");
                }
            }

            Console.WriteLine($"Turma cadastrada com sucesso \n N° da turma:{NumTurma}");
            return this;
        }
        public Professor AtribuirProfessor(Escola Escola)
        {

            Console.ResetColor();
            try
            {
                Console.WriteLine("Professores");
                Escola.Professores.ForEach(c => Console.WriteLine($"Nome:{c.Nome} N° de Registro:{c.NumeroMatricula}"));
                Console.WriteLine("Digite o Numero de Registro Ou Pressione Enter");
                string decisao = Console.ReadLine();
                if (decisao == "") return null;
                var professor = Escola.Professores.First(x => x.NumeroMatricula == Convert.ToInt32(decisao));

                if (Professor != null && !Escola.Professores.Any(x => x == Professor)) Escola.Professores.Add(Professor);

                Professor = professor;

                if (Escola.Turmas.Where(x => x.Professor == professor).Count() == 2) Escola.Professores.Remove(Professor);
            }
            catch (ArgumentException)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Professor não existe\nDigite Novamente");
                AtribuirProfessor(Escola);
            }
            catch (Exception)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Digite Valores Validos!!!");
                AtribuirProfessor(Escola);
            }

            return Professor;
        }     
        public Aluno AtribuirAluno(List<Aluno> alunos)
        {
            if (Alunos.Count() == MaxAlunos)
            {
                Console.WriteLine("Turma ja esta cheia remova um para continuar");
                return null;
            } 
            Aluno aluno = null;
            do
            {
                Console.ResetColor();
                try
                {
                    Console.WriteLine("Alunos sem Turmas");
                    alunos.ForEach(c => Console.WriteLine($"Nome:{c.Nome} N° de Registro:{c.NumeroMatricula}"));
                    Console.WriteLine("Digite o Numero de Registro Ou Pressione Enter");
                    string decisao = Console.ReadLine();
                    if (decisao == "") return null;
                    aluno = alunos.First(x => x.NumeroMatricula == Convert.ToInt32(decisao));
                }
                catch (ArgumentException)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Aluno não existe\nDigite Novamente");
                }
                catch (Exception)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Digite Valores Validos!!!");
                }

            } while (aluno == null);
            alunos.Remove(aluno);
            Alunos.Add(aluno);
            return aluno;
        }
        public Aluno RemoverAluno(List<Aluno> alunos)
        {
            Aluno aluno = null;
            do
            {
                Console.ResetColor();
                try
                {
                    Console.WriteLine($"Turma Numero:{NumTurma} Alunos");
                    Alunos.ForEach(c => Console.WriteLine($"Nome:{c.Nome} N° de Registro:{c.NumeroMatricula}"));
                    Console.WriteLine("Digite o Numero de Registro Ou Pressione Enter para sair");
                    string decisao = Console.ReadLine();
                    if (decisao == "") return null;
                    aluno = Alunos.First(x => x.NumeroMatricula == Convert.ToInt32(decisao));
                }
                catch (ArgumentException)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Aluno não existe\nDigite Novamente");
                }
                catch (Exception)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Digite Valores Validos!!!");
                }

            } while (aluno == null);

            Alunos.Remove(aluno);

            alunos.Add(aluno);

            return aluno;
        }
        public Coordenador AtribuirCoordenador(List<Coordenador> Coordenadores)
        {
            Console.ResetColor();
            try
            {
                Console.WriteLine("Professores");
                Coordenadores.ForEach(c => Console.WriteLine($"Nome:{c.Nome} N° de Registro:{c.NumeroMatricula}"));
                Console.WriteLine("Digite o Numero de Registro Ou Pressione Enter");
                string decisao = Console.ReadLine();
                if (decisao == "") return null;
                Coordenador = Coordenadores.First(x => x.NumeroMatricula == Convert.ToInt32(decisao));
            }
            catch (ArgumentException)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Professor não existe\nDigite Novamente");
                AtribuirCoordenador(Coordenadores);
            }
            catch (Exception)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Digite Valores Validos!!!");
                AtribuirCoordenador(Coordenadores);
            }

            return Coordenador;
        }
        public void RemoverCoordenador()
        {
            Coordenador = null;
            Console.WriteLine("Coordenador removido");
        }
        public void RemoverProfessor(Escola Escola)
        {

            if (!Escola.Professores.Any(x => x == Professor)) Escola.Professores.Add(Professor);

            Professor = null;
            Console.WriteLine($"Professor removido da Turma:{NumTurma}");
        }
        public override string ToString()
        {
            return $"Numero da Turma:{NumTurma} \nNome do Professor:{Professor.Nome} N° de registro:{Professor.NumeroMatricula} \n{TurmaAlunos()}";
        }
        private string TurmaAlunos()
        {
            string retorno = "Alunos na Sala";

            Alunos.ForEach(c => retorno += $"\n Nome:{c.Nome} RA:{c.NumeroMatricula}");
            return retorno;
        }
    }
}
