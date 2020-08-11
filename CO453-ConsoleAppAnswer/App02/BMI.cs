using System;

namespace CO453_ConsoleAppAnswer.App02
{
    /// <summary>
    /// Two systems of measuring weight and height
    /// </summary>
    public enum UnitSystem
    {
        Metric,
        Imperial
    }

    /// <summary>
    /// This class contains methods for calculating 
    /// the user's BMI (Body Mass Index) using 
    /// imperial or metric units.
    /// </summary>
    /// <Author>
    /// Derek Peacock App02: Version 1.0
    /// </Author>
    public class BMI
    {
        public const double Underweight = 18.5;
        public const double NormalRange = 24.9;
        public const double Overweight = 29.9;

        public const double Obese1 = 34.9;
        public const double Obese2 = 39.9;
        public const double Obese3 = 40.0;

        public const int InchesInFeet = 12;
        public const int PoundsInStones = 14;

        private double index;

        // Metric Details
        
        private double kilograms;
        private double metres;

        // Imperial Details
        
        private double pounds;
        private int inches;

        ///<summary>
        /// Prompt the user to select Imperial or Metric
        /// units.  Input the user's height and weight and
        /// then calculate their BMI value.  Output which
        /// weight category they fall into.
        ///</summary>
        public void CalculateIndex()
        {
            UserLib.OutputHeading("\tBMI Calculator");

            UnitSystem unitSystem = SelectUnits();

            if(unitSystem == UnitSystem.Metric)
            {
                InputMetricDetails();
                index = kilograms / (metres * metres);
            }
            else
            {
                InputImperialDetails();
                index = pounds * 703 / (inches * inches);
            }

            OutputHealthMessage();

        }

        /// <summary>
        /// Output the users BMI and their weight
        /// category from underweight to obese.
        /// </summary>
        private void OutputHealthMessage()
        {
            if(index < Underweight )
            {
                Console.WriteLine($" Your BMI is {index}, " +
                    $"You are underweight! ");
            }
            else if(index <= NormalRange)
            {
                Console.WriteLine($" Your BMI is {index}, " +
                    $"You are in the normal range! ");

            }
            else if (index <= Overweight)
            {
                Console.WriteLine($" Your BMI is {index}, " +
                    $"You are overweight! ");

            }
            else if (index <= Obese1)
            {
                Console.WriteLine($" Your BMI is {index}, " +
                    $"You are obese class I ");

            }
            else if (index <= Obese2)
            {
                Console.WriteLine($" Your BMI is {index}, " +
                    $"You are obese class II ");

            }
            else if (index <= Obese3)
            {
                Console.WriteLine($" Your BMI is {index}, " +
                    $"You are obese class III ");

            }

            OutputBameMessage();
        }

        /// <summary>
        /// Output a message for BAME users who are
        /// at higher risk
        /// </summary>
        private void OutputBameMessage()
        {
            Console.WriteLine();
            Console.WriteLine(
                " If you are Black, Asian or other minority");
            Console.WriteLine(
                " ethnic groups, you have a higher risk");
            Console.WriteLine();
            Console.WriteLine(
                "\t Adults 23.0 or more are at increased risk");
            Console.WriteLine(
                "\t Adults 27.5 or more are at high risk");
            Console.WriteLine();
        }

        /// <summary>
        /// Input the users height in feet and inches and
        /// their weight in stones and pounds
        /// </summary>
        private void InputImperialDetails()
        {
            Console.WriteLine(
                " Enter your height in feet and inches ");
            double feet = UserLib.InputNumber(
                "\n Enter your height in feet > ");
            inches = (int) UserLib.InputNumber(
                " Enter your height in inches > ");

            inches += (int) feet * InchesInFeet;

            Console.WriteLine(
                " Enter your weight in stones and pounds");
            double stones = UserLib.InputNumber(
                " Enter your weight in stones > ");
            pounds = UserLib.InputNumber(
                " Enter your weight in pounds > ");

            pounds += stones * PoundsInStones;
        }

        /// <summary>
        /// Input the users height in metres and
        /// their weight in kilograms
        /// </summary>
        private void InputMetricDetails()
        {
            metres = UserLib.InputNumber(
                " \n Enter your height in metres > ");

            kilograms = UserLib.InputNumber(
                " Enter your weight in kilograms > ");
        }

        private UnitSystem SelectUnits()
        {
            string[] choices = new[]
            {
                "Metric Units",
                "Imperial Units"
            };

            int choice = UserLib.SelectChoice(choices);
            
            if (choice == 1)
            {
                return UnitSystem.Metric;
            }
            else return UnitSystem.Imperial;
        }
    }
}
