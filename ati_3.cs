using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Linq;

namespace FaturamentoApp
{
    class Program
    {
        public class Faturamento
        {
            public int dia { get; set; }
            public double valor { get; set; }
        }

        static void Main(string[] args)
        {
           
            string jsonFile = "faturamento.json";

            string jsonContent = File.ReadAllText(jsonFile);

            List<Faturamento> dados = JsonSerializer.Deserialize<List<Faturamento>>(jsonContent);

            var faturamentoValido = dados.Where(x => x.valor > 0).Select(x => x.valor).ToList();
            if (faturamentoValido.Count == 0)
            {
                Console.WriteLine("Não há dias com faturamento > 0.");
                return;
            }

            double menor = faturamentoValido.Min();
            double maior = faturamentoValido.Max();
            double media = faturamentoValido.Average();
            int diasAcimaMedia = faturamentoValido.Count(x => x > media);

            Console.WriteLine("===== Análise Faturamento (JSON) =====");
            Console.WriteLine($"Menor valor (ignora 0): {menor}");
            Console.WriteLine($"Maior valor: {maior}");
            Console.WriteLine($"Média mensal (s/ zeros): {media}");
            Console.WriteLine($"Dias acima da média: {diasAcimaMedia}");
        }
    }
}
