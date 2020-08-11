using CO453_ConsoleAppAnswer.App02;
using CO453_ConsoleAppAnswer.App03;
using CO453_ConsoleAppAnswer.App05v1;

namespace CO453_ConsoleAppAnswer
{

    /// <summary>
    /// This class runs first and create a DistanceConverter
    /// allowing the user three ways of converting distances
    /// </summary>
    /// <author>
    /// Derek Peacock
    /// </author>
    public static class Program
    {
        public static NetworkUI Network { get; set; }

        public static void Main()
        {
            UserLib.OutputHeading(" C# Console Applications 2020");

            string [] choices = { 
                "App01: Distance Converter", "App02: BMI Calculator",
                "App03: Student Grades",     "App04: Network", 
                "App05: Simulator",          "Quit" };

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
            else if (choiceNo == 3)
            {
                StudentGrades app = new StudentGrades();
                app.OutputMenu();
            }
            else if (choiceNo == 4)
            {
                NetworkUI network = new NetworkUI();
                network.DisplayMenu();
            }
            else if (choiceNo == 5)
            {
                SimulatorView view = new SimulatorView();

                view.RunSimulator();
            }
        }
    }
}
