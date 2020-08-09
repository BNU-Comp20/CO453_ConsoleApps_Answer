
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
        public void ShowStatus(int step, Field field)
        {
            throw new NotSupportedException();
        }

        public bool IsViable(Field field)
        {
            return true;
        }
    }
}
