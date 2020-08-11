using Microsoft.VisualStudio.TestTools.UnitTesting;
using CO453_ConsoleAppAnswer.App03;


namespace ConsoleApp.UnitTest
{
    [TestClass]
    public class StudentGradesTest
    {
        private readonly StudentGrades 
            studentGrades = new StudentGrades();
        
        private readonly int[] StatsMarks = new int[]
        {
            10, 20, 30, 40, 50, 60, 70, 80, 90, 100
        };


        [TestMethod]
        public void TestConvertToGrade()
        {
            // Arrange

            int[] marks = new int[]
            {
                0,  37, 38, 39, 40, 49, 
                50, 59, 60, 69, 70, 100
            };

            Grade[] grades = new Grade[]
            {
                        Grade.F, Grade.F,
                        Grade.E, Grade.E,
                        Grade.D, Grade.D,
                        Grade.C, Grade.C,
                        Grade.B, Grade.B,
                        Grade.A, Grade.A
            };

            // Act

            bool allGradesCorrect = true;
            
            for(int markNo = 0; markNo < marks.Length; markNo++)
            {
                Grade grade = studentGrades.ConvertToGrade(marks[markNo]);
                
                if (grade != grades[markNo])
                    allGradesCorrect = false;
            }

            // Assert

           Assert.IsTrue(allGradesCorrect);
        }


        [TestMethod]
        public void TestMarkStats()
        {
            // Arrange

            studentGrades.Marks = StatsMarks;

            double expectedMean = 55.0;
            int expectedMin = 10;
            int expectedMax = 100;

            // Act

            studentGrades.CalculateStats();

            // Assert

            Assert.AreEqual(expectedMean, studentGrades.Mean);
            Assert.AreEqual(expectedMin, studentGrades.Minimum);
            Assert.AreEqual(expectedMax, studentGrades.Maximum);
        }


        [TestMethod]
        public void TestGradeProfile()
        {
            // Arrange

            studentGrades.Marks = StatsMarks;
            bool expectedProfile;
            
            // Act

            studentGrades.CalculateGradeProfile();

            expectedProfile = ((studentGrades.GradeProfile[0] == 0) &&
                               (studentGrades.GradeProfile[1] == 3) &&
                               (studentGrades.GradeProfile[2] == 0) &&
                               (studentGrades.GradeProfile[3] == 1) &&
                               (studentGrades.GradeProfile[4] == 1) &&
                               (studentGrades.GradeProfile[5] == 1) &&
                               (studentGrades.GradeProfile[6] == 4));

            // Assert

            Assert.IsTrue(expectedProfile);
        }


    }
}
