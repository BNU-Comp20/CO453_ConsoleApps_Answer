namespace CO453_ConsoleAppAnswer
{
    public class ExampleClass
    {
        private readonly int mark = 70;
        private string grade;

        public void ConvertMarkToGrade()
        {
            if ((mark >= 70) && (mark <= 100))
            {
                grade = "First Class";
            }
            else if (mark >= 60)
            {
                grade = "Upper Second";
            }
            else if (mark >= 50)
            {
                grade = "Lower Second";
            }
        }

        public void ToGradeFromMark()
        {
            grade = mark switch
            {
                int mark when (mark >= 70) => "First Class",
                int mark when (mark >= 60) => "Upper Second Class",
                int mark when (mark >= 50) => "Lower Second Class",
                int mark when (mark >= 40) => "Third Class",
                _ => "Fail",
            };
        }
    }
}
