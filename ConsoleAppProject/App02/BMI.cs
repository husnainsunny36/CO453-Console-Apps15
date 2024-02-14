using System;

namespace ConsoleAppProject.App02
{
    /// <summary>
    /// This app is to calculate BMI (Body Mass Index) using
    /// imperial or metric Units
    /// </summary>
    /// <author>
    /// Husnain Ateeq version 0.1
    /// </author>
    public class BMI
    {
        double pounds, stones, kilograms, inches, feet, bmi, metres;
        private int choice;

        // BMI categories boundaries
        const double Underweight = 18.5;
        const double Normal = 24.9;
        const double Overweight = 29.9;
        const double ObeseClass1 = 34.9;
        const double ObeseClass2 = 39.9;

        public void Main()
        {
            OutputHeading();
            // Display the menu to choose between imperial or metric units
            int choice = DisplayMenu("Enter your choice: ");

            // Process the choice
            switch (choice)
            {
                case 1:
                    GetImperialDetails();
                    CalculateImperialBMI();
                    Console.WriteLine(BmiMessage());
                    Console.WriteLine(DisplayBameMessage());
                    break;

                case 2:
                    GetMetricDetails();
                    CalculateMetricBMI();
                    Console.WriteLine(BmiMessage());
                    Console.WriteLine(DisplayBameMessage());
                    break;

                default:
                    Console.WriteLine("Invalid choice. Exiting the program.");
                    break;
            }
        }

        private static int DisplayMenu(string prompt)
        {
            // Display the menu and get user's choice
            int choice;
            Console.WriteLine("1. Imperial Units");
            Console.WriteLine("2. Metric Units");
            Console.Write($" \n {prompt} ");
            while (!int.TryParse(Console.ReadLine(), out choice) || choice < 1 || choice > 2)
            {
                Console.Write(" Invalid input. Please enter a valid choice.");
            }
            return choice;
        }

        public void CalculateMetricBMI()
        {
            // Calculate Metric BMI
            // Formula: BMI = weight (kg) / (height (m) * height (m))
            bmi = kilograms / (metres * metres);
            Console.WriteLine($"Your Metric BMI is: {bmi}");
        }

        public string BmiMessage()
        {
            // Generate BMI message based on categories
            string message;

            if (bmi < Underweight)
            {
                message = $"Your BMI is {bmi}. You are underweight.";
            }
            else if (bmi <= Normal)
            {
                message = $"Your BMI is {bmi}. You are within the normal weight range.";
            }
            else if (bmi <= Overweight)
            {
                message = $"Your BMI is {bmi}. You are overweight.";
            }
            else if (bmi <= ObeseClass1)
            {
                message = $"Your BMI is {bmi}. You are in Obese Class 1.";
            }
            else if (bmi <= ObeseClass2)
            {
                message = $"Your BMI is {bmi}. You are in Obese Class 2.";
            }
            else
            {
                message = $"Your BMI is {bmi}. You are in Obese Class 3.";
            }

            return message;
        }

        public void CalculateImperialBMI()
        {
            // Calculate Imperial BMI
            // Convert height to inches and weight to pounds
            double heightInInches = (feet * 12) + inches;
            double weightInPounds = (stones * 14) + pounds;

            // Formula: BMI = (weight (lb) / height (in) / height (in)) * 703
            bmi = (weightInPounds / (heightInInches * heightInInches)) * 703;
            Console.WriteLine($"Your Imperial BMI is: {bmi}");
        }

        public void GetMetricDetails()
        {
            // Get user input for Metric details
            Console.Write("Enter height in meters: ");
            while (!double.TryParse(Console.ReadLine(), out metres) || metres <= 0)
            {
                Console.Write("Invalid input. Please enter a valid height in meters: ");
            }

            Console.Write("Enter weight in kilograms: ");
            while (!double.TryParse(Console.ReadLine(), out kilograms) || kilograms <= 0)
            {
                Console.Write("Invalid input. Please enter a valid weight in kilograms: ");
            }
        }
        
        public void GetImperialDetails()
        {
            // Get user input for Imperial details
            Console.Write("Enter weight in stones: ");
            while (!double.TryParse(Console.ReadLine(), out stones) || stones <= 0)
            {
                Console.Write("Invalid input. Please enter a valid weight in stones: ");
            }

            Console.Write("Enter additional pounds: ");
            while (!double.TryParse(Console.ReadLine(), out pounds) || pounds < 0)
            {
                Console.Write("Invalid input. Please enter a valid additional pounds: ");
            }

            Console.Write("Enter height in feet: ");
            while (!double.TryParse(Console.ReadLine(), out feet) || feet <= 0)
            {
                Console.Write("Invalid input. Please enter a valid height in feet: ");
            }

            Console.Write("Enter additional inches: ");
            while (!double.TryParse(Console.ReadLine(), out inches) || inches < 0)
            {
                Console.Write("Invalid input. Please enter a valid additional inches: ");
            }
        }

        public string DisplayBameMessage()
        {
            // Display message related to ethnic groups
            string bame = ("\n if you are Black, Asian, or other minority ethnic groups, " +
                " \n you have a higher risk, Adults at 23.0 or more are at increased risk," +
                " Adults at 27.5 or more are at high risk.");

            return bame;
        }

        private void OutputHeading()
        {
            Console.WriteLine();
            Console.WriteLine("----------------------------------");
            Console.WriteLine("            BMI Calculator        ");
            Console.WriteLine("           By Husnain Ateeq       ");
            Console.WriteLine("----------------------------------");
            Console.WriteLine();
        }
    }
}
