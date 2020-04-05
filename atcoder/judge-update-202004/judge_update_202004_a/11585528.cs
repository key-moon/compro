// detail: https://atcoder.jp/contests/judge-update-202004/submissions/11585528
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
        var slr = Console.ReadLine().Split().Select(int.Parse).ToArray();
        var (s, l, r) = (slr[0], slr[1], slr[2]);
        Console.WriteLine(Clamp(s, l, r));
    }
}