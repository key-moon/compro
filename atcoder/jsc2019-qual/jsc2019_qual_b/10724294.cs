// detail: https://atcoder.jp/contests/jsc2019-qual/submissions/10724294
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
        long k = nk[1];
        var a = Console.ReadLine().Split().Select(int.Parse).ToArray();
        long res = 0;
        for (int i = 0; i < a.Length; i++)
        {
            var cur =
                a.Skip(i).Count(x => x < a[i]) * k +
                a.Count(x => x < a[i]) * ((k * (k - 1) / 2) % 1000000007);
            res += cur % 1000000007;
            res %= 1000000007;
        }
        Console.WriteLine(res);
    }
}
