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

        public void resetBoardAndButtons()
        {
            // reset the board
            for (int row = 0; row < 3; row++)
                for (int col = 0; col < 3; col++)
                    board[row, col] = Player.Empty;
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
            //for (int row = 0; row < 3; row++)
            //    for (int col = 0; col < 3; col++)
            //        (bt + row + col).ToString().Content = "";
            bt00.Content = "";
            bt01.Content = "";
            bt02.Content = "";
            bt10.Content = "";
            bt11.Content = "";
            bt12.Content = "";
            bt20.Content = "";
            bt21.Content = "";
            bt22.Content = "";
        }
        public MainWindow()
        {
            InitializeComponent();
            resetBoardAndButtons();
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
                    // SHOW DIALOG BOX
                    MessageBox.Show(txtPlayerO.Text + " won in " + turnCount + " moves total playing O", "Game over",
                        MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
            else
            { // X
                boardOfButtons[row, col].Content = "X";
                board[row, col] = Player.X;
                if (isPlayerWinner(Player.X))
                {
                    // SHOW DIALOG BOX
                    MessageBox.Show(txtPlayerX.Text + " won in " + turnCount + " moves total playing X", "Game over",
                        MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
            //
            if (turnCount == 9)
            {
                MessageBox.Show("No winner - draw", "Game over",
                    MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        private bool isPlayerWinner(Player player)
        {
            // HOMEWORK - implement this!
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (
                         (board[0, 0] == player && board[0, 1] == player && board[0, 2] == player) ||
                         (board[1, 0] == player && board[1, 1] == player && board[1, 2] == player) ||
                         (board[2, 0] == player && board[2, 1] == player && board[2, 2] == player) ||

                         (board[0, 0] == player && board[1, 1] == player && board[2, 2] == player) ||

                         (board[0, 0] == player && board[1, 1] == player && board[2, 2] == player) ||

                         (board[0, 0] == player && board[1, 0] == player && board[2, 0] == player) ||
                         (board[0, 1] == player && board[1, 1] == player && board[2, 1] == player) ||
                         (board[0, 2] == player && board[1, 2] == player && board[2, 2] == player)

                        )
                        return true;
                }
            }
            return false;
        }

        private void Restart_Click(object sender, RoutedEventArgs e)
        {
            // 1. reset count to 0 and show it
            turnCount = 0;
            lblTurnCount.Content = turnCount;
            // 2. reset board to empty and boardButtons to empty as well
            resetBoardAndButtons();
        }
    }
}
