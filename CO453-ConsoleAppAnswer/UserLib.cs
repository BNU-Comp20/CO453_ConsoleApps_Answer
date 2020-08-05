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
            string errorMessage = $"\n INVALID CHOICE: must be 1 to {lastChoice} !";

            do
            {
                DisplayChoices(choices);

                choiceNo = (int)InputNumber(" Please enter your choice > ");

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
        private static void DisplayChoices(string[] choices)
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
        /// Prompt the user to enter a valid number  
        /// which is returned
        /// </summary>
        public static double InputNumber(string prompt)
        {
            double number = 0;
            bool Isvalid;

            do
            {
                Console.Write(prompt);
                string value = Console.ReadLine();

                try
                {
                    number = Convert.ToDouble(value);
                    Isvalid = true;
                }
                catch (Exception)
                {
                    Isvalid = false;
                    Console.WriteLine(" INVALID NUMBER!");
                }

            } while (!Isvalid);

            return number;
        }

        /// <summary>
        /// 
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
