// detail: https://atcoder.jp/contests/abc165/submissions/12605333
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
        var nmq = Console.ReadLine().Split().Select(int.Parse).ToArray();
        var (n, m, q) = (nmq[0], nmq[1], nmq[2]);
        var query = Enumerable.Repeat(0, q).Select(_ => Console.ReadLine().Split().Select(int.Parse).ToArray()).ToArray();
        int res = 0;
        for (int i = 0; i < (1 << (m + n)); i++)
        {
            List<int> seq = new List<int>();
            for (int j = 0; j < n + m; j++)
            {
                if ((i >> j & 1) == 1)
                {
                    var next = j + 1 - seq.Count;
                    if (next > m) goto end;
                    seq.Add(next);
                }
            }
            if (seq.Count != n) continue;

            //Console.WriteLine(string.Join(" ", seq));
            res = Max(res, query.Where(x => seq[x[1] - 1] - seq[x[0] - 1] == x[2]).Sum(x => x[3]));
            end:;
        }
        Console.WriteLine(res);
    }
}
