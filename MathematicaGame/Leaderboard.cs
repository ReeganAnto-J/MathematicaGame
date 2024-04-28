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
        string file = "Score.csv";
        string tempFilePath;
        Leaderboard() 
        { 
        }

        public void UpdateScore()
        {
            tempFilePath = Path.GetTempFileName();
        }
    }
}
