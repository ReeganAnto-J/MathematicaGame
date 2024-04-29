namespace MathematicaGame
{
    class GameLogic
    {
        public string[] GenerateEquation(int x)
        {
            string eqn = "";
            double ans = 0;
            Random random = new Random();
            int rnd;
            if (x <= 5)
            {
                int mod;
                if (x <= 3) mod = 11; else mod = 31;
                rnd = (random.Next() % mod);
                eqn += Convert.ToString(rnd) + "+";
                ans += rnd;
                rnd = (random.Next() % mod);
                eqn += Convert.ToString(rnd);
                ans += rnd;
            }
            else if (x <= 20)
            {
                int mod;
                int sign = random.Next(0, 2);
                if (x <= 10) mod = 31; else if (x <= 15) mod = 71; else mod = 101;
                int v1 = (random.Next(11, mod)), v2 = (random.Next(11, mod));
                if (sign == 1)
                {
                    ans += Math.Max(v1, v2);
                    eqn += Convert.ToString(ans) + "-";
                    ans -= Math.Min(v1, v2);
                    eqn += Convert.ToString(Math.Min(v1, v2));
                }
                else
                {
                    ans += v1;
                    eqn += Convert.ToString(v1) + "+";
                    ans += v2;
                    eqn += Convert.ToString(v2);
                }
            }
            else if (x <= 50)
            {
                int mod, st;
                if (x <= 30) mod = 301; else if (x <= 40) mod = 601; else mod = 1001;
                if (x <= 30) st = 11; else st = 100;
                int v = (random.Next(st, mod));
                ans = v; eqn += Convert.ToString(v);
                for (int i = 0; i < 2; i++)
                {
                    v = (random.Next(st, mod));
                    int sign = random.Next(0, 100);
                    if (sign < 60)
                    {
                        ans += v;
                        eqn += '+' + Convert.ToString(v);
                    }
                    else
                    {
                        ans -= v;
                        eqn += '-' + Convert.ToString(v);
                    }
                }
            }
            else if (x <= 75)
            {
                int mod, st;
                if (x <= 60) mod = 11; else if (x <= 65) mod = 51; else mod = 101;
                if (x <= 65) st = 1; else st = 11;
                int pointOfMul = random.Next(0, 2); // To check if first or second value must be multiplied
                if (pointOfMul == 0)
                {
                    int v = (random.Next(st, mod));
                    int m = (random.Next(1, 10));
                    ans = v * m;
                    eqn += Convert.ToString(v) + "x" + Convert.ToString(m);
                    v = (random.Next(st, mod));
                    int sign = random.Next(0, 2);
                    if (sign == 0)
                    {
                        ans += v;
                        eqn += '+' + Convert.ToString(v);
                    }
                    else
                    {
                        ans -= v;
                        eqn += '-' + Convert.ToString(v);
                    }
                }
                else
                {
                    int v = (random.Next(st, mod));
                    ans = v;
                    eqn += Convert.ToString(v);
                    v = (random.Next(st, mod));
                    int m = (random.Next(1, 10));
                    int sign = random.Next(0, 2);
                    if (sign == 0)
                    {
                        ans += v * m;
                        eqn += '+' + Convert.ToString(v) + "x" + Convert.ToString(m);
                    }
                    else
                    {
                        ans -= v * m;
                        eqn += '-' + Convert.ToString(v) + "x" + Convert.ToString(m);
                    }
                }
            }
            else if (x <= 100)
            {
                int mod = 101, st = 11;
                int mulOrDiv = random.Next(0, 2);
                if (mulOrDiv == 0)
                {
                    int pointOfMul = random.Next(0, 2); // To check if first or second value must be multiplied
                    if (pointOfMul == 0)
                    {
                        int v = (random.Next(st, mod));
                        int m = (random.Next(1, 10));
                        ans = v * m;
                        eqn += Convert.ToString(v) + "x" + Convert.ToString(m);
                        v = (random.Next(st, mod));
                        int sign = random.Next(0, 2);
                        if (sign == 0)
                        {
                            ans += v;
                            eqn += '+' + Convert.ToString(v);
                        }
                        else
                        {
                            ans -= v;
                            eqn += '-' + Convert.ToString(v);
                        }
                    }
                    else
                    {
                        int v = (random.Next(st, mod));
                        ans = v;
                        eqn += Convert.ToString(v);
                        v = (random.Next(st, mod));
                        int m = (random.Next(1, 10));
                        int sign = random.Next(0, 2);
                        if (sign == 0)
                        {
                            ans += v * m;
                            eqn += '+' + Convert.ToString(v) + "x" + Convert.ToString(m);
                        }
                        else
                        {
                            ans -= v * m;
                            eqn += '-' + Convert.ToString(v) + "x" + Convert.ToString(m);
                        }
                    }
                }
                else
                {
                    int pointOfDiv = random.Next(0, 2); // To check if first or second value must be divided
                    if (pointOfDiv == 0)
                    {
                        int d = (random.Next(2, 10));
                        int v = d * (random.Next(st, mod));
                        ans = v / d;
                        eqn += Convert.ToString(v) + "/" + Convert.ToString(d);
                        v = (random.Next(st, mod));
                        int sign = random.Next(0, 2);
                        if (sign == 0)
                        {
                            ans += v;
                            eqn += '+' + Convert.ToString(v);
                        }
                        else
                        {
                            ans -= v;
                            eqn += '-' + Convert.ToString(v);
                        }
                    }
                    else
                    {
                        int v = (random.Next(st, mod));
                        ans = v;
                        eqn += Convert.ToString(v);
                        int d = (random.Next(2, 10));
                        v = d * (random.Next(st, mod));                       
                        int sign = random.Next(0, 2);
                        if (sign == 0)
                        {
                            ans += v / d;
                            eqn += '+' + Convert.ToString(v) + "/" + Convert.ToString(d);
                        }
                        else
                        {
                            ans -= v / d;
                            eqn += '-' + Convert.ToString(v) + "/" + Convert.ToString(d);
                        }
                    }
                }
            }
            else return ["OVER", "OVER"];
            return [eqn, Convert.ToString(ans)];
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
