using System;
using System.Collections.Generic;
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

namespace TicTacToe
{

    enum WeekDay { Sunday, Monday, Tuesday, Wednesday, Thursday, Friday, Saturday };

    enum Player { Empty, X, O };

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public void TestMe()
        {
            WeekDay day;
            day = WeekDay.Monday;
            int dayNumber = (int)day;
            string dayName = day.ToString();

            if (day == WeekDay.Tuesday)
            {

            }
        }


        // Model - status of the game
        Player[,] board = new Player[3, 3];
        int turnCount = 0;
        // UI - references to 9 buttons of the board
        Button[,] boardOfButtons = new Button[3, 3];

        public MainWindow()
        {
            InitializeComponent();            
            // remember button references in an array for easy use
            boardOfButtons[0, 0] = bt00;
            boardOfButtons[0, 1] = bt01;
            boardOfButtons[0, 2] = bt02;
            boardOfButtons[1, 0] = bt10;
            boardOfButtons[1, 1] = bt11;
            boardOfButtons[1, 2] = bt12;
            boardOfButtons[2, 0] = bt20;
            boardOfButtons[2, 1] = bt21;
            boardOfButtons[2, 2] = bt22;
            //
            resetBoard();
        }


        private void bt00_Click(object sender, RoutedEventArgs e)
        {
            click(0, 0);
        }

        private void bt01_Click(object sender, RoutedEventArgs e)
        {
            click(0, 1);
        }

        private void bt02_Click(object sender, RoutedEventArgs e)
        {
            click(0, 2);
        }

        private void bt10_Click(object sender, RoutedEventArgs e)
        {
            click(1, 0);
        }

        private void bt11_Click(object sender, RoutedEventArgs e)
        {
            click(1, 1);
        }

        private void bt12_Click(object sender, RoutedEventArgs e)
        {
            click(1, 2);
        }

        private void bt20_Click(object sender, RoutedEventArgs e)
        {
            click(2, 0);
        }

        private void bt21_Click(object sender, RoutedEventArgs e)
        {
            click(2, 1);
        }

        private void bt22_Click(object sender, RoutedEventArgs e)
        {
            click(2, 2);
        }

        private void click(int row, int col)
        {
            if (board[row, col] != Player.Empty)
            {
                return;
            }
            turnCount++;
            lblTurnCount.Content = turnCount;

            if (turnCount % 2 == 0)
            { // O
                boardOfButtons[row, col].Content = "O";
                board[row, col] = Player.O;
                if (isPlayerWinner(Player.O))
                {
                    string name = tbPlayerOName.Text;
                    MessageBox.Show(name + " won in " + turnCount + " total playing O",
                    "Game over", MessageBoxButton.OK, MessageBoxImage.Information);
                    resetBoard();
                    return;
                }
            }
            else
            { // X
                boardOfButtons[row, col].Content = "X";
                board[row, col] = Player.X;
                if (isPlayerWinner(Player.X))
                {
                    string name = tbPlayerXName.Text;
                    MessageBox.Show(name + " won in " + turnCount + " total playing X",
                    "Game over", MessageBoxButton.OK, MessageBoxImage.Information);
                    resetBoard();
                    return;
                }
            }
            //
            if (turnCount == 9)
            {
                MessageBox.Show("No winner - draw", "Game over",
                    MessageBoxButton.OK, MessageBoxImage.Information);
                resetBoard();
            }
        }

        private void resetBoard()
        {
            turnCount = 0;
            lblTurnCount.Content = turnCount;
            // reset the board
            for (int row = 0; row < 3; row++)
                for (int col = 0; col < 3; col++)
                {
                    board[row, col] = Player.Empty;
                    boardOfButtons[row, col].Content = "";                    
                }
        }

        private bool isPlayerWinner(Player player)
        {
            // test columns
            for (int col = 0; col < 3; col++)
            {
                if ((board[0, col] == player) &&
                   (board[1, col] == player) &&
                   (board[2, col] == player))
                {
                    return true;
                }
            }
            // test rows
            for (int row = 0; row < 3; row++)
            {
                if ((board[row, 0] == player) &&
                    (board[row, 1] == player) &&
                    (board[row, 2] == player))
                {
                    return true;
                }
            }
            // test across
            if ((board[0, 0] == player) &&
                (board[1, 1] == player) &&
                (board[2, 2] == player))
            {
                return true;
            }
            if ((board[0, 2] == player) &&
                (board[1, 1] == player) &&
                (board[2, 0] == player))
            {
                return true;
            }
            //
            return false;
        }

        private void Restart_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show(
                "Are you sure you want to reset the game?", "Reset game?",
                    MessageBoxButton.OKCancel, MessageBoxImage.Question);
            if (result == MessageBoxResult.OK)
            {
                resetBoard();
            }
        }
    }
}
