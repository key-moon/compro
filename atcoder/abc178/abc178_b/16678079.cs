// detail: https://atcoder.jp/contests/abc178/submissions/16678079
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
        var abcd = Console.ReadLine().Split().Select(int.Parse).ToArray();
        var a = new List<long> { abcd[0], abcd[1] };
        if (abcd[0] <= 0 && 0 <= abcd[1])
            a.Add(0);
        var b = new List<long> { abcd[2], abcd[3] };
        if (abcd[2] <= 0 && 0 <= abcd[3])
            b.Add(0);
        Console.WriteLine(a.SelectMany(x => b.Select(y => x * y)).Max());
    }
}
