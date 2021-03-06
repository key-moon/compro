// detail: https://atcoder.jp/contests/abc194/submissions/20696167
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
        Dictionary<int, int> cnts = Enumerable.Range(-200, 401).ToDictionary(x => x, _ => 0);
        int n = int.Parse(Console.ReadLine());
        var a = Console.ReadLine().Split().Select(int.Parse).ToArray();
        foreach (var item in a) cnts[item]++;
        long res = 0;
        foreach (var (key1, val1) in cnts)
        {
            foreach (var (key2, val2) in cnts)
            {
                if (key1 > key2) continue;
                long d = key2 - key1;
                res += d * d * val1 * val2;
            }
        }
        Console.WriteLine(res);
    }
}
