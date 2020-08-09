using System;
using System.Collections.Generic;

namespace CO453_ConsoleAppAnswer.App05v1
{
    /**
     * A simple model of a fox.
     * Foxes age, move, eat rabbits, and die.
     * 
     * @author David J. Barnes and Michael Kölling
     * @version 2016.02.29
     */
    public class Fox
    {
        // Characteristics shared by all foxes (class variables).

        // The age at which a fox can start to breed.
        private const int BREEDING_AGE = 15;
        // The age to which a fox can live.
        private const int MAX_AGE = 150;
        // The likelihood of a fox breeding.
        private const double BREEDING_PROBABILITY = 0.08;
        // The maximum number of births.
        private const int MAX_LITTER_SIZE = 2;
        // The food value of a single rabbit. In effect, this is the
        // number of steps a fox can go before it has to eat again.
        private const int RABBIT_FOOD_VALUE = 9;
        // A shared random number generator to control breeding.
        private readonly static Random rand =  Randomizer.GetRandom();
    
        // Individual characteristics (instance fields).

        // The fox's age.
        private int age;
        // Whether the fox is alive or not.
        private bool alive;
        // The fox's position.
        private Location location;
        // The field occupied.
        private Field field;
        // The fox's food level, which is increased by eating rabbits.
        private int foodLevel;

        /**
         * Create a fox. A fox can be created as a new born (age zero
         * and not hungry) or with a random age and food level.
         * 
         * @param randomAge If true, the fox will have random age and hunger level.
         * @param field The field currently occupied.
         * @param location The location within the field.
         */
        public Fox(bool randomAge, Field field, Location location)
        {
            age = 0;
            alive = true;
            this.field = field;
            SetLocation(location);
            if (randomAge)
            {
                age = rand.Next(MAX_AGE);
                foodLevel = rand.Next(RABBIT_FOOD_VALUE);
            }
            else
            {
                // leave age at 0
                foodLevel = rand.Next(RABBIT_FOOD_VALUE);
            }
        }

        /**
         * This is what the fox does most of the time: it hunts for
         * rabbits. In the process, it might breed, die of hunger,
         * or die of old age.
         * @param field The field currently occupied.
         * @param newFoxes A list to return newly born foxes.
         */
        public void Hunt(List<Fox> newFoxes)
        {
            IncrementAge();
            IncrementHunger();

            if (alive)
            {
                GiveBirth(newFoxes);
                // Move towards a source of food if found.
                Location newLocation = FindFood();
                if (newLocation == null)
                {
                    // No food found - try to move to a free location.
                    newLocation = field.FreeAdjacentLocation(location);
                }
                // See if it was possible to move.
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
         * Check whether the fox is alive or not.
         * @return True if the fox is still alive.
         */
        public bool IsAlive()
        {
            return alive;
        }

        /**
         * Return the fox's location.
         * @return The fox's location.
         */
        public Location GetLocation()
        {
            return location;
        }

        /**
         * Place the fox at the new location in the given field.
         * @param newLocation The fox's new location.
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
         * Increase the age. This could result in the fox's death.
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
         * Make this fox more hungry. This could result in the fox's death.
         */
        private void IncrementHunger()
        {
            foodLevel--;
            if (foodLevel <= 0)
            {
                SetDead();
            }
        }

        /**
         * Look for rabbits adjacent to the current location.
         * Only the first live rabbit is eaten.
         * @return Where food was found, or null if it wasn't.
         */
        private Location FindFood()
        {
            List<Location> adjacent = field.AdjacentLocations(location);

            foreach(Location where in adjacent)
            {
                Object animal = field.GetObjectAt(where);
                
                if (animal is Rabbit) 
                {
                    Rabbit rabbit = (Rabbit)animal;
                    if (rabbit.IsAlive())
                    {
                        rabbit.SetDead();
                        foodLevel = RABBIT_FOOD_VALUE;
                        return where;
                    }
                }
            }
            return null;
        }

        /**
         * Check whether or not this fox is to give birth at this step.
         * New births will be made into free adjacent locations.
         * @param newFoxes A list to return newly born foxes.
         */
        private void GiveBirth(List<Fox> newFoxes)
        {
            // New foxes are born into adjacent locations.
            // Get a list of adjacent free locations.
            List<Location> free = field.GetFreeAdjacentLocations(location);
            int births = Breed();
            for (int b = 0; b < births && free.Count > 0; b++)
            {
                Location loc = free[0];
                free.RemoveAt(0);

                Fox young = new Fox(false, field, loc);
                newFoxes.Add(young);
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
         * A fox can breed if it has reached the breeding age.
         */
        private bool CanBreed()
        {
            return age >= BREEDING_AGE;
        }

        /**
         * Indicate that the fox is no longer alive.
         * It is removed from the field.
         */
        private void SetDead()
        {
            alive = false;
            if (location != null)
            {
                field.Clear(location);
                location = null;
                field = null;
            }
        }

    }
}
