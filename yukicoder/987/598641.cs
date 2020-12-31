// detail: https://yukicoder.me/submissions/598641
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
        var b = Console.ReadLine().Split();
        var op = b[0];
        var row = b.Skip(1).Select(long.Parse).ToArray();
        var col = Enumerable.Repeat(0, n).Select(_ => long.Parse(Console.ReadLine())).ToArray();

        Console.WriteLine(string.Join("\n", col.Select(x => string.Join(" ", row.Select(y => op == "+" ? x + y : x * y)))));
    }
}
