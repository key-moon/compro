// detail: https://atcoder.jp/contests/abc165/submissions/12610336
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
        var abn = Console.ReadLine().Split().Select(long.Parse).ToArray();
        var a = abn[0];
        var b = abn[1];
        var n = abn[2];

        var x = Min(b - 1, n);
        //for (int x = 0; x <= n; x++)
        {
            Console.WriteLine(a * x / b - a * (x / b));
        }
    }
}