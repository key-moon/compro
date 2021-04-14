// detail: https://onlinejudge.u-aizu.ac.jp/status/users/keymoon/submissions/1/1179/judge/5374788/C#
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
        int n = int.Parse(Console.ReadLine());
        Dictionary<Tuple<int, int, int>, int> inds = new Dictionary<Tuple<int, int, int>, int>();

        int cur = 0;
        for (int y = 1; y < 1000; y++)
        {
            for (int m = 1; m <= 10; m++)
            {
                bool isBig = y % 3 == 0 || m % 2 == 1;
                for (int d = 1; d <= (isBig ? 20 : 19); d++)
                {
                    cur++;
                    inds[new Tuple<int, int, int>(y, m, d)] = cur;
                }
            }
        }

        for (int i = 0; i < n; i++)
        {
            var ymd = Console.ReadLine().Split().Select(int.Parse).ToArray();
            var y = ymd[0];
            var m = ymd[1];
            var d = ymd[2];
            Console.WriteLine(cur - inds[new Tuple<int, int, int>(y, m, d)] + 1);
        }
    }
}
