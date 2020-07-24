using System;
using System.ComponentModel.DataAnnotations;

namespace CO453_ConsoleAppAnswer
{
    public static class UserLib
    {
        /// <summary>
        /// This method outputs a heading showing the title
        /// of the application or method and the author
        /// </summary>
        public static void OutputHeading(string title)
        {
            Console.WriteLine();
            Console.WriteLine(" ------------------------------");
            Console.WriteLine($"  {title}");
            Console.WriteLine("        by Derek Peacock      ");
            Console.WriteLine(" ------------------------------");
            Console.WriteLine("");
        }

        /// <summary>
        /// This method will display a list of numbered choices
        /// and will ask the user to select one and return it
        /// </summary>
        public static int SelectChoice(string [] choices)
        {
            int choiceNo;
            int lastChoice = choices.Length;

            bool validChoice;
            string errorMessage = $"\n INVALID CHOICE: must be 1 to {lastChoice} !";

            do
            {
                DisplayChoices(choices);

                choiceNo = InputNumber(" Please enter your choice > ");

                if ((choiceNo < 1) || (choiceNo > lastChoice))
                {
                    validChoice = false;
                    Console.WriteLine(errorMessage);
                }
                else validChoice = true;

            } while (!validChoice);

            return choiceNo;
        }

        /// <summary>
        /// Display a list of choices as a numbered list
        /// </summary>
        private static void DisplayChoices(string [] choices)
        {
            Console.WriteLine();

            int count = 0;
            foreach (string choice in choices)
            {
                count++;
                Console.WriteLine($" {count}. {choice}");
            }

            Console.WriteLine();
        }

        /// <summary>
        /// Prompt the user to enter a valid integer value 
        /// which is returned
        /// </summary>
        private static int InputNumber(string prompt)
        {
            int number = 0;
            bool validInt;

            do
            {
                Console.Write(prompt);
                string value = Console.ReadLine();

                try
                {
                    number = Convert.ToInt16(value);
                    validInt = true;
                }
                catch (Exception)
                {
                    validInt = false;
                    Console.WriteLine(" INVALID INTEGER");
                }

            } while (!validInt);

            return number;
        }
    }
}
