// detail: https://codeforces.com/contest/665/submission/99547808
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
        var a = Console.ReadLine().Split().Select(int.Parse).ToArray();
        var b = Console.ReadLine().Split().Select(int.Parse).ToArray();
        var t = Console.ReadLine().Split(':').Select(int.Parse).ToArray();
        var min = t[0] * 60 + t[1];
        var begin = min - b[1];
        var end = min + a[1];
        var res = 0;
        for (int i = 5 * 60; i < 24 * 60; i += b[0])
        {
            if (begin < i && i < end) res++;
        }
        Console.WriteLine(res);
    }
}
