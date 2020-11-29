// detail: https://atcoder.jp/contests/abc025/submissions/18493984
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
        int n = int.Parse(Console.ReadLine()) - 1;
        Console.WriteLine(s.SelectMany(x => s.Select(y => $"{x}{y}")).OrderBy(x => x).ElementAt(n));
    }
}
