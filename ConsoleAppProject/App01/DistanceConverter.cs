using System;

namespace ConsoleAppProject.App01
{
    /// <summary>
    /// Please describe the main features of this App
    /// </summary>
    /// <author>
    /// Derek version 0.1
    /// </author>
    public class DistanceConverter
    {
        private double miles;
        private double feet;

        public void Run()
        {
            InputMiles();
            CalculateFeet();
            OutputFeet();

        }

        /// <summary>
        /// prompt the user to input the distance in miles
        /// Input the miles as a double numbers
        /// </summary>
        private void InputMiles()
        {
            Console.Write("Please Enter the number of miles > ");
            string value = Console.ReadLine();
            miles = Convert.ToDouble(value);
        }

        private void CalculateFeet()
        {

        }

        private void OutputFeet()
        {

        }

    }
}
