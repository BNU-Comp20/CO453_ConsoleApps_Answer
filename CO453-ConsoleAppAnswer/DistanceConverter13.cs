namespace CO453_ConsoleAppAnswer
{
    using System;

    /// <summary>
    /// This class offers three methods for converting
    /// between distances.  It can prompt the user to
    /// 
    /// 1.  Enter the number of miles, and then calculates 
    /// and outputs the number feet.
    /// 
    /// 2.  Enter the number of miles, and then calculates 
    /// and outputs the number metres.
    /// 
    /// 3.  Enter the number of Kilometres and then calculates
    /// the number of miles
    /// </summary>
    /// <author>
    /// Derek Peacock version 1.3
    /// </author>
    public class DistanceConverter13
    {
        public const int FEET_IN_MILES = 5280;
        public const double METRES_IN_MILES = 1609.34;

        // Distance Units
        private double miles;
        private double feet;
        private double metres;

        /// <summary>
        /// Calculate how many feet there are in the given miles
        /// </summary>
        public void ConvertMilesToFeet()
        {
            OutputHeading();
            Console.WriteLine("  Converting miles to feet");
            Console.WriteLine();

            InputMiles();

            feet = miles * FEET_IN_MILES;

            OutputFeet();
        }

        /// <summary>
        /// Calculate how many metres there are in the given miles
        /// </summary>
        public void ConvertMilesToMetres()
        {
            OutputHeading();
            Console.WriteLine("  Converting miles to metres");
            Console.WriteLine();

            InputMiles();

            metres = miles * METRES_IN_MILES;

            OutputMetres();
        }


        /// <summary>
        /// Calculate how many Miles there are in the given Feet
        /// </summary>
        public void ConvertFeetToMiles()
        {
            OutputHeading();
            Console.WriteLine("  Converting feet to miles");
            Console.WriteLine();

            InputFeet();

            miles = feet / FEET_IN_MILES;

            OutputMiles();
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
        /// Prompt the user to input the number of feet
        /// </summary>
        private void InputFeet()
        {
            Console.Write("  Enter the number of feet >");
            string value = Console.ReadLine();
            feet = Convert.ToDouble(value);
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

        /// <summary>
        /// Output how many miles there are in the given feet
        /// </summary>
        private void OutputMiles()
        {
            Console.WriteLine();
            Console.WriteLine("  " + feet + " feet is " + miles + " miles!");
            Console.WriteLine();
        }

        /// <summary>
        /// Output how many metres there are in the given miles
        /// </summary>
        private void OutputMetres()
        {
            Console.WriteLine();
            Console.WriteLine("  " + miles + " miles is " + metres + " metres!");
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
