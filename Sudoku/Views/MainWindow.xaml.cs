using ConsoleApplication1;
using Settings;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Sudoku_Wpf_2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Button choise;
        Manager manager;
        Level CurrentLvl;
        string[,] EmptyBoard;
        public MainWindow()
        {
            InitializeComponent();
            manager = new Manager();
            EmptyBoard = new string[Constants.TotalNumbers, Constants.TotalNumbers];
            FillButtons();
            CurrentLvl = Level.Easy;
        }

        private void FillButtons()
        {
            string num, btnName;
            int index;
            Button item;
            for (int row = 0; row < Constants.TotalNumbers; row++)
            {
                for (int col = 0; col < Constants.TotalNumbers; col++)
                {
                    num = manager.Board[row, col];
                    index = Constants.TotalNumbers * row + col;
                    btnName = "btn" + index;
                    item = this.FindName(btnName) as Button;
                    item.Content = num;
                    EmptyBoard[row, col] = num;
                    item.Click += btn_Click;
                }
            }
        }

       
        private void btn_Click(object sender, RoutedEventArgs e)
        {
            
            spOption.Visibility = Visibility.Visible;
            choise = sender as Button;
           
        }

        private void Option_Click(object sender, RoutedEventArgs e)
        {
            string index;
            int intIndex,rowIndex,colIndex;
            Button item = sender as Button;
            choise.Content= item.Content;
            index = choise.Name.Remove(0,3);
            intIndex = int.Parse(index);
            rowIndex = intIndex/ Constants.TotalNumbers;
            colIndex=intIndex% Constants.TotalNumbers;
            EmptyBoard[rowIndex, colIndex] = choise.Content.ToString();
            spOption.Visibility = Visibility.Hidden;
            
        }

        private void btnNewGame_Click(object sender, RoutedEventArgs e)
        {
            manager.NewGame(CurrentLvl);
            FillButtons();
        }

        private void btnEasy_Click(object sender, RoutedEventArgs e)
        {
            btnEasy.IsEnabled = false;
            btnMedium.IsEnabled = true;
            btnHard.IsEnabled = true;

            CurrentLvl = Level.Easy;
            manager.NewGame(CurrentLvl);
            FillButtons();
        }

        private void btnMedium_Click(object sender, RoutedEventArgs e)
        {
            btnEasy.IsEnabled = true;
            btnMedium.IsEnabled = false;
            btnHard.IsEnabled = true;

            CurrentLvl = Level.Medium;
            manager.NewGame(CurrentLvl);
            FillButtons();
        }

        private void btnHard_Click(object sender, RoutedEventArgs e)
        {
            btnEasy.IsEnabled = true;
            btnMedium.IsEnabled = true;
            btnHard.IsEnabled = false;

            CurrentLvl = Level.Hard;
            manager.NewGame(CurrentLvl);
            FillButtons();
        }

        //private void btnCheck_Click(object sender, RoutedEventArgs e)
        //{
        //    if (manager.IsCorrect(EmptyBoard))
        //        MessageBox.Show("Yes!");
        //    else
        //        MessageBox.Show("No!");
        //}
    }
}
