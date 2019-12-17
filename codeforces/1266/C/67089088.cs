// detail: https://codeforces.com/contest/1266/submission/67089088
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
        var rc = Console.ReadLine().Split().Select(int.Parse).ToArray();
        var r = rc[0];
        var c = rc[1];
        if (r == 1 && c == 1)
        {
            Console.WriteLine(0);
            return;
        }
        if (r == 1)
        {
            Console.WriteLine(string.Join(" ", Enumerable.Range(2, c)));
            return;
        }
        if (c == 1)
        {
            Console.WriteLine(string.Join("\n", Enumerable.Range(2, r)));
            return;
        }
        Console.WriteLine(string.Join("\n", Enumerable.Range(1, r).Select(x => string.Join(" ", Enumerable.Range(r + 1, c).Select(y => x * y)))));
    }
}
