using System;


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
        public static int SelectChoice(string[] choices)
        {
            int choiceNo;
            int lastChoice = choices.Length;
            bool validChoice;

            string errorMessage = 
                $"\n INVALID CHOICE: must be 1 to {lastChoice} !";

            do
            {
                DisplayChoices(choices);

                choiceNo = (int)InputNumber(
                    " Please enter your choice > ", 1, lastChoice);

                if ((choiceNo < 1) || (choiceNo > lastChoice))
                {
                    validChoice = false;
                    Console.WriteLine(errorMessage);
                }
                else validChoice = true;

            } while (!validChoice);

            Console.WriteLine();

            return choiceNo;
        }

        /// <summary>
        /// Display a list of choices as a numbered list
        /// </summary>
        public static void DisplayChoices(string[] choices)
        {
            Console.WriteLine();

            int choiceNo = 0;

            foreach (string choice in choices)
            {
                choiceNo++;
                Console.WriteLine($" {choiceNo}. {choice}");
            }

            Console.WriteLine();
        }

        /// <summary>
        /// Prompt the user to enter a valid number  
        /// which is returned
        /// </summary>
        public static double InputNumber(string prompt)
        {
            double number = 0;
            bool isValid;

            do
            {
                Console.Write(prompt);
                string value = Console.ReadLine();

                try
                {
                    number = Convert.ToDouble(value);
                    isValid = true;
                }
                catch (Exception)
                {
                    isValid = false;
                    Console.WriteLine(" INVALID NUMBER!\n");
                }

            } while (!isValid);

            return number;
        }

        /// <summary>
        /// Repeated prompt the user to enter a number and only
        /// return a value between min and max inclusive
        /// </summary>
        public static double InputNumber(string prompt, double min, double max)
        {
            bool isValid;
            double number;

            do
            {
                number = InputNumber(prompt);

                if (number < min || number > max)
                {
                    isValid = false;
                    Console.WriteLine($"Number must be between {min} and {max} ");
                }
                else isValid = true;

            } while (!isValid);

            return number; 
        }
    }
}
