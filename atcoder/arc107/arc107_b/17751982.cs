// detail: https://atcoder.jp/contests/arc107/submissions/17751982
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
        var nk = Console.ReadLine().Split().Select(int.Parse).ToArray();
        var n = nk[0];
        var k = nk[1];
        long[] table = new long[n + n + 3];
        for (int i = 0; i < table.Length; i++) table[i] = Max(n - Abs(n + 1 - i), 0);
        long res = 0;
        for (int i = 0; i < table.Length; i++)
        {
            var ind = i + k;
            if (Clamp(ind, 0, table.Length - 1) == ind) res += table[i] * table[ind];
        }
        Console.WriteLine(res);
    }
}