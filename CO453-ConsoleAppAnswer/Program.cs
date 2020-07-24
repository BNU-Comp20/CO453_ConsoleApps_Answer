namespace CO453_ConsoleAppAnswer
{
    using System;
    /// <summary>
    /// This class runs first and create a DistanceConverter
    /// allowing the user three ways of converting distances
    /// </summary>
    /// <author>
    /// Derek Peacock
    /// </author>
    public static class Program
    {
        public static void Main()
        {
            UserLib.OutputHeading(" C# Console Applications 2020");

            string [] choices = { "Distance Converter", "BMI Calculator", "Quit" };
            int choiceNo = UserLib.SelectChoice(choices);

            if (choiceNo == 1)
            {
                DistanceConverter15 converter = new DistanceConverter15();
                converter.ConvertDistance();
            }
            else if (choiceNo == 2)
            {
                BMI bmi = new BMI();
                bmi.CalculateIndex();
            }
            
            
            //converter.ConvertFeetToMiles();
            //converter.ConvertMilesToMetres();

            //LengthConverter converter2 = new LengthConverter();

            //converter2.OutputFactors();
            //converter2.Execute();

            //converter.CalculateFeet();
            //converter.DoSomething();
            //converter.CalculateMiles();
        }
    }
}
