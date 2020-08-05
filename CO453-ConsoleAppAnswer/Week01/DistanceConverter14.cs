using System;

namespace CO453_ConsoleAppAnswer
{

    /// <summary>
    /// Choice of units used to measure distance
    /// </summary>
    public enum DistanceUnits
    {
        NoUnit,
        Feet,
        Metres,
        Kilometres,
        Miles
    }

    /// <summary>
    /// This class offers the user a way of converting
    /// between distances measured in Miles, Metre or Feet
    /// The user can select any combination of from and
    /// to distance units.
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
        /// Output the heading and then prompt the user to select the 
        /// from and to distance units.  The entered distance is then 
        /// converted from one to the other distance units.
        /// </summary>
        public void ConvertDistance()
        {
            OutputHeading();

            fromUnit = SelectUnit("  Select distance unit to convert from > ");
            toUnit = SelectUnit("  Select distance unit to conver to > ");

            Console.WriteLine($"  Converting {fromUnit} to {toUnit}");
            Console.WriteLine();

            fromDistance = InputDistance($"  Enter distance in {fromUnit} > ");

            PerformConversion();

            OutputDistance();
        }


        /// <summary>
        /// Convert the fromDistance to the toDistance based
        /// on which fromUnits and toUnits have been selected
        /// </summary>
        private void PerformConversion()
        {
            if ((fromUnit == MILES) && (toUnit == FEET))
            {
                toDistance = fromDistance * FEET_IN_MILES;
            }
            else if ((fromUnit == FEET) && (toUnit == MILES))
            {
                toDistance = fromDistance / FEET_IN_MILES;
            }
            else if ((fromUnit == MILES) && (toUnit == METRES))
            {
                toDistance = fromDistance * METRES_IN_MILES;
            }
            else if ((fromUnit == METRES) && (toUnit == MILES))
            {
                toDistance = fromDistance / METRES_IN_MILES;
            }
            else if ((fromUnit == FEET) && (toUnit == METRES))
            {
                toDistance = fromDistance * FEET_IN_METRES;
            }
            else if ((fromUnit == METRES) && (toUnit == FEET))
            {
                toDistance = fromDistance / FEET_IN_METRES;
            }
        }

        /// <summary>
        /// Display the prompt and ask the user to input a 
        /// distance as a double number
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

        /// <summary>
        /// Display a menu of distance units and then prompt the
        /// user to select one and return it.
        /// </summary>
        private string SelectUnit(string prompt)
        {
            Console.WriteLine();
            Console.WriteLine($" 1. {FEET}");
            Console.WriteLine($" 2. {METRES}");
            Console.WriteLine($" 3. {MILES}");
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

            // Alternative to the if..else

            //switch (choice)
            //{
            //    case "1": unit = FEET; break;
            //    case "2": unit = METRES; break;
            //    case "3": unit = MILES; break;

            //    default: unit = "INVALID CHOICE"; break;
            //}

            return unit;
        }
    } // end class
}
