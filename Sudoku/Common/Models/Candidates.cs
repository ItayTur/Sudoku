using Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    public class Candidates
    {
        public bool[] array;
        int avilableCounter;


        public Candidates()
        {
            array = new bool[10];
            avilableCounter = Constants.TotalNumbers;
            FillArray();
        }


        private void FillArray()
        {
            for (int i = 1; i < array.Length; i++)
            {
                array[i] = true;
            }
        }


        public void Remove(int num)
        {
            array[num] = false;
            avilableCounter--;
        }


        public int GetLength()
        {
            return array.Length;
        }


        public bool IsEmpty()
        {
            return avilableCounter == 0;
        }


        public bool IsAvilable(int num)
        {
            bool flag = false;
            if (array[num] == true)
            {
                flag = true;
            }
            return flag;
        }
    }
}
