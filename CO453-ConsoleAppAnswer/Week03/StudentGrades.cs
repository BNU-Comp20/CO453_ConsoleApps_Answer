using System;

namespace CO453_ConsoleAppAnswer.Week03
{
    /// <summary>
    /// Grade A is First Class   : 70 - 100
    /// Grade B is Upper Second  : 60 - 69
    /// Grade C is Lower Second  : 50 - 59
    /// Grade D is Third Class   : 40 - 49
    /// Grade E is Pass          : 38 - 39
    /// Grade F is Fail          :  0 - 37
    /// Grade X is NOT VALID
    /// </summary>
    public enum Grade
    {
        X, F, E, D, C, B, A
    }

    /// <summary>
    /// This class has methods to input a single mark
    /// for a given array of students.  The marks can be dislplayed,
    /// converted to grades, and basic statistics can be calulated
    /// and display as well as a profile showing the percentage
    /// of students getting each of the grades.
    /// 
    /// </summary>
    /// <Author>
    /// Derek Peacock App03: Version 1.0
    /// </Author>
    public class StudentGrades
    {
        public const int LowestMark = 0;
        public const int HighestMark = 100;

        public const int LowestGradeE = 38;
        public const int LowestGradeD = 40;
        public const int LowestGradeC = 50;
        public const int LowestGradeB = 60;
        public const int LowestGradeA = 70;

        public string[] Students { get; set; }

        public int [] Marks { get; set; }

        public int [] GradeProfile { get; set; }

        public double Mean { get; set; }

        public int Minimum { get; set; }

        public int Maximum { get; set; }


        /// <summary>
        /// Class Constructor called when an object 
        /// is created and sets up an array of students.
        /// </summary>
        public StudentGrades()
        {
            Students = new string[]
            {
                "Daniel","Dylan", "Eric",
                "Georgia", "Hasan","Hamza",
                "Jack", "Liam", "Shan",
                "Shamial"
            };

            GradeProfile = new int[(int)Grade.A + 1];
        }


        /// <summary>
        /// Convert a student mark to a grade 
        /// from F (Fail) to A (First Class)
        /// </summary>
        public Grade ConvertToGrade(int mark)
        {
            if (mark >= LowestMark && mark < LowestGradeE)
            {
                return Grade.F;
            }
            else if (mark >= LowestGradeE && mark < LowestGradeD)
            {
                return Grade.E;
            }
            else if (mark >= LowestGradeD && mark < LowestGradeC)
            {
                return Grade.D;
            }
            else if (mark >= LowestGradeC && mark < LowestGradeB)
            {
                return Grade.C;
            }
            else if (mark >= LowestGradeB && mark < LowestGradeA)
            {
                return Grade.B;
            }
            else if (mark >= LowestGradeA && mark <= HighestMark)
            {
                return Grade.A;
            }
            else return Grade.X;
        }

        /// <summary>
        /// Calculate and display the minimum, maximum 
        /// and mean mark for all the students
        /// </summary>
        public void CalculateStats()
        {
            Minimum = Marks[0];
            Maximum = Marks[0];

            double total = 0;

            foreach(int mark in Marks)
            {
                if (mark > Maximum) Maximum = mark;
                if (mark < Minimum) Minimum = mark;
                total += mark;
            }

            Mean = total / Marks.Length;
        }


        /// <summary>
        /// Calculate and display the proportion of 
        /// students achieving each of the grades
        /// </summary>
        public void CalculateGradeProfile()
        {
            for(int i = 0; i < GradeProfile.Length; i++)
            {
                GradeProfile[i] = 0;
            }

            foreach(int mark in Marks)
            {
                Grade grade = ConvertToGrade(mark);
                GradeProfile[(int)grade]++;
            }
        }

        /// <summary>
        /// Input a mark between 0 - 100 for each 
        /// student and store it in the Marks array
        /// </summary>
        public void InputMarks()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// List all the students and display their
        /// name and current mark
        /// </summary>
        public void OutputMarks()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Output the Minimum, Maximum and Mean Mark
        /// </summary>
        public void OutputStats()
        {
            throw new NotImplementedException();
        }


        /// <summary>
        /// List all the students and display their
        /// name, mark and grade
        /// </summary>
        public void OutputGrades()
        {
            throw new NotImplementedException();
        }

        private void OutputGradeProfile()
        {
            Grade grade = Grade.X;
            Console.WriteLine();

            foreach (int count in GradeProfile)
            {
                int percentage = count * 100 / Marks.Length;
                Console.WriteLine($"Grade {grade} {percentage}% Count {count}");
                grade++;
            }

            Console.WriteLine();
        }

        public void OutputMenu()
        {
            string[] choices = {
                "Input Marks",
                "Output Marks",
                "Output Stats",
                "Output Grade Profile",
                "Quit" };

            int choiceNo;

            do
            {
                UserLib.OutputHeading("    Students Grades App");

                choiceNo = UserLib.SelectChoice(choices);

                switch (choiceNo)
                {
                    case 1: InputMarks(); break;
                    case 2: OutputMarks(); break;
                    case 3:
                        CalculateStats();
                        OutputStats(); break;
                    case 4:
                        CalculateGradeProfile();
                        OutputGradeProfile(); break;

                    default:
                        break;
                }

            } while (choiceNo != 5);
        }

    }
}
