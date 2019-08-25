// detail: https://codeforces.com/contest/1208/submission/59455386
using System;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Debug = System.Diagnostics.Debug;
using static System.Math;
using MethodImplOptions = System.Runtime.CompilerServices.MethodImplOptions;
using MethodImplAttribute = System.Runtime.CompilerServices.MethodImplAttribute;

static class P
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        var a = Console.ReadLine().Split().Select(int.Parse).ToArray();
        var dict = a.Distinct().OrderBy(x => x).Select((Elem, Ind) => new { Elem, Ind }).ToDictionary(x => x.Elem, x => x.Ind);
        a = a.Select(x => dict[x]).ToArray();
        var counts = new int[a.Max() + 1];
        for (int i = 0; i < a.Length; i++)
            counts[a[i]]++;
        int badCount = counts.Count(x => 2 <= x);
        int res = badCount == 0 ? 0 : int.MaxValue;
        for (int i = 0; i < n; i++)
        {
            int curBad = badCount;
            var curCounts = counts.ToArray();
            for (int j = i; j < n; j++)
            {
                if (--curCounts[a[j]] == 1) curBad--;
                if (curBad == 0)
                {
                    res = Min(res, j - i + 1);
                    break;
                }
            }
        }
        Console.WriteLine(res);
    }
}
