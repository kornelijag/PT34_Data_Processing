using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PT34_Data_Processing
{
    enum FinalPointCalculationType
    {
        Average,
        Median,
    }
    class StudentFinalPointTableGenerator
    {
        private const string BORDER = "----------------------------------------------";

        public void GenerateTable (StudentList studentList, FinalPointCalculationType type)
        {
            string tableHeader = GenerateHeader(type);
            string tableBody = GenerateBody(studentList, type);
            Console.WriteLine(tableHeader + tableBody + BORDER);
        }
        public string GenerateHeader(FinalPointCalculationType type)
        {
            string avgOrMed = type == FinalPointCalculationType.Average ? "(Avg.)" : "(Med.)";

            String tableHeader = "\n" + BORDER + "\n";
            tableHeader += String.Format("{0,-10}{1,-10}{2,25}", "Surname", "Name", "Final points " + avgOrMed);
            tableHeader += "\n" + BORDER + "\n";

            return tableHeader;
        }

        public string GenerateBody(StudentList studentList, FinalPointCalculationType type)
        {
            StudentPointManager studentPointManager = new StudentPointManager();
            string studentResults = "";

            foreach (var stud in studentList.Students)
            {
                if (type == FinalPointCalculationType.Average)
                {
                    studentResults += GenerateRow(stud, studentPointManager.CalculateFinalPointBasedOnAverage(stud));
                }
                else if (type == FinalPointCalculationType.Median)
                {
                    studentResults += GenerateRow(stud, studentPointManager.CalculateFinalPointBasedOnMedian(stud));
                }

            }

            return studentResults;
        }
        private string GenerateRow(Student stud, double point)
        {
            return String.Format("{0,-10}{1,-10}{2,20}", stud.Surname, stud.Name, point) + "\n";
        }
    }
}
