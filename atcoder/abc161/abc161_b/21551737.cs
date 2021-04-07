// detail: https://atcoder.jp/contests/abc161/submissions/21551737
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

        var a = Console.ReadLine().Split().Select(int.Parse).ToArray();
        var sum = a.Sum();

        var cnt = a.Count(x => sum <= x * 4 * nm[1]);

        Console.WriteLine(nm[1] <= cnt ? "Yes" : "No");
    }
}