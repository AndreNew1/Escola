using Projeto.teste.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Projeto.teste.Util
{
    public class Escola
    {
        public List<Turma> Turmas { get; set; } = new List<Turma>();
        public List<Aluno> Alunos { get; set; } = new List<Aluno>();
        public List<Professor> Professores { get; set; } = new List<Professor>();
        public List<Coordenador> Coordenadores { get; set; } = new List<Coordenador>();

        string Controle;

        public void MenuPrincipal()
        {

            Console.WriteLine("Digite 1 para ir ao Menu Aluno\nDigite 2 para cadastrar um professor \nDigite 3 para cadastrar um coordenador \nDigite 4 para cadastrar um turma \nDigite 0 para sair");
            Controle = Console.ReadLine();
            switch (Controle)
            {
                case "1":
                    {
                        MenuAluno();
                        break;
                    }
                case "2":
                    {
                        MenuProfessor();
                        break;
                    }
                case "3":
                    {
                        MenuCoordenador();
                        break;
                    }
                case "4":
                    {
                        MenuTurma();
                        break;
                    }
                case "0":
                    {
                        Environment.Exit(0);
                        break;
                    }
                default:
                    Console.WriteLine("Opção Invalida");
                    break;
            }
            Arquivo.SalvarOuLer(this);
            MenuPrincipal();
        }

        public void MenuAluno()
        {
            Console.WriteLine("Digite 1 para cadastrar um aluno \nDigite 2 para ver alunos na lista de espera \nDigite 3 para Atribuir um aluno a uma turma \nDigite 4 para Remover um aluno\nDigite 0 para voltar ao menu principal");
            Controle = Console.ReadLine();

            switch (Controle)
            {
                case "1":
                    {
                        Aluno aluno = new Aluno().CadastroAluno(this);
                        if (aluno == null) break;
                        Alunos.Add(aluno);
                        break;
                    }
                case "2":
                    {
                        Console.WriteLine("lista de Espera Alunos");
                        Alunos.ForEach(c => Console.WriteLine(c.ToString()));
                        Console.WriteLine("Pressione Enter para voltar ao menu");
                        Console.ReadLine();
                        break;
                    }
                case "3":
                    {
                        if (Turmas.Count == 0){ Console.WriteLine("Registre uma turma e um aluno primeiro"); break;}
                        try
                        {
                            Console.WriteLine("Turmas:");
                            Turmas.ForEach(c => Console.WriteLine($"N° da Turma:{c.NumTurma}"));
                            Console.WriteLine("Digite o numero da turma Ou pressione Enter para voltar");
                            string decisao = Console.ReadLine();
                            if (decisao == "") break;
                            Turmas.First(x => x.NumTurma == Convert.ToInt32(decisao)).AtribuirAluno(Alunos);
                        }
                        catch (ArgumentNullException)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Turma não existe");
                        }
                        catch(Exception)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Valores Invalidos");
                        }
                        break;
                    }
                case "4":
                    {
                        if (Turmas.Count == 0) { Console.WriteLine("Registre uma turma e um aluno primeiro"); break; }
                        try
                        {
                            Console.WriteLine("Turmas:");
                            Turmas.ForEach(c => Console.WriteLine($"N° da Turma:{c.NumTurma}"));
                            Console.WriteLine("Digite o numero da turma Ou pressione Enter para voltar");
                            string decisao = Console.ReadLine();
                            if (decisao == "") break;
                            Turmas.First(x => x.NumTurma == Convert.ToInt32(decisao)).RemoverAluno(Alunos);
                        }
                        catch (ArgumentNullException)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Turma não existe");
                        }
                        catch (Exception)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Valores Invalidos");
                        }
                        break;
                    }
                case "0":
                    {
                        MenuPrincipal();
                        break;
                    }
                default:
                    {
                        Console.WriteLine("Opção invalida");
                        break;
                    }
            }
            Arquivo.SalvarOuLer(this);
            MenuAluno();
        }

        public void MenuProfessor()
        {
            Console.WriteLine("Digite 1 para cadastrar um professor \nDigite 2 para ver professores na lista de espera \nDigite 3 para Atribuir um professor a uma turma\nDigite 0 para voltar ao menu principal");
            Controle = Console.ReadLine();

            switch (Controle)
            {
                case "1":
                    {
                        Professor professor = new Professor().CadastroProfessor(this);
                        if (professor == null) break;
                        Professores.Add(professor);
                        break;
                    }
                case "2":
                    {
                        Console.WriteLine("lista de Espera professores");
                        Professores.ForEach(c => Console.WriteLine(c.ToString()));
                        Console.WriteLine("Pressione Enter para voltar ao menu");
                        Console.ReadLine();
                        break;
                    }
                case "3":
                    {
                        if (Turmas.Count == 0) { Console.WriteLine("Registre uma turma e um professor primeiro"); break; }
                        while (true)
                        {
                            try
                            {
                                Console.WriteLine("Turmas:");
                                Turmas.ForEach(c => Console.WriteLine($"N° da Turma:{c.NumTurma}"));
                                Console.WriteLine("Digite o numero da turma Ou pressione Enter para voltar");
                                string decisao = Console.ReadLine();
                                if (decisao == "") break;
                                Turmas.First(x => x.NumTurma == Convert.ToInt32(decisao)).AtribuirProfessor(this);
                                break;
                            }
                            catch (ArgumentNullException)
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("Turma não existe");
                            }
                            catch (Exception)
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("Valores Invalidos");
                            }
                        }
                        break;
                    }
                case "4":
                    {
                        if (Turmas.Count == 0) { Console.WriteLine("Registre uma turma e um professor primeiro"); break; }
                        try
                        {
                            Console.WriteLine("Turmas:");
                            Turmas.ForEach(c => Console.WriteLine($"N° da Turma:{c.NumTurma}"));
                            Console.WriteLine("Digite o numero da turma Ou pressione Enter para voltar");
                            string decisao = Console.ReadLine();
                            if (decisao == "") break;
                            Turmas.First(x => x.NumTurma == Convert.ToInt32(decisao)).RemoverProfessor(this);
                        }
                        catch (ArgumentNullException)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Turma não existe");
                        }
                        catch (Exception)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Valores Invalidos");
                        }
                        break;
                    }
                case "0":
                    {
                        MenuPrincipal();
                        break;
                    }
                default:
                    {
                        Console.WriteLine("Opção invalida");
                        break;
                    }
            }
            Arquivo.SalvarOuLer(this);
            MenuProfessor();
        }

        public void MenuCoordenador()
        {
            Console.WriteLine("Digite 1 para cadastrar um coordenado \nDigite 2 para ver todos os coordenadores \nDigite 3 para Atribuir um coordenador a uma turma \nDigite 4 para Remover um coordenador\nDigite 0 para voltar ao menu principal");
            Controle = Console.ReadLine();

            switch (Controle)
            {
                case "1":
                    {
                        Coordenador coordenador = new Coordenador().CadastroCoordenador(this);
                        if (coordenador == null) break;
                        Coordenadores.Add(coordenador);
                        break;
                    }
                case "2":
                    {
                        Console.WriteLine("lista de Coordenadores");
                        Coordenadores.ForEach(c => Console.WriteLine(c.ToString()));
                        Console.WriteLine("Pressione Enter para voltar ao menu");
                        Console.ReadLine();
                        break;
                    }
                case "3":
                    {
                        if (Turmas.Count == 0) { Console.WriteLine("Registre uma turma primeiro"); break; }
                        while (true)
                        {
                            try
                            {
                                Console.WriteLine("Turmas:");
                                Turmas.ForEach(c => Console.WriteLine($"N° da Turma:{c.NumTurma}"));
                                Console.WriteLine("Digite o numero da turma Ou pressione Enter para voltar");
                                string decisao = Console.ReadLine();
                                if (decisao == "") break;
                                Turmas.First(x => x.NumTurma == Convert.ToInt32(decisao)).AtribuirCoordenador(Coordenadores);
                                break;
                            }
                            catch (ArgumentNullException)
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("Turma não existe");
                            }
                            catch (Exception)
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("Valores Invalidos");
                            }
                        }
                        break;
                    }
                case "4":
                    {
                        if (Turmas.Count == 0) { Console.WriteLine("Registre uma turma primeiro"); break; }
                        while (true)
                        {
                            try
                            {
                                Console.WriteLine("Turmas:");
                                Turmas.ForEach(c => Console.WriteLine($"N° da Turma:{c.NumTurma}"));
                                Console.WriteLine("Digite o numero da turma Ou pressione Enter para voltar");
                                string decisao = Console.ReadLine();
                                if (decisao == "") break;
                                Turmas.First(x => x.NumTurma == Convert.ToInt32(decisao)).RemoverCoordenador();
                                break;
                            }
                            catch (ArgumentNullException)
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("Turma não existe");
                            }
                            catch (Exception)
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("Valores Invalidos");
                            }
                        }
                        break;
                    }
                case "0":
                    {
                        MenuPrincipal();
                        break;
                    }
                default:
                    {
                        Console.WriteLine("Opção invalida");
                        break;
                    }
            }
            Arquivo.SalvarOuLer(this);
            MenuCoordenador();
        }

        public void MenuTurma()
        {
            Console.WriteLine("Digite 1 para cadastrar um coordenado \nDigite 2 para ver todos os turmas \nDigite 3 mostrar informações da turma\nDigite 0 para voltar ao menu principal");
            Controle = Console.ReadLine();

            switch (Controle)
            {
                case "1":
                    {
                        Turma turma = new Turma().CriarTurma(this);
                        if (turma == null) break;
                        Turmas.Add(turma);
                        break;
                    }
                case "2":
                    {
                        Console.WriteLine("lista de Turmas");
                        Turmas.ForEach(c => Console.WriteLine($"Turma:{c.NumTurma}  Nome do coordenador:{(c.Coordenador==null? "Não ha professor" : c.Coordenador.Nome)} Nome do Professor:{(c.Professor==null?"Não ha professor":c.Professor.Nome)}"));
                        Console.WriteLine("Pressione Enter para voltar ao menu");
                        Console.ReadLine();
                        break;
                    }
                case "3":
                    {
                        if (Turmas.Count == 0) { Console.WriteLine("Registre uma turma primeiro"); break; }
                        while (true)
                        {
                            try
                            {
                                Console.WriteLine("Turmas:");
                                Turmas.ForEach(c => Console.WriteLine($"N° da Turma:{c.NumTurma}"));
                                Console.WriteLine("Digite o numero da turma Ou pressione Enter para voltar");
                                string decisao = Console.ReadLine();
                                if (decisao == "") break;
                                Console.WriteLine(Turmas.First(x => x.NumTurma == Convert.ToInt32(decisao)).ToString());
                                Console.WriteLine("Aperte enter para continuar");
                                Console.ReadLine();
                                break;
                            }
                            catch (ArgumentNullException)
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("Turma não existe");
                            }
                            catch (Exception)
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("Valores Invalidos");
                            }
                        }
                        break;
                    }
                case "0":
                    {
                        MenuPrincipal();
                        break;
                    }
                default:
                    {
                        Console.WriteLine("Opção invalida");
                        break;
                    }
            }
            Arquivo.SalvarOuLer(this);
            MenuCoordenador();
        }
    }
}
