using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PT34_Data_Processing
{
    class StudentManagementMenu
    {
        private StudentListManager _studentListManager = new StudentListManager();

        public void OpenMenu(StudentList studentList)
        {
            int option = 0;
            bool loopContinue = true;
            while (loopContinue)
            {
                switch (option)
                {
                    case 0:
                        Console.WriteLine("Add students and points: (choose option)");
                        Console.WriteLine("1 - Manually");
                        Console.WriteLine("2 - Generate default student list with random points");
                        Console.WriteLine("3 - Back to main menu");
                        Console.WriteLine("\nNote: With 2nd option, the existing student list is first cleared.\n");
                        option = Convert.ToInt32(Console.ReadLine());
                        break;
                    case 1:
                        Console.WriteLine("Option chosen: 1\n");
                        loopContinue = false;
                        _studentListManager.AddStudentsAndPointsManually(studentList);
                        OpenMenu(studentList);
                        break;
                    case 2:
                        Console.WriteLine("Option chosen: 2");
                        loopContinue = false;
                        _studentListManager.AddDefaultStudents(studentList);
                        _studentListManager.GeneratePointsRandomly(studentList);
                        MainMenu.OpenMenu(studentList);
                        break;
                    case 3:
                        Console.WriteLine("Option chosen: 3");
                        loopContinue = false;
                        MainMenu.OpenMenu(studentList);
                        break;
                    default:
                        Console.WriteLine("No such option");
                        option = 0;
                        break;
                }
            }
        }


    }
}
