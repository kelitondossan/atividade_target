using System;

class Program
{
    static void Main(string[] args)
    {
        Console.Write("Digite uma palavra ou frase: ");
        string original = Console.ReadLine();

        string invertida = InverterString(original);
        Console.WriteLine($"String invertida: {invertida}");
    }

    static string InverterString(string texto)
    {
        string resultado = "";
        for (int i = texto.Length - 1; i >= 0; i--)
        {
            resultado += texto[i];
        }
        return resultado;
    }
}
