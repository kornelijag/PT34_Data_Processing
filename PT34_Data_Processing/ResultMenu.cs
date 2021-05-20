using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PT34_Data_Processing
{
    class ResultMenu
    {

        public static void OpenMenu(StudentList studentList)
        {
            StudentFinalPointTableGenerator tableGenerator = new StudentFinalPointTableGenerator();

            int option = 0;

            bool loopContinue = true;
            while (loopContinue)
            {
                switch (option)
                {
                    case 0:
                        Console.WriteLine("Calculate final point based on: (Choose option)");
                        Console.WriteLine("1 - Average");
                        Console.WriteLine("2 - Median\n");
                        option = Convert.ToInt32(Console.ReadLine());
                        break;
                    case 1:
                        Console.WriteLine("Option chosen: 1");
                        tableGenerator.GenerateTable(studentList, FinalPointCalculationType.Average);
                        loopContinue = false;
                        break;
                    case 2:
                        Console.WriteLine("Option chosen: 2");
                        tableGenerator.GenerateTable(studentList, FinalPointCalculationType.Median);
                        loopContinue = false;
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
