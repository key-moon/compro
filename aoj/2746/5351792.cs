// detail: https://onlinejudge.u-aizu.ac.jp/status/users/keymoon/submissions/1/2746/judge/5351792/C#
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using static System.Math;
public static class P
{
    public static void Main()
    {
        while (true)
        {
            var s = Console.ReadLine();
            if (s == "#") break;
            var board = s.Split('/').Select(x =>
                    x.SelectMany(y =>
                        char.IsDigit(y) ? Enumerable.Repeat('.', y - '0') : Enumerable.Repeat(y, 1)
                ).ToArray()
            ).ToArray();
            var op = Console.ReadLine().Split().Select(x => int.Parse(x) - 1).ToArray();
            board[op[0]][op[1]] = '.';
            board[op[2]][op[3]] = 'b';
            var res = string.Join("/", board.Select(x =>
            {
                string row = "";
                int streak = 0;
                foreach (var c in x)
                {
                    if (c != '.')
                    {
                        if (streak != 0) row += streak;
                        streak = 0;
                        row += c;
                    }
                    else
                    {
                        streak++;
                    }
                }
                if (streak != 0) row += streak;
                return row;
            }));
            Console.WriteLine(res);
        }
    }
}
