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
            this.DataContext = this;
            timeLeft = true;
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
            GameLogic.time = 20;
            GameLogic gameLogic = new GameLogic();
            string[] eqnAns = gameLogic.GenerateEquation(round);
            equation = eqnAns[0];
            expectedAnswer = eqnAns[1];
            Score.Content = Convert.ToString(round);
            Equation.Content = equation;
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
                    Answer.Text = "";
                }
                else GameOver();
            }
            else Answer.Text = "";
        }

        private void GameOver()
        {
            Window1 window1 = new Window1();
            window1.Show();
            this.Close();
        }

        // Give Up
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            GameOver();
        }
    }
}
