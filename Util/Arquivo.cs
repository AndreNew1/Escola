using Newtonsoft.Json;
using System;
using System.IO;

namespace Projeto.teste.Util
{
    public static class Arquivo
    {
        private static string Caminho = $"{AppDomain.CurrentDomain.BaseDirectory}/Escola.json";
        public static Escola SalvarOuLer(Escola escola)
        {
            if (!File.Exists(Caminho)) File.Create(Caminho).Close();

            if (escola == null) return JsonConvert.DeserializeObject<Escola>(File.ReadAllText(Caminho));

            File.WriteAllText(Caminho, JsonConvert.SerializeObject(escola));
            return null;
        }
    }
}
