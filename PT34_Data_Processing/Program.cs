// Practical tasks 3-4 by Kornelija Gasparaityte iifu-17

using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PT34_Data_Processing
{

    class Program
    {

        static void Main(string[] args)
        {
            // for v0.4
            /*
            String filePath = @"D:\Desktop\VGTU\VGTU 8th sem\Integrated Development Environments\Homework\HW3-4\PT34_Data_Processing\students2.txt";
            FileManager.WriteToFile(filePath, 10, 5);
            */

            StudentList students = new StudentList();
            MainMenu.OpenMenu(students);

        }
    }
}
