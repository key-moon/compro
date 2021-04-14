// detail: https://onlinejudge.u-aizu.ac.jp/status/users/keymoon/submissions/1/1600/judge/5374568/C#
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
            var input = Console.ReadLine().Split().Select(int.Parse).ToArray();
            var m = input[0];
            var nmin = input[1];
            var nmax = input[2];
            if (m == 0) break;
            var p = Enumerable.Repeat(0, m).Select(_ => int.Parse(Console.ReadLine())).ToArray();
            var sorted = p.OrderByDescending(x => x).ToArray();
            int maxN = -1;
            int maxGap = -1;
            for (int n = nmin; n <= nmax; n++)
            {
                var gap = sorted[n - 1] - sorted[n];
                if (maxGap <= gap)
                {
                    maxN = n;
                    maxGap = gap;
                }
            }
            Console.WriteLine(maxN);
        }
    }
}
