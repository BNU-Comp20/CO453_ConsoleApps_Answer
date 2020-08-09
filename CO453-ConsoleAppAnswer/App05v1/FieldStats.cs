using System;
using System.Collections.Generic;
using System.Text;

namespace CO453_ConsoleAppAnswer.App05v1
{
    /**
     * This class collects and provides some statistical data on the state 
     * of a field. It is flexible: it will create and maintain a counter 
     * for any class of object that is found within the field.
     * 
     * @author David J. Barnes and Michael Kölling
     * @version 2016.02.29
     */
    public class FieldStats
    {
        // Counters for each type of entity (fox, rabbit, etc.) in the simulation.
        private readonly Dictionary<string, Counter> counters;

        // Whether the counters are currently up to date.
        private bool countsValid;

        /**
         * Construct a FieldStats object.
         */
        public FieldStats()
        {
            // Set up a collection for counters for each type of animal that
            // we might find
            counters = new Dictionary<string, Counter>();
            countsValid = true;
        }

        /**
         * Get details of what is in the field.
         * @return A string describing what is in the field.
         */
        public String GetPopulationDetails(Field field)
        {
            StringBuilder buffer = new StringBuilder();
            if (!countsValid)
            {
                GenerateCounts(field);
            }

            foreach (string key in counters.Keys)
            {
                Counter info = counters.GetValueOrDefault(key);

                buffer.Append(info.Name);
                buffer.Append(": ");
                buffer.Append(info.Count);
                buffer.Append(' ');
            }
            return buffer.ToString();
        }

        /**
         * Invalidate the current set of statistics; reset all 
         * counts to zero.
         */
        public void Reset()
        {
            countsValid = false;
            foreach (string key in counters.Keys)
            {
                Counter count = counters.GetValueOrDefault(key);
                count.Reset();
            }
        }

        /**
         * Increment the count for one class of animal.
         * @param animalClass The class of animal to increment.
         */
        public void IncrementCount(string animalClass)
        {
            Counter count = counters.GetValueOrDefault(animalClass);
            if (count == null)
            {
                // We do not have a counter for this species yet.
                // Create one.
                count = new Counter(animalClass);
                counters.Add(animalClass, count);
            }
            count.Increment();
        }

        /**
         * Indicate that an animal count has been completed.
         */
        public void CountFinished()
        {
            countsValid = true;
        }

        /**
         * Determine whether the simulation is still viable.
         * I.e., should it continue to run.
         * @return true If there is more than one species alive.
         */
        public bool IsViable(Field field)
        {
            // How many counts are non-zero.
            int nonZero = 0;
            
            if (!countsValid)
            {
                GenerateCounts(field);
            }

            foreach(string key in counters.Keys)
            {
                Counter info = counters.GetValueOrDefault(key);
                if (info.Count > 0)
                {
                    nonZero++;
                }
            }

            return nonZero > 1;
        }

        /**
         * Generate counts of the number of foxes and rabbits.
         * These are not kept up to date as foxes and rabbits
         * are placed in the field, but only when a request
         * is made for the information.
         * @param field The field to generate the stats for.
         */
        private void GenerateCounts(Field field)
        {
            Reset();
            for (int row = 0; row < field.Depth; row++)
            {
                for (int col = 0; col < field.Width; col++)
                {
                    Object animal = field.GetObjectAt(row, col);
                    if (animal != null)
                    {
                        IncrementCount(animal.GetType().ToString());
                    }
                }
            }
            countsValid = true;
        }

    }
}
