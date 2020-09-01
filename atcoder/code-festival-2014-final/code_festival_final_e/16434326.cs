// detail: https://atcoder.jp/contests/code-festival-2014-final/submissions/16434326
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
        int n = int.Parse(Console.ReadLine());
        var last = int.MaxValue;
        var a = Console.ReadLine().Split().Select(int.Parse).Where(x => { var res = x != last; last = x; return res; }).ToArray();
        List<int> res = new List<int>();
        res.Add(a.First());
        for (int i = 1; i < a.Length - 1; i++)
            if ((a[i - 1] < a[i]) != (a[i] < a[i + 1]))
                res.Add(a[i]);
        res.Add(a.Last());
        if (res.Count <= 2) res.Clear();
        Console.WriteLine(res.Count);
    }
}