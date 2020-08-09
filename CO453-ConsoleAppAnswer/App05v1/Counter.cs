using System;

namespace CO453_ConsoleAppAnswer.App05v1
{
    /**
     * Provide a counter for a participant in the simulation.
     * This includes an identifying string and a count of how
     * many participants of this type currently exist within 
     * the simulation.
     * 
     * @author David J. Barnes and Michael Kölling
     * @version 2016.02.29
     */
    public class Counter
    {
        // A name for this type of simulation participant
        public String Name { get; }
        // How many of this type exist in the simulation.
        public int Count { get; set; }

        /**
         * Provide a name for one of the simulation types.
         * @param name  A name, e.g. "Fox".
         */
        public Counter(String name)
        {
            Name = name;
            Count = 0;
        }


        /**
         * Increment the current count by one.
         */
        public void Increment()
        {
            Count++;
        }

        /**
         * Reset the current count to zero.
         */
        public void Reset()
        {
            Count = 0;
        }

    }
}
