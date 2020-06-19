using System;

namespace CO453_ConsoleAppAnswer
{
    /// <summary>
    /// This class runs first and create a DistanceConverter
    /// allowing the user three ways of converting distances
    /// </summary>
    /// <author>
    /// Derek Peacock
    /// </author>
    class Program
    {
        static void Main()
        {
            Console.WriteLine("C# Console Applications 2020");

            DistanceConverter converter = new DistanceConverter();

            converter.CalculateFeet();
            converter.CalculateMetres();
            converter.CalculateMiles();
        }
    }
}
