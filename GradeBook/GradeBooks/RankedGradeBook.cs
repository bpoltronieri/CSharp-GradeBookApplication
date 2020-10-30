using System.Linq;

using GradeBook.Enums;
using System.Collections.Generic;

namespace GradeBook.GradeBooks
{
    public class RankedGradeBook : BaseGradeBook
    {
        public RankedGradeBook(string name) : base(name)
        {
            Type = GradeBookType.Ranked;
        }

        public override char GetLetterGrade(double averageGrade)
        {
            if (Students.Count < 5)
                throw new System.InvalidOperationException("Need at least 5 students for Ranked Grading.");

            var StudentsPerGrade = Students.Count / 5;
            var i = 0;
            List<Student> SortedStudents = Students.OrderByDescending(o => o.AverageGrade).ToList();
            foreach (var student in SortedStudents)
            {
                if (student.AverageGrade <= averageGrade) break;
                i += 1;
            }
            switch (i / StudentsPerGrade)
            {
                case 0:
                    return 'A';
                case 1:
                    return 'B';
                case 2:
                    return 'C';
                case 3:
                    return 'D';
                default:
                    break;
            }
            return 'F';
        }

    }
}