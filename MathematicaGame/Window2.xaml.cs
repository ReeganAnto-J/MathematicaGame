using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
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
    /// Interaction logic for Window2.xaml
    /// </summary>
    public partial class Window2 : Window
    {
        public int round = 1;
        string answerBox = "", expectedAnswer = "", equation = "";
        static bool timeLeft;
        Thread timerThread;
        long score = 0;

        public Window2()
        {
            InitializeComponent();
            Name.Visibility = Visibility.Collapsed;
            Enter.Visibility = Visibility.Collapsed;
            this.DataContext = this;
            timeLeft = true;
            Points.Content = Convert.ToString(score);
            timerThread = new Thread(TimerManager);
            NextRound();
            timerThread.Start();
        }

        void TimerManager()
        {
            while(timeLeft)
            {
                if (GameLogic.time <= 0)
                {
                    timeLeft = false;
                }
                else
                {
                    GameLogic.Timer();
                }
            }
        }

        public void NextRound()
        {
            // Getting the equation and expected answer
            if (round >= 101) GameOver();
            GameLogic.time = 20;
            GameLogic gameLogic = new GameLogic();
            string[] eqnAns = gameLogic.GenerateEquation(round);
            equation = eqnAns[0];
            expectedAnswer = eqnAns[1];
            Score.Content = Convert.ToString(round);
            Equation.Content = equation;
            Answer.Text = Convert.ToString(expectedAnswer);
        }

        // Submit
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if(!timeLeft) { GameOver(); }
            answerBox = Answer.Text;
            int userAnswer, actualAnswer = int.Parse(expectedAnswer);
            if (int.TryParse(answerBox, out userAnswer))
            {
                if (userAnswer == actualAnswer)
                {
                    score += GameLogic.time * round;
                    round++;
                    NextRound();
                    //Answer.Text = "";
                    Points.Content = Convert.ToString(score);
                }
                else GameOver();
            }
            //else Answer.Text = "";
        }

        private void Enter_Click(object sender, RoutedEventArgs e)
        {
            Leaderboard leaderboard = new Leaderboard();
            leaderboard.UpdateScore(score, Name.Text);
            Window3 window = new Window3();
            window.Show();
            this.Close();
        }

        private void GameOver()
        {
            Leaderboard leaderboard = new Leaderboard();
            if(score > leaderboard.ReturnMinimumValue())
            {
                Submit.Visibility = Visibility.Collapsed;
                GiveUp.Visibility = Visibility.Collapsed;
                Round.Visibility = Visibility.Collapsed;
                Score.Visibility = Visibility.Collapsed;
                Equation.Visibility = Visibility.Collapsed;
                Answer.Visibility = Visibility.Collapsed;
                Name.Visibility = Visibility.Visible;
                Enter.Visibility = Visibility.Visible;
                Points.Content = Convert.ToString(score);
            }
            else
            {
                Window1 window1 = new Window1();
                window1.Show();
                this.Close();
            }
        }

        // Give Up
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            GameOver();
        }
    }
}
