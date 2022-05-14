// detail: https://atcoder.jp/contests/abc251/submissions/31665390
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
        int w = int.Parse(Console.ReadLine());
        var res = Enumerable.Range(1, 100).Concat(Enumerable.Range(1, 99).Select(x => x * 100)).Concat(Enumerable.Range(1, 99).Select(x => x * 100 * 100)).ToArray();
        Console.WriteLine(res.Length);
        Console.WriteLine(string.Join(" ", res));
    }
}