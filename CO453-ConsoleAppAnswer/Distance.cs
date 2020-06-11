using System;
using System.Collections.Generic;
using System.Text;

namespace CO453_ConsoleAppAnswer
{
    /// <summary>
    /// This class offers methods for prompting the use
    /// to enter the number of miles, and then converting
    /// that into the equivalent number feet
    /// </summary>
    /// <author>Derek Peacock</author>
    public class Distance
    {
        public const int MILES_TO_FEET = 1760 * 3;

        private double miles, feet;

        public void ConvertToFeet()
        {
            Console.WriteLine("Convert Miles to Feet");

            inputMiles();

            feet = miles * MILES_TO_FEET;

            outputFeet();
        }

        private void outputFeet()
        {
            Console.WriteLine(miles + " miles is " + feet + " feet!");
        }

        private void inputMiles()
        {
            Console.Write("Enter the number of miles >");
            string value = Console.ReadLine();
            miles = Convert.ToDouble(value);
        }
    }
}
