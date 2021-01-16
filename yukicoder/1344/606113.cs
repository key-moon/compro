// detail: https://yukicoder.me/submissions/606113
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
        long[][] mat = Enumerable.Repeat(0, n).Select(_ => Enumerable.Repeat(long.MaxValue / 2, n).ToArray()).ToArray();
        for (int i = 0; i < n; i++) mat[i][i] = 0;
        for (int i = 0; i < m; i++)
        {
            var st = Console.ReadLine().Split().Select(x => long.Parse(x)).ToArray();
            mat[st[0] - 1][st[1] - 1] = Min(mat[st[0] - 1][st[1] - 1], st[2]);
        }
        for (int i = 0; i < n; i++)
            for (int j = 0; j < n; j++)
                for (int k = 0; k < n; k++)
                    mat[j][k] = Min(mat[j][k], mat[j][i] + mat[i][k]);
        for (int i = 0; i < n; i++) Console.WriteLine(mat[i].Sum(x => long.MaxValue / 4 < x ? 0 : x));
    }
}