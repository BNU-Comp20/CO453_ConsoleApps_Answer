using System;

namespace CO453_ConsoleAppAnswer.App02
{
    public class ggBMI
    {
        //<summary>
        //This gets the user's weight and height and converts it to a double.
        //summary>
        public static void Calculator()
        {
            Console.Write("Enter your weight (kg): ");
            double kg = Convert.ToDouble(Console.ReadLine());
            Console.Write("Enter your height (metres): ");
            double metres = Convert.ToDouble(Console.ReadLine());

            ///<summary>
            /// This method will use the formula to calculate BMI and desplay it 
            /// to 2 decimal places.
            /// </summary>
            double BMI = kg / (metres * metres);
            Console.WriteLine("Your BMI is: " + Math.Round(BMI, 2));

            ///<summary
            ///Then we check in which categorie of wight the user suits and 
            ///display the result.
            ///</summary>
            if (BMI <= 17)
            {
                Console.WriteLine(" You are severely underweight");
            }
            else if (BMI <= 18.5)
            {
                Console.WriteLine("You are underweight");
            }
            else if (BMI <= 25)
            {
                Console.WriteLine(" You are a normal weight");
            }
            else if (BMI <= 30)
            {
                Console.WriteLine(" You are overweight");
            }
            else if (BMI <= 40)
            {
                Console.WriteLine("You are obese");
            }
            else
            {
                Console.WriteLine(" You are severely obese");
            }
        }
    }
}
