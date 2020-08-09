using System;
using System.Collections.Generic;

namespace CO453_ConsoleAppAnswer.App05v1
{
    /**
     * A simple model of a rabbit.
     * Rabbits age, move, breed, and die.
     * 
     * @author David J. Barnes and Michael Kölling
     * @version 2016.02.29
     */
    public class Rabbit
    {
        // Characteristics shared by all rabbits (class variables).

        // The age at which a rabbit can start to breed.
        private const int BREEDING_AGE = 5;
        // The age to which a rabbit can live.
        private const int MAX_AGE = 40;
        // The likelihood of a rabbit breeding.
        private const double BREEDING_PROBABILITY = 0.12;
        // The maximum number of births.
        private const int MAX_LITTER_SIZE = 4;
        // A shared random number generator to control breeding.
        private static readonly Random rand = Randomizer.GetRandom();
    
        // Individual characteristics (instance fields).
    
        // The rabbit's age.
        private int age;
        // Whether the rabbit is alive or not.
        private bool alive;
        // The rabbit's position.
        private Location location;
        // The field occupied.
        private Field field;

        /**
         * Create a new rabbit. A rabbit may be created with age
         * zero (a new born) or with a random age.
         * 
         * @param randomAge If true, the rabbit will have a random age.
         * @param field The field currently occupied.
         * @param location The location within the field.
         */
        public Rabbit(bool randomAge, Field field, Location location)
        {
            age = 0;
            alive = true;
            this.field = field;
            SetLocation(location);
            if (randomAge)
            {
                age = rand.Next(MAX_AGE);
            }
        }

        /**
         * This is what the rabbit does most of the time - it runs 
         * around. Sometimes it will breed or die of old age.
         * @param newRabbits A list to return newly born rabbits.
         */
        public void Run(List<Rabbit> newRabbits)
        {
            IncrementAge();
            if (alive)
            {
                GiveBirth(newRabbits);
                // Try to move into a free location.
                Location newLocation = field.FreeAdjacentLocation(location);
                if (newLocation != null)
                {
                    SetLocation(newLocation);
                }
                else
                {
                    // Overcrowding.
                    SetDead();
                }
            }
        }

        /**
         * Check whether the rabbit is alive or not.
         * @return true if the rabbit is still alive.
         */
        public bool IsAlive()
        {
            return alive;
        }

        /**
         * Indicate that the rabbit is no longer alive.
         * It is removed from the field.
         */
        public void SetDead()
        {
            alive = false;
            if (location != null)
            {
                field.Clear(location);
                location = null;
                field = null;
            }
        }

        /**
         * Return the rabbit's location.
         * @return The rabbit's location.
         */
        public Location GetLocation()
        {
            return location;
        }

        /**
         * Place the rabbit at the new location in the given field.
         * @param newLocation The rabbit's new location.
         */
        private void SetLocation(Location newLocation)
        {
            if (location != null)
            {
                field.Clear(location);
            }
            location = newLocation;
            field.Place(this, newLocation);
        }

        /**
         * Increase the age.
         * This could result in the rabbit's death.
         */
        private void IncrementAge()
        {
            age++;
            if (age > MAX_AGE)
            {
                SetDead();
            }
        }

        /**
         * Check whether or not this rabbit is to give birth at this step.
         * New births will be made into free adjacent locations.
         * @param newRabbits A list to return newly born rabbits.
         */
        private void GiveBirth(List<Rabbit> newRabbits)
        {
            // New rabbits are born into adjacent locations.
            // Get a list of adjacent free locations.
            List<Location> free = field.GetFreeAdjacentLocations(location);
            int births = Breed();
            for (int b = 0; b < births && free.Count > 0; b++)
            {
                Location loc = free[0];
                free.RemoveAt(0);

                Rabbit young = new Rabbit(false, field, loc);
                newRabbits.Add(young);
            }
        }

        /**
         * Generate a number representing the number of births,
         * if it can breed.
         * @return The number of births (may be zero).
         */
        private int Breed()
        {
            int births = 0;
            if (CanBreed() && rand.NextDouble() <= BREEDING_PROBABILITY)
            {
                births = rand.Next(MAX_LITTER_SIZE) + 1;
            }
            return births;
        }

        /**
         * A rabbit can breed if it has reached the breeding age.
         * @return true if the rabbit can breed, false otherwise.
         */
        private bool CanBreed()
        {
            return age >= BREEDING_AGE;
        }

    }
}
