// detail: https://atcoder.jp/contests/abc190/submissions/19790299
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
        var constraints = Enumerable.Repeat(0, m).Select(_ => Console.ReadLine().Split().Select(int.Parse).ToArray()).ToArray();
        int k = int.Parse(Console.ReadLine());
        var place = Enumerable.Repeat(0, k).Select(_ => Console.ReadLine().Split().Select(int.Parse).ToArray()).ToArray();
        int res = 0;
        for (int b = 0; b < (1 << k); b++)
        {
            bool[] pos = new bool[n + 1];
            for (int i = 0; i < k; i++)
            {
                if ((b >> i & 1) == 1) pos[place[i][0]] |= true;
                else pos[place[i][1]] |= true;
            }
            res = Max(res, constraints.Count(x => pos[x[0]] && pos[x[1]]));
        }
        Console.WriteLine(res);
    }
}