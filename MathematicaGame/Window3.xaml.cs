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
using System.Windows.Shapes;
using static System.Formats.Asn1.AsnWriter;

namespace MathematicaGame
{
    /// <summary>
    /// Interaction logic for Window3.xaml
    /// </summary>
    public partial class Window3 : Window
    {
        public Window3()
        {
            InitializeComponent();
            this.DataContext = this;
            DisplayBoard();
        }

        private void DisplayBoard()
        {
            Leaderboard leaderboard = new Leaderboard();
            List<KeyValuePair<long, string>> board = leaderboard.ReturnLeaderboard();
            N1.Content = board[9].Value;
            S1.Content = Convert.ToString(board[9].Key);
            N2.Content = board[8].Value;
            S2.Content = Convert.ToString(board[8].Key);
            N3.Content = board[7].Value;
            S3.Content = Convert.ToString(board[7].Key);
            N4.Content = board[6].Value;
            S4.Content = Convert.ToString(board[6].Key);
            N5.Content = board[5].Value;
            S5.Content = Convert.ToString(board[5].Key);
            N6.Content = board[4].Value;
            S6.Content = Convert.ToString(board[4].Key);
            N7.Content = board[3].Value;
            S7.Content = Convert.ToString(board[3].Key);
            N8.Content = board[2].Value;
            S8.Content = Convert.ToString(board[2].Key);
            N9.Content = board[1].Value;
            S9.Content = Convert.ToString(board[1].Key);
            N10.Content = board[0].Value;
            S10.Content = Convert.ToString(board[0].Key);
        }

        // Back
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Window1 window1 = new Window1();
            window1.Show();
            this.Close();
        }
    }
}
