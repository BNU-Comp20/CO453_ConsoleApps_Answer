using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;

namespace CO453_ConsoleAppAnswer
{
    public enum UnitSystems
    {
        Metric,
        Imperial
    }

    /// <summary>
    /// Prompt the user to select Imperial or Metric
    /// units.  Input the user's height and weight and
    /// then calculate their BMI value.  Output which
    /// weight category they fall into.
    /// </summary>
    public class BMI
    {
        private UnitSystems unitSystem;

        private double index;

        // Metric Details
        
        private int kilograms;
        private double metres;

        // Imperial Details
        
        private int stones;
        private double pounds;
        
        private int feet;
        private int inches;

        /// <summary>
        /// 
        /// </summary>
        public void CalculateIndex()
        {
            unitSystem = SelectUnits();

            if(unitSystem == UnitSystems.Metric)
            {
                InputMetricDetails();
                index = kilograms / (metres * metres);
            }
            else
            {
                InputImperialDetails();
                index = pounds * 703 / (inches * inches);
            }

            OutputHealthMessage();

        }

        private void OutputHealthMessage()
        {
            throw new NotImplementedException();
        }

        private void InputImperialDetails()
        {
            throw new NotImplementedException();
        }

        private void InputMetricDetails()
        {
            throw new NotImplementedException();
        }

        private UnitSystems SelectUnits()
        {
            throw new NotImplementedException();
        }
    }
}
