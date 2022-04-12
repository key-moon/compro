// detail: https://atcoder.jp/contests/abc175/submissions/30928638
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
        var a = Console.ReadLine().Split().Select(long.Parse).GroupBy(x => x).Select(x => (x.Key, (long)x.Count())).OrderBy(x => x).ToArray();
        long res = 0;
        for (int i = 0; i < a.Length; i++)
        {
            for (int j = i + 1; j < a.Length; j++)
            {
                for (int k = j + 1; k < a.Length; k++)
                {
                    if (a[i].Item1 + a[j].Item1 > a[k].Item1)
                    {
                        res += a[i].Item2 * a[j].Item2 * a[k].Item2;
                    }
                }
            }
        }
        Console.WriteLine(res);
    }
}