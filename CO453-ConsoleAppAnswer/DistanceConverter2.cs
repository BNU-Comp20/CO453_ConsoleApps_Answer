namespace CO453_ConsoleAppAnswer
{
    using System;

    /// <summary>
    /// This class offers methods for prompting the user
    /// to input the number of miles, and then calculates
    /// and outputs the equivalent number feet
    /// </summary>
    /// <author>
    /// Derek Peacock
    /// </author>
    public class DistanceConverter2
    {
        public const int FeetInMiles = 5280;
        public const double MetresInMiles = 1609.34;
        public const double MilesInKilometres = 0.621371;

        // Distance Units
        private double miles;
        private double feet;
        private double metres;
        private double kiloMetres;

        /// <summary>
        /// Calculate how many feet there are in the given miles
        /// </summary>
        public void CalculateFeet()
        {
            OutputHeading();
            feet = InputNumber("Enter the number of miles > ");

            feet = miles * FeetInMiles;

            OutputResult("miles", miles, "feet", feet);
        }

        /// <summary>
        /// Calculate how many metres there are in the given miles
        /// </summary>
        public void CalculateMetres()
        {
            OutputHeading();
            miles = InputNumber("Enter the number of miles > ");

            metres = miles * MetresInMiles;

            OutputResult("miles", miles, "metres", metres);
        }


        /// <summary>
        /// Calculate how many Miles there are in the given Kilometres
        /// </summary>
        public void CalculateMiles()
        {
            OutputHeading();
            kiloMetres = InputNumber("Enter the number of Kilometers > ");

            miles = kiloMetres * MilesInKilometres;

            OutputResult("kilometres", kiloMetres, "miles", miles);
        }

        /// <summary>
        /// Prompt the user to input a double number
        /// </summary>
        private double InputNumber(string prompt)
        {
            Console.Write(prompt);
            string value = Console.ReadLine();
            return Convert.ToDouble(value);
        }

        /// <summary>
        /// Output the number of metres in the given distance in miles
        /// </summary>
        private void OutputResult(string fromUnit, double fromNumber, 
                                  string toUnit,   double toNumber)
        {
            Console.WriteLine();
            Console.WriteLine($"  {fromNumber} {fromUnit} is {toNumber} {toUnit} !");
            Console.WriteLine();
        }

        /// <summary>
        /// Output a Heading for the distance converter
        /// </summary>
        private void OutputHeading()
        {
            Console.WriteLine();
            Console.WriteLine("  -----------------------------");
            Console.WriteLine("         Convert Distances     ");
            Console.WriteLine("         by Derek Peacock      ");
            Console.WriteLine("  -----------------------------");
            Console.WriteLine();
        }
    }
}
