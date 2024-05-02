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
        // Constants to define the number of feet in a mile, metres in a mile, and feet in a metre.
        public const int FEET_IN_MILES = 5280;
        public const double METRE_IN_MILES = 1609.34;
        public const double FEET_IN_METRES = 3.28084;

        // Properties to store the distances and units for conversion.
        public double FromDistance { get; set; }
        public double ToDistance { get; set; }
        public DistanceUnits FromUnit { get; set; }
        public DistanceUnits ToUnit { get; set; }

        // Default constructor initializing default conversion from miles to feet.
        public DistanceConverter()
        {
            FromUnit = DistanceUnits.Miles;
            ToUnit = DistanceUnits.Feet;
        }

        /// <summary>
        /// Main method to manage distance conversion workflow including user input and output.
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

        /// <summary>
        /// Calculates the converted distance based on the selected units.
        /// </summary>
        public void CalculateDistance()
        {
            // Handles all unit conversions through conditional checks.
            if (FromUnit == DistanceUnits.Miles && ToUnit == DistanceUnits.Feet)
                ToDistance = FromDistance * FEET_IN_MILES;
            else if (FromUnit == DistanceUnits.Miles && ToUnit == DistanceUnits.Metres)
                ToDistance = FromDistance * METRE_IN_MILES;
            else if (FromUnit == DistanceUnits.Feet && ToUnit == DistanceUnits.Miles)
                ToDistance = FromDistance / FEET_IN_MILES;
            else if (FromUnit == DistanceUnits.Feet && ToUnit == DistanceUnits.Metres)
                ToDistance = FromDistance / FEET_IN_METRES;
            else if (FromUnit == DistanceUnits.Metres && ToUnit == DistanceUnits.Miles)
                ToDistance = FromDistance / METRE_IN_MILES;
            else if (FromUnit == DistanceUnits.Metres && ToUnit == DistanceUnits.Feet)
                ToDistance = FromDistance * FEET_IN_METRES;
            else if (FromUnit == ToUnit)
                ToDistance = FromDistance;
        }

        /// <summary>
        /// Guides user to select a distance unit with a console prompt.
        /// </summary>
        private DistanceUnits SelectUnit(string prompt)
        {
            string choice = DisplayChoices(prompt);
            DistanceUnits unit = ExecuteChoice(choice);
            while (unit == DistanceUnits.NoUnit)
            {
                Console.WriteLine("error, invalid input");
                choice = DisplayChoices(prompt);
                unit = ExecuteChoice(choice);
            }
            Console.WriteLine($"\n You have chosen {unit}");
            return unit;
        }

        /// <summary>
        /// Executes conversion based on user's choice of unit.
        /// </summary>
        private static DistanceUnits ExecuteChoice(string choice)
        {
            if (choice.Equals("1"))
                return DistanceUnits.Feet;
            else if (choice == "2")
                return DistanceUnits.Metres;
            else if (choice == "3")
                return DistanceUnits.Miles;
            return DistanceUnits.NoUnit;
        }

        /// <summary>
        /// Displays options for units to the user and captures selection.
        /// </summary>
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
        /// Prompts user to enter a distance value and validates it.
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

        /// <summary>
        /// Outputs the conversion result to the console.
        /// </summary>
        private void OutputDistance()
        {
            Console.WriteLine($"\n {FromDistance} {FromUnit}" +
                $" is {ToDistance} {ToUnit}!\n");
        }

        /// <summary>
        /// Displays a heading for the converter at the beginning of interaction.
        /// </summary>
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
