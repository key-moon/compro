// detail: https://atcoder.jp/contests/abc167/submissions/13025688
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

public static class P
{
    public static void Main()
    {
        var nmk = Console.ReadLine().Split().Select(int.Parse).ToArray();
        var n = nmk[0];
        var m = nmk[1];
        var k = nmk[2];
        var c = Enumerable.Repeat(0, n).Select(_ => Console.ReadLine().Split().Select(int.Parse).ToArray()).ToArray();
        int res = int.MaxValue;
        for (int i = 0; i < (1 << n); i++)
        {
            int price = 0;
            int[] a = new int[m];
            for (int j = 0; j < n; j++)
            {
                if ((i >> j & 1) == 1)
                {
                    price += c[j][0];
                    a = a.Zip(c[j].Skip(1), (x, y) => x + y).ToArray();
                }
            }
            if (a.All(x => x >= k)) res = Math.Min(res, price);
        }
        if (res == int.MaxValue) res = -1;
        Console.WriteLine(res);
    }
}
