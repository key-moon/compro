// detail: https://codeforces.com/contest/1326/submission/73666351
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using static System.Math;
using MethodImplAttribute = System.Runtime.CompilerServices.MethodImplAttribute;
using MethodImplOptions = System.Runtime.CompilerServices.MethodImplOptions;

public static class P
{
    public static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        var b = Console.ReadLine().Split().Select(long.Parse).ToArray();
        List<long> a = new List<long>();
        var max = b[0];
        a.Add(b[0]);
        for (int i = 1; i < b.Length; i++)
        {
            a.Add(b[i] + max);
            max = Max(max, a.Last());
        }

        Console.WriteLine(string.Join(" ", a));
    }
}
