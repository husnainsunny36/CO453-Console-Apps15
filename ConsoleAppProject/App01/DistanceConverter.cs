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



        public double FromDistance { get; set; }
        public double ToDistance { get; set; }

        public DistanceUnits FromUnit { get; set; }
        public DistanceUnits ToUnit { get; set; }
        public static DistanceUnits FEET { get; set; }
        public static DistanceUnits MILES { get; set; }

        public DistanceConverter()
        {
            FromUnit = DistanceUnits.Miles;
            ToUnit = DistanceUnits.Feet;
        }

        /// <summary>
        /// This method will input the distance measured in miles
        /// calculate the same distance in feet, and output the
        /// distance in feet.
        /// </summary>

        public void ConvertDistance()
        {
            OutputHeading();

            FromUnit = SelectUnit(" Please select the from distance unit > ");
            ToUnit = SelectUnit(" Please select the to distance unit > ");

            Console.WriteLine($"\n Converting {FromUnit} To {ToUnit}");

            FromDistance = InputDistance($" Enter The Number of {FromUnit} > ");

            CalculateDistance();

            OutputDistance();

        }


        public void CalculateDistance()

        {
            if (FromUnit == DistanceUnits.Miles && ToUnit == DistanceUnits.Feet)
            {
                ToDistance = FromDistance * FEET_IN_MILES;
            }
            else if (FromUnit == DistanceUnits.Miles && ToUnit == DistanceUnits.Metres)
            {
                ToDistance = FromDistance * METRE_IN_MILES;
            }
            else if (FromUnit == DistanceUnits.Feet && ToUnit == DistanceUnits.Miles)
            {
                ToDistance = FromDistance / FEET_IN_MILES;
            }
            else if (FromUnit == DistanceUnits.Feet && ToUnit == DistanceUnits.Metres)
            {
                ToDistance = FromDistance / FEET_IN_METRES;
            }
            else if (FromUnit == DistanceUnits.Metres && ToUnit == DistanceUnits.Miles)
            {
                ToDistance = FromDistance / METRE_IN_MILES;
            }
            else if (FromUnit == DistanceUnits.Metres && ToUnit == DistanceUnits.Feet)
            {
                ToDistance = FromDistance * FEET_IN_METRES;
            }
            else if (FromUnit == ToUnit)
            {
                ToDistance = FromDistance;
            }

        }

        private DistanceUnits SelectUnit(string prompt)
        {
            string choice = DisplayChoices(prompt);
            DistanceUnits unit = ExecuteChoice(choice);

            //checking error for invalid input
            while (unit == DistanceUnits.NoUnit)
            {
                Console.WriteLine("error, invalid input");
                choice = DisplayChoices(prompt);
                unit = ExecuteChoice(choice);
            }
            Console.WriteLine($"\n You have chosen {unit}");
            return unit;
        }

        private static DistanceUnits ExecuteChoice(string choice)
        {
            if (choice.Equals("1"))
            {
                return DistanceUnits.Feet;
            }
            else if (choice == "2")
            {
                return DistanceUnits.Metres;
            }
            else if (choice == "3")
            {
                return DistanceUnits.Miles;
            }
            return DistanceUnits.NoUnit;
        }

        private static string DisplayChoices(string prompt)
        {
            Console.WriteLine();
            Console.WriteLine($" 1. {DistanceUnits.Feet}");
            Console.WriteLine($" 2. {DistanceUnits.Metres}");
            Console.WriteLine($" 3. {DistanceUnits.Miles}");
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
            double enteredDistance = 0.00;
            bool isValidInput = false;

            do
            {
                Console.Write(prompt);
                string value = Console.ReadLine();

                try
                {
                    enteredDistance = Convert.ToDouble(value);
                    
                    isValidInput = true;
                    if (enteredDistance < 0)
                    {
                        isValidInput = false;
                        Console.WriteLine("Invalid Input");
                    }
                }
                catch (Exception E)
                {

                    Console.WriteLine("Error: Please enter a valid number.");
                }

            } while (!isValidInput);

            return enteredDistance;
            
        }




        private void OutputDistance()
        {
            Console.WriteLine($"\n {FromDistance} {FromUnit}" +
                $" is {ToDistance} {ToUnit}!\n");
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