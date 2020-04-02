// detail: https://atcoder.jp/contests/arc068/submissions/11440387
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
        var res = n - (a.GroupBy(x => x).Select(x => x.Count() - 1).Sum() + 1) / 2 * 2;
        Console.WriteLine(res);
    }
}
