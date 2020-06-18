using System;

namespace CO453_ConsoleAppAnswer
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("C# Console Applications 2020");

            DistanceConverter converter = new DistanceConverter();
            converter.CalculateFeet();
        }
    }
}
