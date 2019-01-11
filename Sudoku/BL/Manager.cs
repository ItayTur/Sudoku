using Settings;
using Sudoku;
using Sudoku_Wpf_2;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Manager
    {
        SudokuBoard fullSb;
        public string[,] Board;
        Random rand;

        public Manager()
        {
            fullSb = new SudokuBoard();
            rand = new Random();
            Board = new string[Constants.TotalNumbers, Constants.TotalNumbers];
            GetEasy();
        }
        
        private void GetEasy()
        {
            GetBoardByLevel(Constants.EasyAmountVisibels);
        }

        private void GetMedium()
        {
             GetBoardByLevel(Constants.MediumAmountVisibels);
        }

        private void GetHard()
        {
             GetBoardByLevel(Constants.HardAmountVisibels);
        }

        private void GetBoardByLevel(int visibels)
        {
            int[,] BoardCopy = fullSb.board;
            int Invisibels = Constants.TotalCells - visibels;
            for (int i = 0; i < Invisibels; i++)
            {
                int row = rand.Next(Constants.TotalNumbers);
                int col = rand.Next(Constants.TotalNumbers);
                while (BoardCopy[row, col] == 0)
                {
                    row = rand.Next(Constants.TotalNumbers);
                    col = rand.Next(Constants.TotalNumbers);
                }
                BoardCopy[row, col] = 0;

            }
            FillStringBoard(BoardCopy);

        }

        private void FillStringBoard(int[,] BoardCopy)
        {
            for (int row = 0; row < Constants.TotalNumbers; row++)
            {
                for (int col = 0; col < Constants.TotalNumbers; col++)
                {
                    if (BoardCopy[row, col] == 0)
                    {
                        Board[row, col] = "";
                    }
                    else
                        Board[row, col] = BoardCopy[row, col].ToString();
                }
            }
        }
        //public bool IsCorrect(string[,] emptyBoard)
        //{
        //    bool flag=true;
        //    for (int row = 0; row < Constants.TotalNumbers; row++)
        //    {
        //        for (int col = 0; col < Constants.TotalNumbers; col++)
        //        {
        //            if (emptyBoard[row, col] == "" || fullSb.board[row, col] != int.Parse(emptyBoard[row, col]))
        //            {
        //                flag = false;
        //                break;
        //            }
        //        }
        //    }
        //    return flag;
        //}
        public void NewGame(Level level)
        {
            fullSb = new SudokuBoard();
            if (level == Level.Easy)
            {
                GetEasy();
            }
            else if (level == Level.Medium)
            {
                GetMedium();
            }
            else if (level == Level.Hard)
            {
                GetHard();
            }
        }

    }
}
