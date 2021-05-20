using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PT34_Data_Processing
{
    class MainMenu
    {
        public static void OpenMenu(StudentList studentList)
        {
            int option = 0;
            bool loopContinue = true;
            while (loopContinue)
            {
                switch (option)
                {
                    case 0:
                        Console.WriteLine("\nMain menu:");
                        Console.WriteLine("1 - Add students and points"); 
                        Console.WriteLine("2 - View results\n"); // final point table and interim points
                        option = Convert.ToInt32(Console.ReadLine());
                        break;
                    case 1:
                        Console.WriteLine("Option chosen: 1\n");
                        loopContinue = false;
                        StudentManagementMenu studentManagementMenu = new StudentManagementMenu();
                        studentManagementMenu.OpenMenu(studentList);
                        break;
                    case 2:
                        Console.WriteLine("Option chosen: 2");
                        ResultMenu.OpenMenu(studentList); // offers to calculate final point based on average or median
                        StudentListManager studentListManager = new StudentListManager();
                        studentListManager.PrintAllPoints(studentList);
                        OpenMenu(studentList);
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

