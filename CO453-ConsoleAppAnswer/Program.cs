namespace CO453_ConsoleAppAnswer
{
    using System;
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
            Console.WriteLine(" C# Console Applications 2020");
            Console.WriteLine("");

            Distance converter = new Distance();

            LengthConverter converter2 = new LengthConverter();
            //converter2.OutputFactors();
            //converter2.Execute();

            //converter.CalculateFeet();
            converter.DoSomething();
            //converter.CalculateMiles();
        }
    }
}
