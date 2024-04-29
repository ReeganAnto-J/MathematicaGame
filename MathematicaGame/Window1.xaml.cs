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

namespace MathematicaGame
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        // Main Menu
        public Window1()
        {
            InitializeComponent();
        }

        // Play
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Window2 window2 = new Window2(); // Play window
            window2.Show();
            this.Close();
        }

        // Leaderboard
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Window3 window3 = new Window3(); // Leadeboard Window
            window3.Show();
            this.Close();
        }

        // Back
        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }
    }
}
