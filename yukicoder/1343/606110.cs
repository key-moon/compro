// detail: https://yukicoder.me/submissions/606110
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
        var a = Console.ReadLine().Split().Select(int.Parse).ToArray();
        var mod = a.Sum();
        long res = 0;
        long b = 1;
        for (int i = a.Length - 1; i >= 0; i--)
        {
            res += a[i] * b;
            res %= mod;
            b *= nk[1];
            b %= mod;
        }
        Console.WriteLine(res);
    }
}