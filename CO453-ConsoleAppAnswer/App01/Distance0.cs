using System;

namespace CO453_ConsoleAppAnswer
{
    /// <summary>
    /// This class offers methods for prompting the use
    /// to enter the number of miles, and then converting
    /// that into the equivalent number feet
    /// </summary>
    /// <author>
    /// Derek Peacock
    /// </author>
    public class Distance0
    {
        public const int FEET_IN_MILES = 5280;

        private double feet;  // distance in miles
        private double miles; // distance in feet


        /// <summary>
        /// convert the distance measured in miles to feet
        /// </summary>
        public void ConvertMilesToFeet()
        {
            OutputHeading();
            InputMiles();

            feet = miles * FEET_IN_MILES;
            
            OutputFeet();
        }

        /// <summary>
        /// Output the given distance measured in feet
        /// </summary>
        private void OutputFeet()
        {
        }

        /// <summary>
        /// Input a distance measured in miles
        /// </summary>
        private void InputMiles()
        {
        }

        /// <summary>
        /// Output a Heading for the distance converter
        /// </summary>
        private void OutputHeading()
        {
            Console.WriteLine();
            Console.WriteLine("  -----------------------------");
            Console.WriteLine("       Convert Miles to Feet   ");
            Console.WriteLine("       by Derek Peacock        ");
            Console.WriteLine("  -----------------------------");
            Console.WriteLine();
        }

    }

}
