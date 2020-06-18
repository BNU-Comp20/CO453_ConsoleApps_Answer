using System;
using System.Collections.Generic;
using System.Text;

namespace CO453_ConsoleAppAnswer
{
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

        private double miles;  // distance in miles
        private double feet;   // distance in feet

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

        private void OutputHeading()
        {
            Console.WriteLine();
            Console.WriteLine("  -----------------------------");
            Console.WriteLine("      Convert Miles to Feet    ");
            Console.WriteLine("         by Derek Peacock      ");
            Console.WriteLine("  -----------------------------");
            Console.WriteLine();
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
            Console.WriteLine("  " + miles + " miles is " + feet + " feet!");
            Console.WriteLine();
        }
    }

}

