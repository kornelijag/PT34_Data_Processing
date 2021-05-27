using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PT34_Data_Processing
{
    class StudentList
    {
        private List<Student> _students = new List<Student>();

        public List<Student> Students
        {
            get => _students;
        }

        public StudentList AddStudent(string name, string surname)
        {
            _students.Add(new Student(name, surname));
            Console.WriteLine("New student added: " + name + " " + surname);

            return this; // allows AddStudent(...).AddStudent(...).......
        }

        public StudentList AddStudent(string name, string surname, List<int> hwList, int exam)
        {
            _students.Add(new Student(name, surname, hwList, exam));
            string message = "New student added: " + name + " " + surname + " HW: ";

            foreach (var hw in hwList) message += hw + " ";
            
            message += " Exam: " + exam;

            Console.WriteLine(message);
            return this; // allows AddStudent(...).AddStudent(...).......
        }

        public Student GetLastAddedStudent()
        {
            return _students.Last();
        }

        public void RemoveAllStudents()
        {
            _students.Clear();
            Console.WriteLine("The list is cleared.");
        }

        public int GetNumberOfStudents()
        {
            int numOfStud = 0;
            foreach(var stud in _students)
            {
                numOfStud++;
            }
            return numOfStud;
        }

    }
}
