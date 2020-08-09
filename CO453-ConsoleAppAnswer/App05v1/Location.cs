using System;

namespace CO453_ConsoleAppAnswer.App05v1
{
    /**
     * Represent a location in a rectangular grid.
     * 
     * @author David J. Barnes and Michael Kölling
     * @version 2016.02.29
     */
    public class Location
    {
        // Row and column positions.
        public int Row { get; set; }
        public int Column { get; set; }

        /**
         * Represent a row and column.
         * @param row The row.
         * @param col The column.
         */
        public Location(int row, int col)
        {
            this.Row = row;
            this.Column = col;
        }

        /**
         * Implement content equality.
         */
        public bool Equals(Object obj)
        {
            if (obj.GetType() == typeof(Location)) 
            {
                Location other = (Location)obj;
                return Row == other.Row && Column == other.Column;
            }
            else
            {
                return false;
            }
        }

        /**
         * Return a string of the form row,column
         * @return A string representation of the location.
         */
        public override string ToString()
        {
            return Row + "," + Column;
        }

        /**
         * Use the top 16 bits for the row value and the bottom for
         * the column. Except for very big grids, this should give a
         * unique hash code for each (row, col) pair.
         * @return A hashcode for the location.
         */
        public int HashCode()
        {
            return (Row << 16) + Column;
        }

    }
}
