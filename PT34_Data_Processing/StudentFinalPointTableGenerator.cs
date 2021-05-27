using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PT34_Data_Processing
{
    class StudentFinalPointTableGenerator
    {
        private const string BORDER = "-------------------------------------------------------------------";

        public void GenerateTable (StudentList studentList)
        {
            string tableHeader = GenerateHeader();
            string tableBody = GenerateBody(studentList);

            if (studentList.GetNumberOfStudents() == 0)
                Console.WriteLine("\nNo students have been added yet.");

            Console.WriteLine(tableHeader + tableBody + BORDER);
        }

        public string GenerateHeader()
        {
            String tableHeader = "\n" + BORDER + "\n";
            tableHeader += String.Format("{0,-12}{1,-12}{2,18}{3,23}", "Surname", "Name", "Final points (Avg.)", "Final points (Med.)");
            tableHeader += "\n" + BORDER + "\n";

            return tableHeader;
        }

        public string GenerateBody(StudentList studentList)
        {
            StudentPointManager studentPointManager = new StudentPointManager();
            string studentResults = "";

            List<Student> sortedStudentList = new List<Student>(studentList.Students);

            // sort students by surnames
            sortedStudentList = sortedStudentList.OrderBy(s => s.Surname).ToList();

            // sort students by names
            //sortedStudentList = sortedStudentList.OrderBy(s => s.Name).ToList();

            foreach (var stud in sortedStudentList)
            {
             studentResults += GenerateRow(stud, 
                 studentPointManager.CalculateFinalPointBasedOnAverage(stud), 
                 studentPointManager.CalculateFinalPointBasedOnMedian(stud));
            }

            return studentResults;
        }
        private string GenerateRow(Student stud, double fpBasedOnAvg, double fpBasedOnMed)
        {
            return String.Format("{0,-12}{1,-12}{2,17}{3,22}", stud.Surname, stud.Name, fpBasedOnAvg, fpBasedOnMed) + "\n";
        }
    }
}
