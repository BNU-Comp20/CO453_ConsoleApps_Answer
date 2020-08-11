using System;

namespace CO453_ConsoleAppAnswer
{

    /// <summary>
    /// This class offers the user a way of converting
    /// between distances measured in Miles, Metre or Feet
    /// The user can select any combination of from and
    /// to distance units.
    /// </summary>
    /// <author>
    /// Derek Peacock App01: Version 1.5
    /// </author>
    public class DistanceConverter15
    {
        // Distance conversion constants

        public const int FEET_IN_MILES = 5280;
        public const double METRES_IN_MILES = 1609.34;
        public const double FEET_IN_METRES = 3.28084;


        // Distance properties

        public double FromDistance { get; set; }
        public double ToDistance { get; set; }

        // Unit properties

        public DistanceUnit FromUnit { get; set; }
        public DistanceUnit ToUnit { get; set; }

        /// <summary>
        /// Output the heading and then prompt the user to select the 
        /// from and to distance units.  The entered distance is then 
        /// converted from one to the other distance units.
        /// </summary>
        public void ConvertDistance()
        {
            OutputHeading();

            FromUnit = SelectUnit(" Select distance unit to convert from > ");
            ToUnit = SelectUnit(" Select distance unit to conver to > ");

            Console.WriteLine($" Converting {FromUnit} to {ToUnit}");
            Console.WriteLine();

            FromDistance = InputDistance($"  Enter distance in {FromUnit} > ");

            PerformConversion();

            OutputDistance();
        }


        /// <summary>
        /// Convert the fromDistance to the toDistance based
        /// on which fromUnits and toUnits have been selected
        /// </summary>
        public void PerformConversion()
        {
            if ((FromUnit == DistanceUnit.Miles) && 
                (ToUnit == DistanceUnit.Feet))
            {
                ToDistance = FromDistance * FEET_IN_MILES;
            }
            else if ((FromUnit == DistanceUnit.Feet) && 
                     (ToUnit == DistanceUnit.Miles))
            {
                ToDistance = FromDistance / FEET_IN_MILES;
            }
            else if ((FromUnit == DistanceUnit.Miles) && 
                     (ToUnit == DistanceUnit.Metres))
            {
                ToDistance = FromDistance * METRES_IN_MILES;
            }
            else if ((FromUnit == DistanceUnit.Metres) && 
                     (ToUnit == DistanceUnit.Miles))
            {
                ToDistance = FromDistance / METRES_IN_MILES;
            }
            else if ((FromUnit == DistanceUnit.Feet) && 
                     (ToUnit == DistanceUnit.Metres))
            {
                ToDistance = FromDistance * FEET_IN_METRES;
            }
            else if ((FromUnit == DistanceUnit.Metres) && 
                     (ToUnit == DistanceUnit.Feet))
            {
                ToDistance = FromDistance / FEET_IN_METRES;
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
            Console.WriteLine($" {FromDistance} {FromUnit} is {ToDistance} {ToUnit} !");
            Console.WriteLine();
        }

        /// <summary>
        /// Output a Heading for the distance converter
        /// </summary>
        private void OutputHeading()
        {
            Console.WriteLine();
            Console.WriteLine(" -----------------------------");
            Console.WriteLine("        Convert Distances     ");
            Console.WriteLine("        by Derek Peacock      ");
            Console.WriteLine(" -----------------------------");
            Console.WriteLine();
        }

        /// <summary>
        /// Display a menu of distance units and then prompt the
        /// user to select one and return it.
        /// </summary>
        private DistanceUnit SelectUnit(string prompt)
        {
            string[] choices = { $" {DistanceUnit.Feet}", 
                                 $" {DistanceUnit.Metres}", 
                                 $" {DistanceUnit.Miles}"};

            Console.WriteLine(prompt);
            int choice = UserLib.SelectChoice(choices);

            DistanceUnit unit;

            if (choice == 1)
            {
                unit = DistanceUnit.Feet;
            }
            else if (choice == 2)
            {
                unit = DistanceUnit.Metres;
            }
            else if(choice == 3)
            {
                unit = DistanceUnit.Miles;
            }
            else unit = DistanceUnit.NoUnit;

            Console.WriteLine($" You have selected {unit}");
            Console.WriteLine();

            // Alternative to the if..else

            //switch (choice)
            //{
            //    case "1": unit = DistanceUnit.Feet; break;
            //    case "2": unit = DistanceUnit.Metres; break;
            //    case "3": unit = DistanceUnit.Miles; break;

            //    default: unit = "INVALID CHOICE"; break;
            //}

            return unit;
        }
    } // end class

}
