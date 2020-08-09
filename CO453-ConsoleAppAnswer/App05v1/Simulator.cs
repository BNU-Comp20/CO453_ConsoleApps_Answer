using System;
using System.Collections.Generic;
using System.Threading;

namespace CO453_ConsoleAppAnswer.App05v1
{
    /**
     * A simple predator-prey simulator, based on a rectangular field containing 
     * rabbits and foxes.
     * 
     * @author David J. Barnes and Michael Kölling
     * @version 2016.02.29
     */
    public class Simulator
    {
        // Constants representing configuration information for the simulation.
        // The default width for the grid.
        private const int DEFAULT_WIDTH = 120;
        // The default depth of the grid.
        private const int DEFAULT_DEPTH = 80;
        
        // The probability that a fox will be created in any given grid position.
        private const double FOX_CREATION_PROBABILITY = 0.02;
        // The probability that a rabbit will be created in any given position.
        private const double RABBIT_CREATION_PROBABILITY = 0.08;

        // Lists of animals in the field.
        private readonly List<Rabbit> rabbits;
        private readonly List<Fox> foxes;
        
        // The current state of the field.
        private readonly Field field;
        
        // The current step of the simulation.
        private int step;
        
        // A graphical view of the simulation.
        //private SimulatorView view;

        /**
         * Construct a simulation field with default size.
         */
        public Simulator() :     
            this(DEFAULT_DEPTH, DEFAULT_WIDTH)
        { 
        }

        /**
         * Create a simulation field with the given size.
         * @param depth Depth of the field. Must be greater than zero.
         * @param width Width of the field. Must be greater than zero.
         */
        public Simulator(int depth, int width)
        {
            if (width <= 0 || depth <= 0)
            {
                Console.WriteLine("The dimensions must be >= zero.");
                Console.WriteLine("Using default values.");

                depth = DEFAULT_DEPTH;
                width = DEFAULT_WIDTH;
            }

            rabbits = new List<Rabbit>();
            foxes = new List<Fox>();
            field = new Field(depth, width);

            // Create a view of the state of each location in the field.
            //view = new SimulatorView(depth, width);
            //view.setColor(Rabbit.class, Color.ORANGE);
            //view.setColor(Fox.class, Color.BLUE);

            // Setup a valid starting point.
            Reset();
        }

        /**
         * Run the simulation from its current state for a reasonably long 
         * period (4000 steps).
         */
        public void RunLongSimulation()
        {
            Simulate(4000);
        }

        /**
         * Run the simulation for the given number of steps.
         * Stop before the given number of steps if it ceases to be viable.
         * @param numSteps The number of steps to run for.
         */
        public void Simulate(int numSteps)
        {
            for (int i = 1; step <= numSteps; i++)
            {
                SimulateOneStep();
                // delay(60);   // uncomment this to run more slowly
            }
        }

        /**
         * Run the simulation from its current state for a single step. Iterate
         * over the whole field updating the state of each fox and rabbit.
         */
        public void SimulateOneStep()
        {
            step++;

            // Provide space for newborn rabbits.
            List<Rabbit> newRabbits = new List<Rabbit>();

            // Let all rabbits act.
            foreach (Rabbit rabbit in rabbits)
            {
                rabbit.Run(newRabbits);
                if (!rabbit.IsAlive())
                {
                    rabbits.Remove(rabbit);
                }
            }

            // Provide space for newborn foxes.
            List<Fox> newFoxes = new List<Fox>();

            // Let all foxes act.
            foreach (Fox fox in foxes)
            {
                fox.Hunt(newFoxes);
                if (!fox.IsAlive())
                {
                    foxes.Remove(fox);
                }
            }

            // Add the newly born foxes and rabbits to the main lists.
            rabbits.AddRange(newRabbits);
            foxes.AddRange(newFoxes);

            //view.ShowStatus(step, field);
        }

        /**
         * Reset the simulation to a starting position.
         */
        public void Reset()
        {
            step = 0;

            rabbits.Clear();
            foxes.Clear();
            Populate();

            // Show the starting state in the view.
            //view.ShowStatus(step, field);
        }

        /**
         * Randomly populate the field with foxes and rabbits.
         */
        private void Populate()
        {
            Random rand = Randomizer.GetRandom();
            field.Clear();
            for (int row = 0; row < field.Depth; row++)
            {
                for (int col = 0; col < field.Width; col++)
                {
                    if (rand.NextDouble() <= FOX_CREATION_PROBABILITY)
                    {
                        Location location = new Location(row, col);
                        Fox fox = new Fox(true, field, location);
                        foxes.Add(fox);
                    }
                    else if (rand.NextDouble() <= RABBIT_CREATION_PROBABILITY)
                    {
                        Location location = new Location(row, col);
                        Rabbit rabbit = new Rabbit(true, field, location);
                        rabbits.Add(rabbit);
                    }
                    // else leave the location empty.
                }
            }
        }

        /**
         * Pause for a given time.
         * @param millisec  The time to pause for, in milliseconds
         */
        private void Delay(int millisec)
        {
            try
            {
                Thread.Sleep(millisec);
            }
            catch (ThreadInterruptedException ie)
            {
                // wake up
            }
        }
    }
}

