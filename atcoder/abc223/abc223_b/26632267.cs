// detail: https://atcoder.jp/contests/abc223/submissions/26632267
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
        string s = Console.ReadLine();
        SortedSet<string> set = new SortedSet<string>(Enumerable.Range(0, s.Length).Select(x => s[x..] + s[..x]));
        Console.WriteLine($"{set.Min}\n{set.Max}");
    }
}