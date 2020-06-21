namespace CO453_ConsoleAppAnswer
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    /// <summary>
    /// This class offers methods for prompting the user
    /// to input the number of miles, and then calculates
    /// and outputs the equivalent number feet
    /// </summary>
    /// <author>
    /// Derek Peacock
    /// </author>
    class DistanceConverter
    {
        public const int FEET_IN_MILES = 5280;
        public const double METRES_IN_MILES = 1609.34;
        public const double MILES_IN_KILOMETRES = 0.621371;

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
            InputMiles();

            feet = miles * FEET_IN_MILES;

            OutputFeet();
        }

        /// <summary>
        /// Calculate how many metres there are in the given miles
        /// </summary>
        public void CalculateMetres()
        {
            OutputHeading();
            InputMiles();

            metres = miles * METRES_IN_MILES;

            OutputMetres();
        }


        /// <summary>
        /// Calculate how many Miles there are in the given Kilometres
        /// </summary>
        public void CalculateMiles()
        {
            OutputHeading();
            InputKilometres();

            miles = kiloMetres * MILES_IN_KILOMETRES;

            OutputMiles();
        }

        /// <summary>
        /// Prompt the user to input the number of kilometres
        /// </summary>
        private void InputKilometres()
        {
            Console.Write("  Enter the number of Kilometres >");
            string value = Console.ReadLine();
            kiloMetres = Convert.ToDouble(value);
        }

        /// <summary>
        /// Prompt the user to input the number of miles
        /// </summary>
        private void InputMiles()
        {
            Console.Write("  Enter the number of miles >");
            string value = Console.ReadLine();
            miles = Convert.ToDouble(value);
        }

        /// <summary>
        /// Output how many feet there are in the given miles
        /// </summary>
        private void OutputFeet()
        {
            Console.WriteLine();
            Console.WriteLine($"  {miles} miles is {feet} feet!");
            Console.WriteLine();
        }

        /// <summary>
        /// Output the number of metres in the given distance in miles
        /// </summary>
        private void OutputMetres()
        {
            Console.WriteLine();
            Console.WriteLine($"  {miles} miles is {metres} metres!");
            Console.WriteLine();
        }


        /// <summary>
        /// Output the number of miles in the given distance in Kilometres
        /// </summary>
        private void OutputMiles()
        {
            Console.WriteLine();
            Console.WriteLine("  " + kiloMetres + " Kilometres is " + miles + " miles!");
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

