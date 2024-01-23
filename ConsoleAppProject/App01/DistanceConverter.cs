using System;

namespace ConsoleAppProject.App01
{
    /// <summary>
    /// This App will prompt the user to input a distance
    /// measured in one unit (fromUnit) and it will calculate and
    /// output the equivalent distance in another unit (toUnit)
    /// </summary>
    /// <author>
    /// Husnain Version 0.6
    /// </author>
    public class DistanceConverter
    {
        public const int FEET_IN_MILES = 5280;
        public const double METRE_IN_MILES = 1609.34;
        public const double FEET_IN_METRES = 3.28084;

        public const string FEET = "feet";
        public const string METRES = "metres";
        public const string MILES = "miles";

        private double fromDistance;
        private double toDistance;

        private string fromUnit;
        private string toUnit;

        public DistanceConverter ()
        {
            fromUnit = MILES;
            toUnit = FEET;
        }

        /// <summary>
        /// This method will input the distance measured in miles
        /// calculate the same distance in feet, and output the
        /// distance in feet.
        /// </summary>

        public void ConvertDistance()
        {
            OutputHeading();

            fromUnit = SelectUnit(" Please select the from distance unit > ");
            toUnit = SelectUnit(" Please select the to distance unit > ");

            Console.WriteLine($"\n Converting {fromUnit} To {toUnit}");

            fromDistance  = InputDistance($" Enter The Number of {fromUnit} > ");

            CalculateDistance();

            OutputDistance();

        }

        private void CalculateDistance()
        {
            if(fromUnit == MILES &&  toUnit == FEET) 
            {
                toDistance = fromDistance * FEET_IN_MILES;
            }
            else if (fromUnit == FEET && toUnit == MILES)
            {
                toDistance = fromDistance / FEET_IN_MILES;
            }

            if (fromUnit == FEET && toUnit == METRES)
            {
                toDistance = fromDistance / FEET_IN_METRES ;
            }
            else if (fromUnit == METRES && toUnit == FEET)
            {
                toDistance = fromDistance * FEET_IN_METRES ;
            }

            if (fromUnit == METRES && toUnit == MILES)
            {
                toDistance = fromDistance / METRE_IN_MILES ;
            }
            else if (fromUnit == MILES && toUnit == METRES)
            {
                toDistance = fromDistance * METRE_IN_MILES ;
            }
        }

        private string SelectUnit(string prompt)
        {
            string choice = DisplayChoices(prompt);
            string unit = ExecuteChoice(choice);
            Console.WriteLine($"\n You have chosen {unit}");
            return unit;
        }

        private static string ExecuteChoice(string choice)
        {
            if (choice.Equals("1"))
            {
                return FEET;
            }
            else if (choice == "2")
            {
                return METRES;
            }
            else if (choice == "3")
            {
                return MILES;
            }
            return null;
        }

        private static string DisplayChoices(string prompt)
        {
            Console.WriteLine();
            Console.WriteLine($" 1. {FEET}");
            Console.WriteLine($" 2. {METRES}");
            Console.WriteLine($" 3. {MILES}");
            Console.WriteLine();

            Console.Write(prompt);
            string choice = Console.ReadLine();
            return choice;
        }



        /// <summary>
        /// prompt the user to input the distance in miles
        /// Input the miles as a double numbers
        /// </summary>
        private double InputDistance(string prompt)
        {
            Console.Write(prompt);
            string value = Console.ReadLine();
            return Convert.ToDouble(value);
        }

        

        private void OutputDistance()
        {
            Console.WriteLine($"\n {fromDistance} {fromUnit}" +
                $" is {toDistance} {toUnit}!\n");
        }

        

        private void OutputHeading()
        {
            Console.WriteLine();
            Console.WriteLine("----------------------------------");
            Console.WriteLine("        Distance Converter        ");
            Console.WriteLine("         By Husnain Ateeq         ");
            Console.WriteLine("----------------------------------");
            Console.WriteLine();
        }

    }
}
