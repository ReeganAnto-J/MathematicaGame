﻿using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MathematicaGame
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        // Opening Window
        public MainWindow()
        {
            InitializeComponent();
        }

        //Start Button
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Window1 window1 = new Window1(); // Main Menu
            window1.Show();
            this.Close();
        }

        // Exit Button
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}