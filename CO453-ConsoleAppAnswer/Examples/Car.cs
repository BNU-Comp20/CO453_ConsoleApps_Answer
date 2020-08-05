namespace CO453_ConsoleAppAnswer
{
    /// <summary>
    /// This is a comment describing the
    /// main purpose of the class
    /// </summary>
    public class Car
    {
        // Attributes
        private readonly string make;

        private readonly string model;

        private readonly string colour;

        /// <summary>
        /// Constructor
        /// </summary>
        public Car()
        {
            make = "Honda";
            model = "Jazz";
            colour = "White";
        }

        /// <summary>
        /// Change gear between 1 and 5
        /// </summary>
        public void ChangeGear()
        {
        }

        /// <summary>
        /// Accelerate, speed the car up or slow the car down
        /// </summary>
        public void Accelerate()
        {
        }

        /// <summary>
        /// Stop the car from moving or slow it down
        /// </summary>
        public void Brake()
        {
        } // end of method

        public override string ToString()
        {
            return $"{make} {model} {colour}";
        }
    } // end of class
}
