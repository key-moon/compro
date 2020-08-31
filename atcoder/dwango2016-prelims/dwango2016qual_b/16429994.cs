// detail: https://atcoder.jp/contests/dwango2016-prelims/submissions/16429994
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
        var a = Console.ReadLine().Split().Select(int.Parse).ToArray();
        List<int> res = new List<int>();
        res.Add(a.First());
        for (int i = 1; i < a.Length; i++)
            res.Add(Min(a[i - 1], a[i]));
        res.Add(a.Last());
        Console.WriteLine(string.Join(" ", res));
    }
}