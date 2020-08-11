using System;

namespace CO453_ConsoleAppAnswer.App05v1
{
    /**
     * A graphical view of the simulation grid.
     * The view displays a colored rectangle for each location 
     * representing its contents. It uses a default background color.
     * Colors for each type of species can be defined using the
     * setColor method.
     * 
     * @author David J. Barnes and Michael Kölling
     * @version 2016.02.29
     */
    public class SimulatorView
    {
        private readonly Simulator simulator = new Simulator();

        private readonly FieldStats stats = new FieldStats();

        public void RunSimulator()
        {
            bool displayField = false;
            UserLib.OutputHeading("  Foxes and Rabbits Sumulation");

            int lastStep = (int)UserLib.InputNumber("Run the simulation how many times > ");
            Console.WriteLine();

            Console.Write("  Do you want to display the field (Y/N) >");
            string answer = Console.ReadLine();

            if (answer.ToLower() == "y")
                displayField = true;

            for(int step = 1; step <= lastStep; step++)
            {
                simulator.SimulateOneStep();
                
                if(displayField)
                    Console.WriteLine(simulator.Field.ToString());


                CountAnimals();
                string result = stats.GetPopulationDetails(simulator.Field);
                Console.WriteLine(result);
            }
        }

        public void CountAnimals()
        {
            stats.Reset();

            Field field = simulator.Field;
            for(int row = 0; row < field.Depth; row++)
            {
                for( int column = 0; column < field.Width; column++)
                {
                    Object animal = field.GetAnimalAt(row, column);
                    if(animal != null)
                    {
                        stats.IncrementCount(animal.GetType().Name);
                    }
                }
            }

            stats.CountFinished();
        }

        public bool IsViable()
        {
            return true;
        }
    }
}
