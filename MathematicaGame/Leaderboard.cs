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
        public void UpdateScore(long score, string name)
        {
            List<KeyValuePair < long, string>> board = ReturnLeaderboard();
            board.Remove(board[0]);
            board.Add(KeyValuePair.Create(score, name));
            board = board.OrderBy(kvp => kvp.Key).ToList();
            string tempFilePath = Path.Combine(Path.GetTempPath(), "Score.csv");
            using (StreamWriter sr = new StreamWriter(tempFilePath))
            {
                for (int i = 0;i<10;i++)
                {
                    sr.WriteLine(board[i].Value + "," + Convert.ToString(board[i].Key));
                }
            }
            File.Delete(App.leaderboardPath);
            File.Move(tempFilePath, App.leaderboardPath);
            File.Delete(tempFilePath);
        }
        public List<KeyValuePair<long, string>> ReturnLeaderboard()
        {
            string[] score;
            List<KeyValuePair<long, string>> board = new List<KeyValuePair<long, string>>();
            using(StreamReader reader = new StreamReader(App.leaderboardPath))
            {
                for(int i = 0; i<10; i++)
                {
                    score = reader.ReadLine().Split(',');
                    board.Add(KeyValuePair.Create(Convert.ToInt64(score[1]), score[0]));
                }
            }
            board = board.OrderBy(kvp => kvp.Key).ToList();
            return board;
        }
        public long ReturnMinimumValue()
        {
            return ReturnLeaderboard()[0].Key;
        }
    }
}
