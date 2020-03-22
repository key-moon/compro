// detail: https://atcoder.jp/contests/abc159/submissions/11101092
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
        var a = Console.ReadLine().Split().Select(x => long.Parse(x) - 1).ToArray();
        var counts = new long[n];
        for (int i = 0; i < a.Length; i++)
        {
            counts[a[i]]++;
        }
        long res = 0;
        for (int i = 0; i < a.Length; i++)
        {
            res += counts[i] * (counts[i] - 1) / 2;
        }
        for (int i = 0; i < a.Length; i++)
        {
            res -= counts[a[i]] * (counts[a[i]] - 1) / 2;
            counts[a[i]]--;
            res += counts[a[i]] * (counts[a[i]] - 1) / 2;
            Console.WriteLine(res);
            res -= counts[a[i]] * (counts[a[i]] - 1) / 2;
            counts[a[i]]++;
            res += counts[a[i]] * (counts[a[i]] - 1) / 2;
        }
    }
}
