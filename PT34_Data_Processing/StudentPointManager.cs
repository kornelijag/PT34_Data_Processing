using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PT34_Data_Processing
{
    class StudentPointManager
    {
        public void PrintAllPoints(Student student) // for testing
        {
            Console.WriteLine("Points of " + student.Name + " " + student.Surname + ":\n");

            PrintHwPoints(student);
            Console.WriteLine();
            Console.WriteLine("Hw average: " + CalculateHwAverage(student));
            Console.WriteLine("Hw median: " + CalculateHwMedian(student));
            Console.WriteLine();
            Console.WriteLine("Exam: " + student.Exam);
            Console.WriteLine("Final point based on average: " + CalculateFinalPointBasedOnAverage(student));
            Console.WriteLine("Final point based on median: " + CalculateFinalPointBasedOnMedian(student));

            Console.WriteLine("----------------------------------------------");

        }

        public void PrintHwPoints(Student student) // for testing
        {
            // if array
            /*
            for (int i = 0; i < student.HwArr.Length; i++)
            {
                int hwNo = i + 1;
                Console.WriteLine("HW no." + hwNo + ": " + student.HwArr[i]);
            }
            */


            // if list
            
            for (int i = 0; i < student.HwList.Count; i++)
            {
                int hwNo = i + 1;
                Console.WriteLine("HW no." + hwNo + ": " + student.HwList[i]);
            }
            

        }

        public double CalculateHwAverage(Student student)
        {
            double hwAverage = 0;


            // with homework array
            /*
            for (int i = 0; i < student.HwArr.Length; i++)
            {
                hwAverage += student.HwArr[i];
            }
            hwAverage /= student.HwArr.Length;
            */

            // with homework list
            
            foreach (var hw in student.HwList)
            {
                hwAverage += hw;
            }
            hwAverage /= student.HwList.Count;
            

            hwAverage = Math.Round(hwAverage, 2, MidpointRounding.AwayFromZero);
            return hwAverage;
        }

        public double CalculateHwMedian(Student student)
        {
            double hwMedian = 0;
            int medianPosition;

            // with homework array
            /*
            int[] sortedHwArr = new int[student.HwArr.Length];
            Array.Copy(student.HwArr, sortedHwArr, student.HwArr.Length); // copying all elements from from _hwArr into sortedHwArr
            Array.Sort(sortedHwArr);

            if (sortedHwArr.Length % 2 == 0)
            {
                medianPosition = sortedHwArr.Length / 2;
                hwMedian = (sortedHwArr[medianPosition-1] + sortedHwArr[medianPosition]) / 2.0;
            }
            else if (sortedHwArr.Length % 2 != 0)
            {
                medianPosition = sortedHwArr.Length / 2;
                hwMedian = sortedHwArr[Convert.ToInt32(medianPosition)];
            }
            */

            // with homework list
            
            List<int> sortedHwList = new List<int>(student.HwList); // shallow copy of _hwList
            sortedHwList.Sort();

            bool hasHw = sortedHwList.Count > 0;

            if (sortedHwList.Count % 2 == 0 && hasHw)
            {
                medianPosition = sortedHwList.Count / 2;
                hwMedian = (sortedHwList[medianPosition - 1] + sortedHwList[medianPosition]) / 2.0;
            }
            else if (sortedHwList.Count % 2 != 0)
            {
                medianPosition = sortedHwList.Count / 2;
                hwMedian = sortedHwList[Convert.ToInt32(medianPosition)];
            }
            

            return hwMedian;
        }

        public double CalculateFinalPointBasedOnAverage(Student student)
        {
            // with hw average

            double hwAverage = CalculateHwAverage(student);
            double finalPoint = 0.3 * hwAverage + 0.7 * student.Exam;

            finalPoint = Math.Round(finalPoint, 2, MidpointRounding.AwayFromZero);
            return finalPoint;
        }

        public double CalculateFinalPointBasedOnMedian(Student student)
        {
            // with hw median

            double hwMedian = CalculateHwMedian(student);
            double finalPoint = 0.3 * hwMedian + 0.7 * student.Exam;

            finalPoint = Math.Round(finalPoint, 2, MidpointRounding.AwayFromZero);
            return finalPoint;
        }
    }
}
