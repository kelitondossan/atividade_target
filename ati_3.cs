using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    // Classe para representar faturamento diário
    public class FaturamentoDia
    {
        public int Dia { get; set; }
        public double Valor { get; set; }
    }

    static void Main(string[] args)
    {
        //Ddados (poderia vir de um arquivo JSON/XML)
        List<FaturamentoDia> dados = new List<FaturamentoDia>
        {
            new FaturamentoDia { Dia = 1, Valor = 22174.1664 },
            new FaturamentoDia { Dia = 2, Valor = 0.0 },
            new FaturamentoDia { Dia = 3, Valor = 24537.6698 },
            new FaturamentoDia { Dia = 4, Valor = 26139.6134 },
            new FaturamentoDia { Dia = 5, Valor = 0.0 },
            new FaturamentoDia { Dia = 6, Valor = 0.0 },
            new FaturamentoDia { Dia = 7, Valor = 29408.1673 },
        };

        var faturamentosValidos = dados
            .Where(x => x.Valor > 0)
            .Select(x => x.Valor)
            .ToList();

        if (faturamentosValidos.Count == 0)
        {
            Console.WriteLine("Não há dias com faturamento > 0 para analisar.");
            return;
        }

        double menorValor = faturamentosValidos.Min();
        double maiorValor = faturamentosValidos.Max();

        double media = faturamentosValidos.Average();

        int diasAcimaMedia = faturamentosValidos.Count(valor => valor > media);

        Console.WriteLine($"Menor valor de faturamento (acima de 0): {menorValor}");
        Console.WriteLine($"Maior valor de faturamento: {maiorValor}");
        Console.WriteLine($"Média mensal (só dias com valor > 0): {media}");
        Console.WriteLine($"Dias com faturamento acima da média: {diasAcimaMedia}");
    }
}
