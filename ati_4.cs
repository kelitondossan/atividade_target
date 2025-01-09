using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        Dictionary<string, double> faturamentos = new Dictionary<string, double>()
        {
            { "SP", 67836.43 },
            { "RJ", 36678.66 },
            { "MG", 29229.88 },
            { "ES", 27165.48 },
            { "Outros", 19849.53 }
        };

        double total = 0.0;
        foreach (var valor in faturamentos.Values)
        {
            total += valor;
        }

        Console.WriteLine("Percentuais de representação no total mensal:\n");
        foreach (var kv in faturamentos)
        {
            double percentual = (kv.Value / total) * 100;
            Console.WriteLine($"{kv.Key}: {percentual:F2}%");
        }
    }
}
