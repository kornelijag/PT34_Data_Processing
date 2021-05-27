using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PT34_Data_Processing
{
    class StudentListManager
    {
        private StudentPointManager _studentPointManager = new StudentPointManager();

        /*
        public void AddStudentsAndPointsManually(StudentList studentList) // with homework array
        {
            bool addMoreStudents = true;

            while (addMoreStudents == true)
            {
                // add student 
                Console.WriteLine("Name Surname:");
                string inputNameSurname = Console.ReadLine();
                string[] nameSurname = inputNameSurname.Split(' ');
                studentList.AddStudent(nameSurname[0], nameSurname[1]);

                // add points
                int totalHwNo = studentList.GetLastAddedStudent().GetHwArraySize();
                Console.WriteLine("\nEnter points for each of " + totalHwNo + " homeworks:");
                for (int i = 0; i < totalHwNo; i++)
                {
                    int hwNo = i + 1;
                    Console.WriteLine("\nEnter HW no." + hwNo + " point:");
                    int hwPoint = Convert.ToInt32(Console.ReadLine());
                    studentList.GetLastAddedStudent().HwArr[i] = hwPoint;
                }
                Console.WriteLine("\nEnter exam point:");
                int examPoint = Convert.ToInt32(Console.ReadLine());
                studentList.GetLastAddedStudent().Exam = examPoint;
                Console.WriteLine("\nAdd another student? (y/n)");

                // asking if user wants to add another student
                bool loopContinue = true;
                while (loopContinue)
                {
                    char yn = Console.ReadLine()[0];
                    if (yn == 'y')
                    {
                        addMoreStudents = true;
                        loopContinue = false;
                    }
                    else if (yn == 'n')
                    {
                        addMoreStudents = false;
                        loopContinue = false;
                    }
                    else
                    {
                        loopContinue = true;
                        Console.WriteLine("Invalid option. Type y for yes, n for no.");
                    }
                }
            }
        }
        */

        
        public void AddStudentsAndPointsManually(StudentList studentList) // with homework list
        {
            bool addMoreStudents = true;

            while (addMoreStudents == true) {
                // add student 
                Console.WriteLine("Name Surname:");
                string inputNameSurname = Console.ReadLine();
                string[] nameSurname = inputNameSurname.Split(' ');
                studentList.AddStudent(nameSurname[0], nameSurname[1]);

                // add points
                int hwNo = 0;
                bool addHw = true;
                while(addHw)
                {
                    hwNo += 1;
                    Console.WriteLine("\nEnter HW no." + hwNo + " point:");
                    int hwPoint = Convert.ToInt32(Console.ReadLine());
                    studentList.GetLastAddedStudent().HwList.Add(hwPoint);
                    char yn = 'o';
                    while (yn != 'y' && yn != 'n')
                    {
                        Console.WriteLine("\nDo you want to add more homework? (y/n)");
                        yn = Console.ReadLine()[0];
                        if (yn == 'y')
                        {
                            addHw = true;
                        }
                        else if (yn == 'n')
                        {
                            addHw = false;
                        }
                        else
                        {
                            Console.WriteLine("\nInvalid option. Enter y for yes, n for no.");
                        }
                    }

                }
                Console.WriteLine("\nEnter exam point:");
                int examPoint = Convert.ToInt32(Console.ReadLine());
                studentList.GetLastAddedStudent().Exam = examPoint;
                Console.WriteLine("\nAdd another student? (y/n)");

                // asking if user wants to add another student
                bool loopContinue = true;
                while (loopContinue) 
                {
                    char yn = Console.ReadLine()[0];
                    if (yn == 'y')
                    {
                        addMoreStudents = true;
                        loopContinue = false;
                    }
                    else if (yn == 'n')
                    {
                        addMoreStudents = false;
                        loopContinue = false;
                    }
                    else
                    {
                        loopContinue = true;
                        Console.WriteLine("Invalid option. Type y for yes, n for no.");
                    }
                }
            }
        }
        

        public void AddDefaultStudents(StudentList studentList)
        {
            if (studentList.GetNumberOfStudents() > 0)
            studentList.RemoveAllStudents();

            studentList
                .AddStudent("May", "Keller")
                .AddStudent("Tim", "Rodgers")
                .AddStudent("Amy", "Stewart");
        }

        public void GeneratePointsRandomly(StudentList studentList)
        {
            Random random = new Random();

            // with homework array
            /*
            for (int student = 0; student < studentList.Students.Count; student++)
            {
                // random homework points
                for (int hw = 0; hw < studentList.Students[student].HwArr.Length; hw++)
                    studentList.Students[student].HwArr[hw] = random.Next(4, 10);

                // random exam point
                studentList.Students[student].Exam = random.Next(4, 10);
            }
            */


            // with homework list
            
            for (int student = 0; student < studentList.Students.Count; student++)
            {
                bool hasHw = studentList.Students[student].HwList.Count > 0;

                // random number of homeworks with random points
                if (!hasHw) for (int i = 0; i < random.Next(3, 5); i++) 
                        studentList.Students[student].HwList.Add(random.Next(4, 10));

                // random exam point
                studentList.Students[student].Exam = random.Next(4, 10);
            }
            

            Console.WriteLine("Random HW and exam points have geen generated for all students.");
        }


        public void PrintAllPoints(StudentList studentList) // for testing
        {
            foreach (var stud in studentList.Students)
            {
                _studentPointManager.PrintAllPoints(stud);
            }
        }

    }
}
