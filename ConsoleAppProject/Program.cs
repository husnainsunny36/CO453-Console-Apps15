using ConsoleAppProject.App01;
using ConsoleAppProject.App02;
using ConsoleAppProject.App03;
using ConsoleAppProject.App04;
using ConsoleAppProject.Helpers;
using System;

namespace ConsoleAppProject
{
    /// <summary>
    /// The main method in this class is called first
    /// when the application is started.  It will be used
    /// to start App01 to App05 for CO453 CW1
    /// 
    /// This Project has been modified by:
    /// Husnain Ateeq 
    /// </summary>
    public static class Program
    {
        public static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;

            Console.WriteLine();
            Console.WriteLine(" =================================================");
            Console.WriteLine("    BNU CO453 Applications Programming 2023-2024! ");
            Console.WriteLine(" =================================================");
            Console.WriteLine();

            // Display menu to choose between apps
            int appChoice = DisplayAppMenu("Choose an app to run:\n1. Distance Converter\n2. BMI Calculator\n3. Student Grades\n4. Social App");

            // Run the chosen app
            switch (appChoice)
            {
                case 1:
                    RunDistanceConverter();
                    Console.ReadLine();
                    
                    break;

                case 2:
                    RunBMIApp();
                    Console.ReadLine();
                    break;

                case 3:
                    RunStudentGradesApp();
                    Console.ReadLine();
                    break;

                case 4:
                    RunSocialApp();
                    Console.ReadLine();
                    break;
                   
                default:
                    Console.WriteLine("Invalid choice. Exiting the program.");
                    break;
            }

        }

        private static int DisplayAppMenu(string prompt)
        {
            int choice;

            Console.WriteLine(prompt);
            Console.Write("Enter your choice: ");

            while (!int.TryParse(Console.ReadLine(), out choice) || choice < 1 || choice > 4)
            {
                Console.Write("Invalid input. Please enter a valid choice: ");
            }

            return choice;
        }


        private static void RunDistanceConverter()
        {
            DistanceConverter converter = new DistanceConverter();
            converter.ConvertDistance();
        }

        private static void RunBMIApp()
        {
            BMI bmi = new BMI();
            bmi.Main();
        }

        private static void RunStudentGradesApp()
        {
            StudentGrades studentGrades = new StudentGrades();
            studentGrades.StudentGradesMenu();
        }

        private static void RunSocialApp() 
        {
            NewsApp news = new NewsApp();
            news.DisplayMenu();
        }


    }
}
