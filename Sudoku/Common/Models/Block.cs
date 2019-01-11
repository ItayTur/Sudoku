using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Settings;

namespace ConsoleApplication1
{
    public class Block
    {
        int[] cells;
        public Block()
        {
            cells = new int[Constants.TotalNumbers];
        }
        public bool Contains(int num)
        {
            bool flag = false;
            for (int i = 0; i < cells.Length; i++)
            {
                if (cells[i] == num)
                {
                    flag = true;
                    break;
                }
            }
            return flag;
        }
        public void Add(int num)
        {
            for (int i = 0; i < cells.Length; i++)
            {
                if (cells[i] == 0)
                {
                    cells[i] = num;
                    return;
                }
            }
        }
        public void Remove(int num)
        {
            for (int i = 0; i < cells.Length; i++)
            {
                if (cells[i] == num)
                {
                    cells[i] = 0;
                    return;
                }
            }
        }
    }
}
