// detail: https://codeforces.com/contest/1320/submission/72167657
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
using MethodImplAttribute = System.Runtime.CompilerServices.MethodImplAttribute;
using MethodImplOptions = System.Runtime.CompilerServices.MethodImplOptions;

public static class P
{
    public static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        var a = Console.ReadLine().Split().Select(int.Parse).ToArray();
        var beauty = new long[800000];
        for (int i = 0; i < a.Length; i++)
        {
            var offset = n - i;
            beauty[a[i] + offset] += a[i];
        }
        Console.WriteLine(beauty.Max());
    }
}
