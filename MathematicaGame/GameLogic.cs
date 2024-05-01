namespace MathematicaGame
{
    class GameLogic
    {
        public string[] GenerateEquation(int roundNumber)
        {
            string generatedEquation = "";
            double solution = 0;
            Random random = new Random();
            int randomNumber;
            if (roundNumber <= 5)
            {
                int mod;
                if (roundNumber <= 3) mod = 11; else mod = 31;
                randomNumber = (random.Next() % mod);
                generatedEquation += Convert.ToString(randomNumber) + "+";
                solution += randomNumber;
                randomNumber = (random.Next() % mod);
                generatedEquation += Convert.ToString(randomNumber);
                solution += randomNumber;
            }
            else if (roundNumber <= 20)
            {
                int mod;
                int sign = random.Next(0, 2);
                if (roundNumber <= 10) mod = 31; else if (roundNumber <= 15) mod = 71; else mod = 101;
                int v1 = (random.Next(11, mod)), v2 = (random.Next(11, mod));
                if (sign == 1)
                {
                    solution += Math.Max(v1, v2);
                    generatedEquation += Convert.ToString(solution) + "-";
                    solution -= Math.Min(v1, v2);
                    generatedEquation += Convert.ToString(Math.Min(v1, v2));
                }
                else
                {
                    solution += v1;
                    generatedEquation += Convert.ToString(v1) + "+";
                    solution += v2;
                    generatedEquation += Convert.ToString(v2);
                }
            }
            else if (roundNumber <= 50)
            {
                int mod, startingValue;
                if (roundNumber <= 30) mod = 301; else if (roundNumber <= 40) mod = 601; else mod = 1001;
                if (roundNumber <= 30) startingValue = 11; else startingValue = 100;
                int v = (random.Next(startingValue, mod));
                solution = v; generatedEquation += Convert.ToString(v);
                for (int i = 0; i < 2; i++)
                {
                    v = (random.Next(startingValue, mod));
                    int sign = random.Next(0, 100);
                    if (sign < 60)
                    {
                        solution += v;
                        generatedEquation += '+' + Convert.ToString(v);
                    }
                    else
                    {
                        solution -= v;
                        generatedEquation += '-' + Convert.ToString(v);
                    }
                }
            }
            else if (roundNumber <= 75)
            {
                int mod, startingValue;
                if (roundNumber <= 60) mod = 11; else if (roundNumber <= 65) mod = 51; else mod = 101;
                if (roundNumber <= 65) startingValue = 1; else startingValue = 11;
                int pointOfMul = random.Next(0, 2); // To check if first or second value must be multiplied
                if (pointOfMul == 0)
                {
                    int v = (random.Next(startingValue, mod));
                    int m = (random.Next(1, 10));
                    solution = v * m;
                    generatedEquation += Convert.ToString(v) + "x" + Convert.ToString(m);
                    v = (random.Next(startingValue, mod));
                    int sign = random.Next(0, 2);
                    if (sign == 0)
                    {
                        solution += v;
                        generatedEquation += '+' + Convert.ToString(v);
                    }
                    else
                    {
                        solution -= v;
                        generatedEquation += '-' + Convert.ToString(v);
                    }
                }
                else
                {
                    int v = (random.Next(startingValue, mod));
                    solution = v;
                    generatedEquation += Convert.ToString(v);
                    v = (random.Next(startingValue, mod));
                    int m = (random.Next(1, 10));
                    int sign = random.Next(0, 2);
                    if (sign == 0)
                    {
                        solution += v * m;
                        generatedEquation += '+' + Convert.ToString(v) + "x" + Convert.ToString(m);
                    }
                    else
                    {
                        solution -= v * m;
                        generatedEquation += '-' + Convert.ToString(v) + "x" + Convert.ToString(m);
                    }
                }
            }
            else if (roundNumber <= 100)
            {
                int mod = 101, startingValue = 11;
                int mulOrDiv = random.Next(0, 2);
                if (mulOrDiv == 0)
                {
                    int pointOfMul = random.Next(0, 2); // To check if first or second value must be multiplied
                    if (pointOfMul == 0)
                    {
                        int v = (random.Next(startingValue, mod));
                        int m = (random.Next(1, 10));
                        solution = v * m;
                        generatedEquation += Convert.ToString(v) + "x" + Convert.ToString(m);
                        v = (random.Next(startingValue, mod));
                        int sign = random.Next(0, 2);
                        if (sign == 0)
                        {
                            solution += v;
                            generatedEquation += '+' + Convert.ToString(v);
                        }
                        else
                        {
                            solution -= v;
                            generatedEquation += '-' + Convert.ToString(v);
                        }
                    }
                    else
                    {
                        int v = (random.Next(startingValue, mod));
                        solution = v;
                        generatedEquation += Convert.ToString(v);
                        v = (random.Next(startingValue, mod));
                        int m = (random.Next(1, 10));
                        int sign = random.Next(0, 2);
                        if (sign == 0)
                        {
                            solution += v * m;
                            generatedEquation += '+' + Convert.ToString(v) + "x" + Convert.ToString(m);
                        }
                        else
                        {
                            solution -= v * m;
                            generatedEquation += '-' + Convert.ToString(v) + "x" + Convert.ToString(m);
                        }
                    }
                }
                else
                {
                    int pointOfDiv = random.Next(0, 2); // To check if first or second value must be divided
                    if (pointOfDiv == 0)
                    {
                        int d = (random.Next(2, 10));
                        int v = d * (random.Next(startingValue, mod));
                        solution = v / d;
                        generatedEquation += Convert.ToString(v) + "/" + Convert.ToString(d);
                        v = (random.Next(startingValue, mod));
                        int sign = random.Next(0, 2);
                        if (sign == 0)
                        {
                            solution += v;
                            generatedEquation += '+' + Convert.ToString(v);
                        }
                        else
                        {
                            solution -= v;
                            generatedEquation += '-' + Convert.ToString(v);
                        }
                    }
                    else
                    {
                        int v = (random.Next(startingValue, mod));
                        solution = v;
                        generatedEquation += Convert.ToString(v);
                        int d = (random.Next(2, 10));
                        v = d * (random.Next(startingValue, mod));                       
                        int sign = random.Next(0, 2);
                        if (sign == 0)
                        {
                            solution += v / d;
                            generatedEquation += '+' + Convert.ToString(v) + "/" + Convert.ToString(d);
                        }
                        else
                        {
                            solution -= v / d;
                            generatedEquation += '-' + Convert.ToString(v) + "/" + Convert.ToString(d);
                        }
                    }
                }
            }
            else return ["OVER", "OVER"];
            return [generatedEquation, Convert.ToString(solution)];
        }

        public static void SetTimerValue(int round)
        {
            if (round <= 10) time = 20;
            else if (round <= 20) time = 30;
            else if (round <= 50) time = 45;
            else time = 60;
        }
        public static int time = 20;
        public static void Timer()
        {
            time--;
            Thread.Sleep(1000);
        }
    }
}
