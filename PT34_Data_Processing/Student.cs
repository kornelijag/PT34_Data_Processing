using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PT34_Data_Processing
{
    class Student
    {
        public Student(string name, string surname)
        {
            Name = name;
            Surname = surname;
        }


        private string _name;
        public string Name
        {
            get => _name;
            set => _name = value;
        }


        private string _surname;
        public string Surname
        {
            get => _surname;
            set => _surname = value;
        }


        private int _exam;
        public int Exam
        {
            get => _exam;
            set => _exam = value;
        }

        // Homework as an array
        /*
        private int[] _hwArr = new int[4];

        public int[] HwArr
        {
            get => _hwArr;
            set => _hwArr = value;
        }

        // when homework is an array
        public int GetHwArraySize()
        {
            return _hwArr.Length;
        }
        */
        
        //Homework as a list
        
        private List<int> _hwList = new List<int>();
        public List<int> HwList
        {
            get => _hwList;
            set => _hwList = value;
        }
        
    }
}
