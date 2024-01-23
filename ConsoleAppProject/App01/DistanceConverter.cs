using System;

namespace ConsoleAppProject.App01
{
    /// <summary>
    /// Please describe the main features of this App
    /// </summary>
    /// <author>
    /// Husnain Version 0.3
    /// </author>
    public class DistanceConverter
    {
        public const int FEET_IN_MILES = 5280;
        public const double METRE_IN_MILES = 1609.34;
        private double miles;
        private double feet;
        private double metres;


        public void MilesToFeet()
        {
            OutputHeading("Converting Miles To Feet");
            miles = InputDistance("Please Enter The Number of Miles > ");
            CalculateFeet();
            OutputDistance(miles, nameof (miles), feet , nameof (feet));

        }

        public void FeetToMiles()
        {
            OutputHeading("Converting Feet To Miles");
            feet = InputDistance("Please Enter The Number of Feet > ");
            CalculateMiles();
            OutputDistance(feet, nameof(feet), miles, nameof(miles));

        }

        public void MilesToMetres()
        {
            OutputHeading("Converting Miles To Metres");
            miles = InputDistance("Please Enter The Number of Miles > ");
            CalculateMetres();
            OutputDistance(miles, nameof(miles), metres, nameof(metres));

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

        
        private void CalculateFeet()
        {
            feet = miles * FEET_IN_MILES;
        }

        private void CalculateMiles()
        {
            miles = feet / FEET_IN_MILES;
        }

        private void CalculateMetres()
        {
            metres = miles * METRE_IN_MILES;
        }

        private void OutputDistance(
            double fromDistance, string fromUnit,
            double toDistance, string toUnit)
        {
            Console.WriteLine($"{fromDistance} {fromUnit}" +
                $" is {toDistance} {toUnit}!");
        }

        

        private void OutputHeading(String prompt)
        {
            Console.WriteLine();
            Console.WriteLine("----------------------------------");
            Console.WriteLine("        Distance Converter        ");
            Console.WriteLine("         By Husnain Ateeq         ");
            Console.WriteLine("----------------------------------");
            Console.WriteLine();

            Console.WriteLine(prompt);
            Console.WriteLine();

        }

    }
}
