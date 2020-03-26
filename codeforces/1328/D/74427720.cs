// detail: https://codeforces.com/contest/1328/submission/74427720
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
        int t = int.Parse(Console.ReadLine());
        for (int i = 0; i < t; i++)
        {
            Solve();
        }
    }
    static void Solve() 
    {
        int n = int.Parse(Console.ReadLine());
        var a = Console.ReadLine().Split().Select(int.Parse).ToArray();
        int[] res = new int[n];
        if (a.Distinct().Count() == 1) res = Enumerable.Repeat(1, n).ToArray();
        else if (n % 2 == 0) res = Enumerable.Range(0, n).Select(x => x % 2 + 1).ToArray();
        else
        {
            var hasSameColor = false;
            var color = 0;
            var last = a.Last();
            for (int i = 0; i < a.Length; i++)
            {
                if (!hasSameColor && last == a[i]) hasSameColor = true;
                else color ^= 1;
                res[i] = color + 1;
                last = a[i];
            }
            if (!hasSameColor) res[0] = 3;
        }
        Console.WriteLine(res.Max());
        Console.WriteLine(string.Join(" ", res));
    }
}
