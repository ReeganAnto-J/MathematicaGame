using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathematicaGame
{
    class Leaderboard
    {

        public void UpdateScore(int score, string name)
        {
            
        }
        public SortedDictionary<int, string> ReturnLeaderboard()
        {
            string[] score;
            SortedDictionary<int, string> board = new SortedDictionary<int, string>();
            using(StreamReader reader = new StreamReader(App.leaderboardPath))
            {
                for(int i = 0; i<10; i++)
                {
                    score = reader.ReadLine().Split(',');
                    board[Convert.ToInt32(score[1])] = score[0];
                }
            }
            return board;
        }
    }
}
