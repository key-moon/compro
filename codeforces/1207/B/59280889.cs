// detail: https://codeforces.com/contest/1207/submission/59280889
using System;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Debug = System.Diagnostics.Debug;
using static System.Math;

static class P
{
    static void Main()
    {
        var nm = Console.ReadLine().Split().Select(int.Parse).ToArray();
        var n = nm[0];
        var m = nm[1];
        var a = Enumerable.Repeat(0, n).Select(_ => Console.ReadLine().Split().Select(int.Parse).Select(x => x != 0).ToArray()).ToArray();
        var b = Enumerable.Repeat(0, n).Select(_ => new bool[m]).ToArray();
        List<Tuple<int, int>> res = new List<Tuple<int, int>>();
        for (int i = 0; i < n - 1; i++)
        {
            for (int j = 0; j < m - 1; j++)
            {
                if (a[i][j] && a[i][j + 1] && a[i + 1][j] && a[i + 1][j + 1])
                {
                    res.Add(new Tuple<int, int>(i, j));
                    b[i][j] = true;
                    b[i][j + 1] = true;
                    b[i + 1][j] = true;
                    b[i + 1][j + 1] = true;
                }
            }
        }
        if (a.Zip(b, (x, y) => x.Zip(y, (X, Y) => X != Y).Any(X => X)).Any(x => x))
        {
            Console.WriteLine(-1);
            return;
        }
        Console.WriteLine(res.Count);
        if (res.Count != 0) Console.WriteLine(string.Join("\n", res.Select(x => $"{x.Item1 + 1} {x.Item2 + 1}")));
    }
}
