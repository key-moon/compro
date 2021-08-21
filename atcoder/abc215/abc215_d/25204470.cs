// detail: https://atcoder.jp/contests/abc215/submissions/25204470
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
        var nm = Console.ReadLine().Split().Select(int.Parse).ToArray();
        var n = nm[0];
        var m = nm[1];
        var a = Console.ReadLine().Split().Select(int.Parse).ToHashSet();
        bool[] hasValue = new bool[100001];
        for (int i = 2; i < hasValue.Length; i++)
        {
            bool flag = false;
            for (int j = i; j < hasValue.Length; j += i)
                flag |= a.Contains(j);
            for (int j = i; j < hasValue.Length; j += i)
                hasValue[j] |= flag;
        }
        var res = Enumerable.Range(1, m).Where(x => !hasValue[x]).ToArray();
        Console.WriteLine(res.Length);
        Console.WriteLine(string.Join("\n", res));
    }
}