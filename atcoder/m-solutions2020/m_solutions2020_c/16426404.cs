// detail: https://atcoder.jp/contests/m-solutions2020/submissions/16426404
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
        var a = Console.ReadLine().Split().Select(int.Parse).ToArray();
        for (int i = k; i < n; i++)
        {
            Console.WriteLine(a[i - k] < a[i] ? "Yes" : "No");
        }
    }
}
