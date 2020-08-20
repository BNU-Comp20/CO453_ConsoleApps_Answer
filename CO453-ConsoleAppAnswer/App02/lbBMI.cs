using System;
using System.Collections.Generic;
using System.Text;

namespace CO453_ConsoleAppAnswer.App02
{
    public class lbBMI
    {
        double bmi, weight, height;

        /// <summary>
        /// This method asks the user to input their height and weight
        /// </summary>
        public void GetDetails()
        {
            string input;

            Console.WriteLine("Please enter your weight in kg:");
            input = Console.ReadLine();
            weight = Convert.ToDouble(input);

            Console.WriteLine("Please enter your height in metres:");
            input = Console.ReadLine();
            height = Convert.ToDouble(input);
        }

        /// <summary>
        /// This method then calculates the BMI of the user based on what they input
        /// </summary>
        public void CalcBMI()
        {
            bmi = weight / (height * height);
        }

        /// <summary>
        /// This method then displays a message based on your BMI
        /// </summary>
        public void DisplayBMI()
        {
            Console.WriteLine("Your BMI is " + bmi);

            if (bmi < 18.5)
            {
                Console.WriteLine("Your BMI was less than 18.5 which means you are underweight");
            }
            else if (bmi > 18.5 && bmi <= 25)
            {
                Console.WriteLine("Your BMI was greater than 18.5 and less than 25 which means you are of desirable weight for size");
            }
            else if (bmi > 25 && bmi <= 30)
            {
                Console.WriteLine("Your BMI was greater than 25 and less than 30 which means you are overweight");
            }
            else if (bmi > 30 && bmi <= 40)
            {
                Console.WriteLine("Your BMI was greater than 30 but less than 40 which means you are obese");
            }
            else if (bmi > 40)
            {
                Console.WriteLine("Your BMI was greater than 40 which means you are severely obese");
            }
        }
    }
}
