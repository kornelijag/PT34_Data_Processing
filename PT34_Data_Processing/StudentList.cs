using System;
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

            return this; // allows studman.AddStudent(...).AddStudent(...).......
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

        public int ReturnNumberOfStudents()
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
