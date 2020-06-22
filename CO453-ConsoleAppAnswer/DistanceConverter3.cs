using System;
using System.Collections.Generic;
using System.Text;

namespace CO453_ConsoleAppAnswer
{
    /// <summary>
    /// This class offers methods for prompting the user
    /// to select a distance unit to convert from, and a
    /// distance unit to convert to, and then calculates
    /// and outputs the number toUnits for the given 
    /// fromUnits.
    /// </summary>
    /// <author>
    /// Derek Peacock
    /// </author>
    class DistanceConverter3
    {
        // Conversion Factors
        public const int FeetInMiles = 5280;
        public const double MetresInMiles = 1609.34;
        public const double KilometresInMiles = 1.60934;

        public const double FeetInKilometres = 3280.84;
        public const double MetresInKilometres = 1000;
        public const double MilesInKilometres = 0.621371;

        public const double FeetInMetres = 1 / MetresInFeet;
        public const double KilometersInMetres = 1 / MetresInKilometres;
        public const double MilesInMetres = 1 / MetresInMiles;

        public const double MetresInFeet = 0.3048;
        public const double KilometresInFeet = 1 / FeetInKilometres;
        public const double MilesInFeet = 1 / FeetInMiles;

        // Available Distance Units
        public const string Feet = "Feet";
        public const string Metres = "Metres";
        public const string Kilometres = "Kilometres";
        public const string Miles = "Miles";

        // Convert from distance value and unit
        private double fromValue;
        private string fromUnit;

        // Convert to distance value and unit
        private double toValue;
        private string toUnit;

        /// <summary>
        /// Calculate how many toUnits there are in the given fromUnits
        /// </summary>
        public void Execute()
        {
            OutputHeading();

            fromUnit = SelectUnit(" Enter unit to convert from > ");
            fromValue = InputNumber($" Enter the number of {fromUnit} > ");

            toUnit = SelectUnit(" Enter unit to convert to > ");

            if ((fromUnit == Miles) && (toUnit == Feet))
            {
                toValue = fromValue * FeetInMiles;
            }
            else if ((fromUnit == Miles) && (toUnit == Metres))
            {
                toValue = fromValue * MetresInMiles;
            }
            else if ((fromUnit == Miles) && (toUnit == Kilometres))
            {
                toValue = fromValue * KilometresInMiles;
            }
            else if ((fromUnit == Kilometres) && (toUnit == Miles))
            {
                toValue = fromValue * MilesInKilometres;
            }
            else if ((fromUnit == Kilometres) && (toUnit == Metres))
            {
                toValue = fromValue * MetresInKilometres;
            }
            else if ((fromUnit == Kilometres) && (toUnit == Feet))
            {
                toValue = fromValue * FeetInKilometres;
            }

            OutputResult();
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
        private void OutputResult()
        {
            Console.WriteLine();
            Console.WriteLine($"  {fromValue} {fromUnit} is {toValue} {toUnit} !");
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


        private string SelectUnit(string prompt)
        {
            Console.WriteLine();
            Console.WriteLine(" 1. Feet");
            Console.WriteLine(" 2. Metres");
            Console.WriteLine(" 3. Kilometres");
            Console.WriteLine(" 4. Miles");
            Console.WriteLine();

            Console.Write(prompt);
            string choice = Console.ReadLine();

            string unit = Miles;

            if (choice == "1")
            {
                unit = Feet;
            }
            else if (choice == "2")
            {
                unit = Metres;
            }
            else if (choice == "3")
            {
                unit = Kilometres;
            }

            return unit;
        }
    }
}
