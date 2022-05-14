// detail: https://atcoder.jp/contests/abc251/submissions/31661296
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
        var nw = Console.ReadLine().Split().Select(int.Parse).ToArray();
        var n = nw[0];
        var w = nw[1];
        var a = Console.ReadLine().Split().Select(int.Parse).Concat(new[] { 0, 0 }).ToArray();
        HashSet<int> s = new HashSet<int>();
        for (int i = 0; i < a.Length; i++)
        {
            for (int j = i + 1; j < a.Length; j++)
            {
                for (int k = j + 1; k < a.Length; k++)
                {
                    var v = a[i] + a[j] + a[k];
                    if (v <= w) s.Add(v);
                }
            }
        }
        
        Console.WriteLine(s.Count);
    }
}