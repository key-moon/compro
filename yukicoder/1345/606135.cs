// detail: https://yukicoder.me/submissions/606135
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
        var nm = Console.ReadLine().Split().Select(int.Parse).ToArray();
        var n = nm[0];
        var m = nm[1];
        var bingo = Enumerable.Repeat(0, n).Select(_ => Console.ReadLine().Split().Select(int.Parse).ToArray()).ToArray();

        static int Solve(int[][] bingo, int norma)
        {
            int res = int.MaxValue / 2;
            int n = bingo.Length;
            for (int b = 0; b < (1 << n); b++)
            {
                int[] cols = new int[n];
                int popcnt = 0;
                for (int i = 0; i < n; i++) popcnt += b >> i & 1;
                if (popcnt + n < norma) continue;
                int sum = 0;
                for (int i = 0; i < n; i++)
                {
                    for (int j = 0; j < n; j++)
                    {
                        if ((b >> i & 1) != 1) cols[j] += bingo[i][j];
                        else sum += bingo[i][j];
                    }
                }
                sum += cols.OrderBy(x => x).Take(norma - popcnt).Sum();
                res = Min(res, sum);
            }
            return res;
        }
        var res = Solve(bingo, m);
        {
            var newBingo1 = bingo.Select(x => x.ToArray()).ToArray();
            var newBingo2 = bingo.Select(x => x.ToArray()).ToArray();
            var newBingo3 = bingo.Select(x => x.ToArray()).ToArray();
            int sum1 = 0;
            int sum2 = 0;
            int sum3 = 0;
            for (int i = 0; i < n; i++)
            {
                sum1 += newBingo1[i][i];
                newBingo1[i][i] = 0;
                sum3 += newBingo3[i][i];
                newBingo3[i][i] = 0;

                sum2 += newBingo2[i][n - i - 1];
                newBingo2[i][n - i - 1] = 0;
                sum3 += newBingo3[i][n - i - 1];
                newBingo3[i][n - i - 1] = 0;
            }
            res = Min(res, Solve(newBingo1, m - 1) + sum1);
            res = Min(res, Solve(newBingo2, m - 1) + sum2);
            if (1 < m) res = Min(res, Solve(newBingo3, m - 2) + sum3);
        }
        Console.WriteLine(res);
    }
}