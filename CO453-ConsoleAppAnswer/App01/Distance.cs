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

        public const int MAXN_PEOPLE = 10;

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
            DoSomething();
        }

        private void InputMiles()
        {
            Console.Write("Enter the number of miles >");
            string value = Console.ReadLine();
            miles = Convert.ToDouble(value);
        }

        public void DoSomething()
        {
            //bool carryOn = false;

            //int x = 0;

            //do
            //{
            //    // Do Something
            //    x++;
            //}
            //while (x <= 10);


            //while (x < 10)
            //{
            //    // do something

            //    x++;
            //}

            for(int count = 0; count < MAXN_PEOPLE; count++)
            {
                Console.WriteLine($" Count = {count}");
            }

        }
    }
}
