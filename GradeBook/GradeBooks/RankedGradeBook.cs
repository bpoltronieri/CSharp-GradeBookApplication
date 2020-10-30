using System;
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

        private bool CheckEnoughStudentsConsole()
        {
            if (Students.Count < 5)
            {
                Console.WriteLine("Ranked grading requires at least 5 students with grades in order to properly calculate a student's overall grade.");
                return false;
            }
            return true;
        }

        public override void CalculateStatistics()
        {
            if ( !CheckEnoughStudentsConsole() ) return;
            else base.CalculateStatistics();
        }

        public override void CalculateStudentStatistics(string name)
        {
            if ( !CheckEnoughStudentsConsole() ) return;
            else base.CalculateStudentStatistics(name);
        }

        public override char GetLetterGrade(double averageGrade)
        {
            if (Students.Count < 5)
                throw new System.InvalidOperationException("Ranked grading needs at least 5 students for Ranked Grading.");

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

        public override string ToString()
        {
            return base.ToString();
        }
    }
}