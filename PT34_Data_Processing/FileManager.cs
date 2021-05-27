using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PT34_Data_Processing
{
    class FileManager
    {
        public static void WriteToFile(string filePath, int numOfStudents, int numOfHomeworks)
        {
            Console.WriteLine("\nWriting to file started ...");

            TextWriter textWriter = new StreamWriter(filePath, false);

            // creating header
            string header = "Surname Name";
            for (int i = 1; i <= numOfHomeworks; ++i) {
                header += " HW" + i;
            }
            header += " Exam";
            textWriter.WriteLine(header);


            Random random = new Random(); // for random point generation


            int numOfPoints = numOfHomeworks + 1; // total num of points equals number of HW points plus exam point
            for (int i = 0; i < numOfStudents; ++i)
            {
                int studentNum = i + 1;
                string line = "Surname" + studentNum + " " + "Name" + studentNum;
                
                for (int j = 1; j <= numOfPoints; ++j)
                    line += " " + random.Next(4, 10).ToString();
                
                textWriter.WriteLine(line);
            }

            textWriter.Close();

            Console.WriteLine("\nWriting to file finished.");
        }

        public static void ReadFromFile(string filePath, StudentList studentList)
        {
            Console.WriteLine("\nReading from file started ...\n");

            int lineCounter = 0;
            foreach (string line in File.ReadAllLines(filePath))
            {
                lineCounter++;
                if (lineCounter == 1) continue; // skips header line
                string[] strings = line.Split(' ');
                strings = line.Split(' ');
                

                List<int> hwList = new List<int>();
                for (int i = 2; i < strings.Length-1; ++i)
                {
                    hwList.Add(Int32.Parse(strings[i]));
                }

                studentList.AddStudent(strings[0], strings[1], hwList, Int32.Parse(strings[strings.Length-1]));
                
            }
            Console.WriteLine("\nWriting from file ended.");
        }
    }
}
