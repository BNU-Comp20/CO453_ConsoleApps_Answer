

using System;

namespace CO453_ConsoleAppAnswer
{
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
    /// Derek Peacock version 1.4
    /// </author>
    class DistanceConverter14
    {
        // Distance conversion constants

        public const int FEET_IN_MILES = 5280;
        public const double METRES_IN_MILES = 1609.34;
        public const double FEET_IN_METRES = 3.28084;

        // Distance Unit Names

        public const string FEET = "Feet";
        public const string MILES = "Miles";
        public const string METRES = "Metres";

        // Distance variables

        private double fromDistance;
        private double toDistance;

        // Unit variables

        private string fromUnit;
        private string toUnit;


        /// <summary>
        /// Calculate how many feet there are in the given miles
        /// </summary>
        public void ConvertDistance()
        {
            OutputHeading();

            fromUnit = SelectUnit("  Select distance unit to convert from > ");
            toUnit = SelectUnit("  Select distance unit to conver to > ");

            Console.WriteLine($"  Converting {fromUnit} to {toUnit}");
            Console.WriteLine();

            fromDistance = InputDistance($"  Enter distance in {fromUnit} > ");

            if((fromUnit == MILES) && (toUnit == FEET))
            {
                toDistance = fromDistance * FEET_IN_MILES;
            }
            else if ((fromUnit == FEET) && (toUnit == MILES))
            {
                toDistance = fromDistance / FEET_IN_MILES;
            }

            OutputDistance();
        }

        private void InputFeet()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Prompt the user to input a distance as a double number
        /// </summary>
        private double InputDistance(string prompt)
        {
            Console.Write(prompt);
            string value = Console.ReadLine();
            return Convert.ToDouble(value);
        }

        /// <summary>
        /// Output the distance and units converted from and the distance
        /// and units converted to
        /// </summary>
        private void OutputDistance()
        {
            Console.WriteLine();
            Console.WriteLine($"  {fromDistance} {fromUnit} is {toDistance} {toUnit} !");
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
            Console.WriteLine(" 3. Miles");
            Console.WriteLine();

            Console.Write(prompt);
            string choice = Console.ReadLine();

            string unit = "INVALID CHOICE";

            if (choice == "1")
            {
                unit = FEET;
            }
            else if (choice == "2")
            {
                unit = METRES;
            }
            else if (choice == "3")
            {
                unit = MILES;
            }

            Console.WriteLine($"  You have selected {unit}");
            Console.WriteLine();

            switch (choice)
            {
                case "1": unit = FEET; break;
                case "2": unit = METRES; break;
                case "3": unit = MILES; break;

                default: unit = "INVALID CHOICE"; break;
            }

            //if (unit == DistanceUnit.NoUnit)
            //{
            //    Console.WriteLine("Invalid Choice!");
            //    Console.WriteLine("Must be a digit 1 to 4");
            //}

            return unit;
        }

    }
}
