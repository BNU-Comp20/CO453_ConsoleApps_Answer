using System;
using System.Collections.Generic;
using System.Text;

namespace CO453_ConsoleAppAnswer.App05v1
{
    /**
     * Represent a rectangular grid of field positions.
     * Each position is able to store a single animal.
     * 
     * @author David J. Barnes and Michael Kölling
     * @version 2016.02.29
     */
    public class Field
    {
        // A random number generator for providing random locations.
        private readonly Random rand = Randomizer.GetRandom();
    
        // The depth and width of the field.
        public int Depth { get; }
        public int Width { get; }

        // Storage for the animals.
        private readonly Object[,] animals;

        /**
         * Represent a field of the given dimensions.
         * @param depth The depth of the field.
         * @param width The width of the field.
         */
        public Field(int depth, int width)
        {
            Depth = depth;
            Width = width;
            animals = new Object[Depth, Width];
        }

        /**
         * Empty the field.
         */
        public void Clear()
        {
            for (int row = 0; row < Depth; row++)
            {
                for (int col = 0; col < Width; col++)
                {
                    animals[row, col] = null;
                }
            }
        }

        /**
         * Clear the given location.
         * @param location The location to clear.
         */
        public void Clear(Location location)
        {
            animals[location.Row, location.Column] = null;
        }

        /**
         * Place an animal at the given location.
         * If there is already an animal at the location it will
         * be lost.
         * @param animal The animal to be placed.
         * @param row Row coordinate of the location.
         * @param col Column coordinate of the location.
         */
        public void Place(Object animal, int row, int col)
        {
            Place(animal, new Location(row, col));
        }

        /**
         * Place an animal at the given location.
         * If there is already an animal at the location it will
         * be lost.
         * @param animal The animal to be placed.
         * @param location Where to place the animal.
         */
        public void Place(Object animal, Location location)
        {
            animals[location.Row, location.Column] = animal;
        }

        /**
         * Return the animal at the given location, if any.
         * @param location Where in the field.
         * @return The animal at the given location, or null if there is none.
         */
        public Object GetAnimalAt(Location location)
        {
            return GetAnimalAt(location.Row, location.Column);
        }

        /**
         * Return the animal at the given location, if any.
         * @param row The desired row.
         * @param col The desired column.
         * @return The animal at the given location, or null if there is none.
         */
        public Object GetAnimalAt(int row, int col)
        {
            return animals[row, col];
        }

        /**
         * Generate a random location that is adjacent to the
         * given location, or is the same location.
         * The returned location will be within the valid bounds
         * of the field.
         * @param location The location from which to generate an adjacency.
         * @return A valid location within the grid area.
         */
        public Location RandomAdjacentLocation(Location location)
        {
            List<Location> adjacent = AdjacentLocations(location);
            return adjacent[0];
        }

        /**
         * Get a shuffled list of the free adjacent locations.
         * @param location Get locations adjacent to this.
         * @return A list of free adjacent locations.
         */
        public List<Location> GetFreeAdjacentLocations(Location location)
        {
            List<Location> free = new List<Location>();
            List<Location> adjacent = AdjacentLocations(location);

            foreach (Location next in adjacent)
            {
                if (GetAnimalAt(next) == null)
                {
                    free.Add(next);
                }
            }
            return free;
        }

        /**
         * Try to find a free location that is adjacent to the
         * given location. If there is none, return null.
         * The returned location will be within the valid bounds
         * of the field.
         * @param location The location from which to generate an adjacency.
         * @return A valid location within the grid area.
         */
        public Location FreeAdjacentLocation(Location location)
        {
            // The available free ones.
            List<Location> free = GetFreeAdjacentLocations(location);
            if (free.Count > 0)
            {
                return free[0];
            }
            else
            {
                return null;
            }
        }

        /**
         * Return a shuffled list of locations adjacent to the given one.
         * The list will not include the location itself.
         * All locations will lie within the grid.
         * @param location The location from which to generate adjacencies.
         * @return A list of locations adjacent to that given.
         */
        public List<Location> AdjacentLocations(Location location)
        {
            // The list of locations to be returned.
            List<Location> locations = new List<Location>();

            if (location != null)
            {
                int row = location.Row;
                int col = location.Column;

                for (int roffset = -1; roffset <= 1; roffset++)
                {
                    int nextRow = row + roffset;
                    if (nextRow >= 0 && nextRow < Depth)
                    {
                        for (int coffset = -1; coffset <= 1; coffset++)
                        {
                            int nextCol = col + coffset;
                            // Exclude invalid locations and the original location.
                            if (nextCol >= 0 && nextCol < Width && (roffset != 0 || coffset != 0))
                            {
                                locations.Add(new Location(nextRow, nextCol));
                            }
                        }
                    }
                }

                // Shuffle the list. Several other methods rely on the list
                // being in a random order.
                Shuffle(locations);
            }
            return locations;
        }

        private void Shuffle(List<Location> locations)
        {
            // todo
        }

        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();
            builder.AppendLine($"Field Contents:");
            builder.AppendLine();

            for (int row = 0; row < animals.GetLength(0); row++)
            {
               for(int column = 0; column < animals.GetLength(1); column++)
               {
                    if(animals[row,column] == null)
                    {
                        builder.Append(".");
                    }
                    else 
                    {
                        builder.Append(animals[row, column].ToString());
                    }
               }
                builder.AppendLine();
            }

            builder.AppendLine();
            return builder.ToString();
        }

    }
}
