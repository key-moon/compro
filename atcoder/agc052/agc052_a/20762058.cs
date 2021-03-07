// detail: https://atcoder.jp/contests/agc052/submissions/20762058
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
        var t = int.Parse(Console.ReadLine());
        for (int i = 0; i < t; i++)
        {
            Solve();
        }
    }
    static void Solve()
    {
        int n = int.Parse(Console.ReadLine());
        string rep0 = string.Join("", Enumerable.Repeat('0', n));
        string rep1 = string.Join("", Enumerable.Repeat('1', n));
        string s1 = Console.ReadLine();
        string s2 = Console.ReadLine();
        string s3 = Console.ReadLine();
        int GetKind(char first, char last)
        {
            return (first - '0') * 2 + (last - '0');
        }
        HashSet<int> kinds = new HashSet<int>();
        kinds.Add(GetKind(s1.First(), s1.Last()));
        kinds.Add(GetKind(s2.First(), s2.Last()));
        kinds.Add(GetKind(s3.First(), s3.Last()));
        string res = null;
        if (!kinds.Contains(GetKind('0', '0')))
            res = rep0 + "1" + rep0;
        if (!kinds.Contains(GetKind('1', '1')))
            res = rep1 + "0" + rep1;
        if (!kinds.Contains(GetKind('0', '1')))
            res = rep0 + rep1 + "0";
        if (!kinds.Contains(GetKind('1', '0')))
            res = rep1 + rep0 + "1";
        if (res is null) throw new Exception();
        Console.WriteLine(res);
    }
}
