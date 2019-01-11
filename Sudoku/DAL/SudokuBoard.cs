using ConsoleApplication1;
using Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sudoku
{
    public class SudokuBoard
    {
        public int[,] board;
        private Random random;
        private Block upperLeft;
        private Block upperMiddle;
        private Block upperRight;
        private Block MiddleLeft;
        private Block Middle;
        private Block MiddleRight;
        private Block downLeft;
        private Block downMiddle;
        private Block downRight;

        public SudokuBoard()
        {
            board = new int[Constants.TotalNumbers, Constants.TotalNumbers];
            random = new Random();
            upperLeft = new Block();
            upperMiddle = new Block();
            upperRight = new Block();
            MiddleLeft = new Block();
            Middle = new Block();
            MiddleRight = new Block();
            downLeft = new Block();
            downMiddle = new Block();
            downRight = new Block();

            for (int i = 0; i < board.GetLength(0); i++)
            {
                for (int j = 0; j < board.GetLength(1); j++)
                {
                    board[i, j] = 0;
                }
            }
            BoardGenerate();

        }
        private void BoardGenerate()
        {

            int count = 0;
            BoardGenerate(count);
        }

        private bool BoardGenerate(int count)
        {
            bool flag = false;
            if (count >= Constants.TotalCells) flag= true;//The board is full
            else
            {
                int row = count / Constants.TotalNumbers;
                int col = count % Constants.TotalNumbers;
                Candidates candidates = new Candidates();
                while (!candidates.IsEmpty())
                {
                    int num = DrowNumber(candidates);
                    if (Possible(row, col, num))
                    {
                        board[row, col] = num;
                        if (BoardGenerate(++count))
                            flag= true;

                        else
                            RemoveFromBlocks(row, col, num);
                    }
                }
            }
            return flag;
        }


        private int DrowNumber(Candidates candidates)
        {
            int num=0;
            do
            {
                num = random.Next(1, 10);
            } while (!candidates.IsAvilable(num));
            candidates.Remove(num);
            return num;
        }


     

        private bool Possible(int row, int col, int num)
        {
            bool flag = false;
            for (int i = 0; i < Constants.TotalNumbers; i++)
            {
                if (board[row, i] == num) return flag;
                if (board[i, col] == num) return flag;
            }
            if (!IsInBlocks(row, col, num))
            {
                flag = true;
            }
            return flag;
        }


        private bool IsInBlocks(int row, int col, int num)
        {
            bool flag;
            if (row < 3)
            {
                flag = IsInRow(col, num, upperLeft, upperMiddle, upperRight);
            }
            else if (row < 6)
            {
                flag = IsInRow(col, num, MiddleLeft, Middle, MiddleRight);
            }
            else
            {
                flag = IsInRow(col, num, downLeft, downMiddle, downRight);
            }
            return flag;
        }
        

       private bool IsInRow(int col,int num,Block left,Block middle, Block right)
        {
            bool flag = true;
            if (col < 3)
            {
                if (!left.Contains(num))
                {
                    left.Add(num);
                    flag = false;
                }
            }
            else if (col < 6)
            {
                if (!middle.Contains(num))
                {
                    middle.Add(num);
                    flag = false;
                }
            }
            else if (!right.Contains(num))
            {
                right.Add(num);
                flag = false;
            }
            return flag;
        }

        private void RemoveFromBlocks(int row, int col, int num)
        {
            board[row, col] = Constants.EmptyCell;

            if (row < 3)
            {
                BlocksRemove(col, num, upperLeft, upperMiddle, upperRight);
            }
            else if (row < 6)
            {
                BlocksRemove(col, num, MiddleLeft, Middle, MiddleRight);
            }
            else
            {
                BlocksRemove(col, num, downLeft, downMiddle, downRight);
            }
        }

        private void BlocksRemove(int col, int num, Block left, Block middle, Block right)
        {
            if (col < 3)
            {
                left.Remove(num);
            }
            else if (col < 6)
            {
                middle.Remove(num);
            }
            else
            {
                right.Remove(num);
            }
        }


    }
}
