namespace CO453_ConsoleAppAnswer
{
    using System;

    /// <summary>
    /// This class offers methods for prompting the use
    /// to enter the number of miles, and then converting
    /// that into the equivalent number feet
    /// </summary>
    /// <author>
    /// Derek Peacock
    /// </author>
    public class Distance
    {
        public const int MILES_TO_FEET = 1760 * 3;

        private double miles, feet;

        public void ConvertToFeet()
        {
            Console.WriteLine("Convert Miles to Feet");

            InputMiles();

            feet = miles * MILES_TO_FEET;

            OutputFeet();
        }

        private void OutputFeet()
        {
            Console.WriteLine(miles + " miles is " + feet + " feet!");
        }

        private void InputMiles()
        {
            Console.Write("Enter the number of miles >");
            string value = Console.ReadLine();
            miles = Convert.ToDouble(value);
        }
    }
}
