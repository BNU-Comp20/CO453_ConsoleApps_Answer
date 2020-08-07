using System;
using System.Collections.Generic;
using System.Text;

namespace CO453_ConsoleAppAnswer
{
    public static class UserLib01
    {
        public static int SelectChoice(string [] choices)
        {
            DisplayChoices(choices);

            // Input the users choice as a number

            int choiceNo = (int) InputNumber(
                "\n Please enter your choice number > ");

            return choiceNo;
        }

        public static double InputNumber(string prompt)
        {
            Console.Write(prompt);
            string value = Console.ReadLine();
            return Convert.ToDouble(value);
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
    }
}
