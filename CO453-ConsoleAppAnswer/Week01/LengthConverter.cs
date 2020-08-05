namespace CO453_ConsoleAppAnswer
{
    using System;

    /// <summary>
    /// This class offers methods for prompting the user
    /// select the from length unit and the to length unit.
    /// The user then inputs the number of from units, and then 
    /// calculates and outputs the equivalent number of to units
    /// </summary>
    /// <author>
    /// Derek Peacock
    /// </author>
    public class LengthConverter
    {
        public const int NUMBER_OF_UNITS = 4;

        private int fromUnit;
        private int toUnit;

        private double fromNumber;
        private double toNumber;

        private readonly string[] units = new string[]
        {
            "Feet",
            "Meters",
            "Kilometers",
            "Miles"
        };

        private readonly double[,] conversionFactors = new double[NUMBER_OF_UNITS, NUMBER_OF_UNITS]
        {
          {1.0,     0.3048,  0.0003048, 0.000189394},
          {3.28084, 1.0,     0.001,     0.000621371},
          {3280.84, 1000,    1.0,       0.621371},
          {5280,    1609.34, 1.60934,   1.0}
        };

        /// <summary>
        /// Prompt the user to enter a double number and return it
        /// </summary>
        private double InputNumber(string prompt)
        {
            Console.WriteLine();
            Console.Write(prompt);

            string value = Console.ReadLine();
            return Convert.ToDouble(value);
        }

        /// <summary>
        /// Display all the conversion factors between the
        /// different length units
        /// </summary>
        public void OutputFactors()
        {
            for (int i = 0; i < NUMBER_OF_UNITS; i++)
            {
                for (int j = 0; j < NUMBER_OF_UNITS; j++)
                {
                    Console.Write(" From " + units[i]);
                    Console.Write(" to " + units[j]);
                    Console.WriteLine(" Factor = " + conversionFactors[i, j]);
                }
                Console.WriteLine();
            }
        }

        /// <summary>
        /// Output a Heading for the length converter
        /// </summary>
        private void OutputHeading()
        {
            Console.WriteLine();
            Console.WriteLine("  -----------------------------");
            Console.WriteLine("         Convert Lengths     ");
            Console.WriteLine("         by Derek Peacock      ");
            Console.WriteLine("  -----------------------------");
            Console.WriteLine();
        }

        /// <summary>
        /// Output the length converted from one unit to another
        /// </summary>
        private void OutputResult()
        {
            Console.WriteLine();
            Console.WriteLine($" {fromNumber} {units[fromUnit]} is {toNumber } {units[toUnit]}");
            Console.WriteLine();
        }

        /// <summary>
        /// Prompt the user to select the unit they wish to conver from
        /// and the unit they wish to conver to follwed by the length.
        /// The resulting length is output.
        /// </summary>
        public void Execute()
        {
            OutputHeading();

            fromUnit = SelectUnitNo();
            toUnit = SelectUnitNo();

            fromNumber = InputNumber(" Enter the number of "
                + units[fromUnit] + " > ");

            toNumber = fromNumber * conversionFactors[fromUnit, toUnit];

            OutputResult();
        }

        /// <summary>
        /// Select a unit number from the list of available units
        /// </summary>
        private int SelectUnitNo()
        {
            Console.WriteLine();
            Console.WriteLine(" Please select unit");
            Console.WriteLine();

            for (int i = 0; i < NUMBER_OF_UNITS; i++)
            {
                Console.WriteLine($"{i + 1}. {units[i]}");
            }

            int choice = (int)InputNumber(" Enter choice no > ");
            return choice - 1;
        }
    }
}
