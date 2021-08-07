// detail: https://atcoder.jp/contests/abc134/submissions/24831782
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
        var nd = Console.ReadLine().Split().Select(int.Parse).ToArray();
        var n = nd[0];
        var d = nd[1];
        var cover = d * 2 + 1;
        Console.WriteLine((n + cover - 1) / cover);
    }
}