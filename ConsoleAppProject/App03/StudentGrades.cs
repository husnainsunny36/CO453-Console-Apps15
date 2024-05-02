using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using ConsoleAppProject.Helpers;


namespace ConsoleAppProject.App03
{
    /// <summary>
    /// This application will allow a tutor to enter a single mark of each of
    /// a list of students and it will convert that mark into a grade. 
    /// </summary>
    /// <author>
    /// Husnain Ateeq version 0.9
    /// </author>
    public class StudentGrades
    {
        // Constants representing the highest possible mark, various grade thresholds, and the lowest possible mark.
        public const int HighestMark = 100;
        public const int LowestGradeA = 70;
        public const int LowestGradeB = 60;
        public const int LowestGradeC = 50;
        public const int LowestGradeD = 40;
        public const int LowestMark = 0;

        // Properties to store student names, their marks, a profile of grades, and statistical data.
        public string[] Students { get; set; }
        public int[] Marks { get; set; }
        public int[] GradeProfile { get; set; }
        public double Mean { get; set; }
        public int Minimum { get; set; }
        public int Maximum { get; set; }
        public string StudentClass { get; set; }

        // Constructor initializes the students' names and arrays for marks and grade profile.
        public StudentGrades()
        {
            Students = new string[]
            {
            "Husnain", "Kaleem", "Asim", "Ismael", "Noman", "Jake", "Flavious", "Carl", "Andy", "Danny"
            };

            GradeProfile = new int[(int)Grades.A + 1];
            Marks = new int[Students.Length];
        }

        // Method to input marks for each student, ensuring they are within the valid range.
        public void InputMarks()
        {
            ConsoleHelper.OutputHeading1("\t\tPlease enter a mark for each student");
            for (int i = 0; i < Students.Length; i++)
            {
                Marks[i] = (int)ConsoleHelper.InputNumber($"Enter {Students[i]} marks: ", LowestMark, HighestMark);
            }
            Console.WriteLine();
            ConsoleHelper.OutputHeading("\t\t Student Marks System");
            DisplayMenu("\nPlease enter your choice > ");
        }

        // Method to output each student's name, mark, grade, and class.
        public void OutputMarks()
        {
            ConsoleHelper.OutputHeading1("\t\tThe each Student Marks");

            for (int i = 0; i < Students.Length; i++)
            {
                Console.WriteLine($"Student Name: {Students[i]} \tStudent Mark: {Marks[i]}\t" +
                    $"Student Grade: {ConvertToGrade(Marks[i])}\tStudent Class: {StudentClass}\t");
            }
            Console.WriteLine();
            ConsoleHelper.OutputHeading("\t\t Student Marks System");
            DisplayMenu("\n\nPlease enter your choice > ");
        }

        // Method to convert numeric marks into letter grades and classes based on defined thresholds.
        public Grades ConvertToGrade(int mark)
        {
            if (mark >= LowestMark && mark < LowestGradeD)
            {
                StudentClass = "Referred";
                return Grades.F;
            }
            else if (mark >= LowestGradeD && mark < LowestGradeC)
            {
                StudentClass = "BSc(Hons) Third Class";
                return Grades.D;
            }
            else if (mark >= LowestGradeC && mark < LowestGradeB)
            {
                StudentClass = "BSc(Hons) Lower Second";
                return Grades.C;
            }
            else if (mark >= LowestGradeB && mark < LowestGradeA)
            {
                StudentClass = "BSc(Hons) Upper Second";
                return Grades.B;
            }
            else if (mark >= LowestGradeA && mark <= HighestMark)
            {
                StudentClass = "BSc(Hons) First Class";
                return Grades.A;
            }
            else
            {
                return Grades.F;
            }
        }

        // Method to calculate and display statistical data such as mean, minimum, and maximum marks.
        public void CalculateStats()
        {
            Minimum = Marks[0];
            Maximum = Marks[0];

            double total = 0;
            foreach (int mark in Marks)
            {
                total += mark;
                if (mark > Maximum)
                {
                    Maximum = mark;
                }
                else if (mark < Minimum)
                {
                    Minimum = mark;
                }
            }

            Mean = total / Marks.Length;

            ConsoleHelper.OutputHeading1("The Student Mean Mark, Minimum Mark and Maximum Mark");
            Console.WriteLine($"Mean Mark: {Mean}\nMinimum Mark: {Minimum}\nMaximum Mark:{Maximum}");
            Console.WriteLine();
            ConsoleHelper.OutputHeading("\t\t Student Marks System");
            DisplayMenu("\n\nPlease enter your choice > ");
        }

        // Method to calculate the grade distribution of students.
        public void CalculateGradeProfile()
        {
            for (int i = 0; i < GradeProfile.Length; i++)
            {
                GradeProfile[i] = 0;
            }

            foreach (int mark in Marks)
            {
                Grades grade = ConvertToGrade(mark);
                GradeProfile[(int)grade]++;
            }
        }

        // Method to output the grade distribution of students.
        public void OutputGradeProfile()
        {
            Grades grade = Grades.D;
            Console.WriteLine();
            ConsoleHelper.OutputHeading1("\t\tThe Student Grade Profile");
            foreach (int count in GradeProfile)
            {
                int percentage = count * 100 / Marks.Length;
                Console.WriteLine($"Grade {grade}\t {percentage}%\t Count {count}");
                grade++;
            }

            Console.WriteLine();
            ConsoleHelper.OutputHeading("\t\t Student Marks System");
            DisplayMenu("\n\nPlease enter your choice > ");
        }

        // Method to display a menu and capture the user's choice.
        private void DisplayMenu(string display)
        {
            string[] choices =
            {
            "Input Marks",
            "Output Marks",
            "Output Stats",
            "Output Grade Profile",
            "Quit"
        };
            int choiceNo = ConsoleHelper.SelectChoice(choices);
            GradeIndex(choiceNo);
        }

        // Method to handle the user's menu selection and invoke corresponding functionality.
        public void GradeIndex(int choiceNo)
        {
            switch (choiceNo)
            {
                case 1:
                    InputMarks();
                    break;
                case 2:
                    OutputMarks();
                    break;
                case 3:
                    CalculateStats();
                    break;
                case 4:
                    CalculateGradeProfile();
                    OutputGradeProfile();
                    break;
                case 5:
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Invalid choice");
                    DisplayMenu("Please enter your choice > ");
                    break;
            }
        }

        // Method to display the main menu for the student grades management system.
        public void StudentGradesMenu()
        {
            ConsoleHelper.OutputHeading("\t\t Student Marks System");
            DisplayMenu("Please enter your choice > ");
        }
    }
