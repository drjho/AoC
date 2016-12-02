using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AoC.Puzzles
{
    class D1
    {
        static string input = "L5, R1, L5, L1, R5, R1, R1, L4, L1, L3, R2, R4, L4, L1, L1, R2, R4, R3, L1, R4, L4, L5, L4, R4, L5, R1, R5, L2, R1, R3, L2, L4, L4, R1, L192, R5, R1, R4, L5, L4, R5, L1, L1, R48, R5, R5, L2, R4, R4, R1, R3, L1, L4, L5, R1, L4, L2, L5, R5, L2, R74, R4, L1, R188, R5, L4, L2, R5, R2, L4, R4, R3, R3, R2, R1, L3, L2, L5, L5, L2, L1, R1, R5, R4, L3, R5, L1, L3, R4, L1, L3, L2, R1, R3, R2, R5, L3, L1, L1, R5, L4, L5, R5, R2, L5, R2, L1, L5, L3, L5, L5, L1, R1, L4, L3, L1, R2, R5, L1, L3, R4, R5, L4, L1, R5, L1, R5, R5, R5, R2, R1, R2, L5, L5, L5, R4, L5, L4, L4, R5, L2, R1, R5, L1, L5, R4, L3, R4, L2, R3, R3, R3, L2, L2, L2, L1, L4, R3, L4, L2, R2, R5, L1, R2";

        static HashSet<string> coords = new HashSet<string>();

        static int dir, x, y;

        public D1()
        {
            dir = 0;
            x = 0;
            y = 0;
            int steps = 0;
            var inputs = input.Split(',');
            foreach (var s in inputs)
            {
                var str = s.Trim();
                if (str[0] == 'R')
                    dir = (dir == 3) ? 0 : dir + 1;
                else
                    dir = (dir == 0) ? 3 : dir - 1;
                steps = int.Parse(str.Substring(1));

                if (Move(steps).Length > 0)
                    break;
            }
            Console.WriteLine(Distance(x, y));
        }

        string Move(int steps)
        {
            while (steps > 0)
            {
                steps--;
                switch (dir)
                {
                    case 0:
                        y++;
                        break;
                    case 1:
                        x++;
                        break;
                    case 2:
                        y--;
                        break;
                    case 3:
                        x--;
                        break;
                }
                var str = CoordString(x, y);
                if (coords.Contains(str))
                {
                    Console.WriteLine(str);
                    return str;
                }
                else
                    coords.Add(str);
            }
            return "";
        }

        string CoordString(int x, int y)
        {
            return $"{x},{y}";
        }

        int Distance(int x, int y)
        {
            Console.WriteLine(x + "," + y);
            return Math.Abs(x) + Math.Abs(y);
        }
    }
}
