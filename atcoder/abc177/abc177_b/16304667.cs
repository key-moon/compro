// detail: https://atcoder.jp/contests/abc177/submissions/16304667
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
        var s = Console.ReadLine();
        var t = Console.ReadLine();
        var res = int.MaxValue;
        for (int i = 0; i <= s.Length - t.Length; i++)
        {
            res = Min(s.Substring(i, t.Length).Zip(t, (x, y) => x == y ? 0 : 1).Sum(), res);
        }
        Console.WriteLine(res);
    }
}
