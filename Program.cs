using Projeto.teste.Util;

namespace Projeto.teste
{
    class Program
    {
        static void Main(string[] args)
        {
            Escola Escola = Arquivo.SalvarOuLer(null);
            Escola = Escola ?? new Escola();
            Escola.MenuPrincipal();
        }
    }
}
