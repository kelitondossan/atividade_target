using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Linq;

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
            string xmlFile = "faturamento.xml";
            var dados = LerXml(xmlFile);

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

            Console.WriteLine("===== Análise Faturamento (XML) =====");
            Console.WriteLine($"Menor valor (ignora 0): {menor}");
            Console.WriteLine($"Maior valor: {maior}");
            Console.WriteLine($"Média mensal (s/ zeros): {media}");
            Console.WriteLine($"Dias acima da média: {diasAcimaMedia}");
        }

        static List<Faturamento> LerXml(string xmlFile)
        {
            XDocument doc = XDocument.Load(xmlFile);

            List<Faturamento> lista = doc
                .Descendants("row")
                .Select(x => new Faturamento {
                    dia = (int)x.Element("dia"),
                    valor = (double)x.Element("valor")
                })
                .ToList();

            return lista;
        }
    }
}
