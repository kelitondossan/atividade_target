using System;

class Program
{
    static void Main(string[] args)
    {
        Console.Write("Informe um número: ");
        int numero = int.Parse(Console.ReadLine());

        if (PertenceFibonacci(numero))
            Console.WriteLine($"O número {numero} pertence à sequência de Fibonacci.");
        else
            Console.WriteLine($"O número {numero} não pertence à sequência de Fibonacci.");
    }

    static bool PertenceFibonacci(int numero)
    {
        if (numero == 0) return true;

        int a = 0;
        int b = 1;

        while (a <= numero)
        {
            if (a == numero)
                return true;
            
            int temp = a + b;
            a = b;
            b = temp;
        }

        return false;
    }
}
