// detail: https://atcoder.jp/contests/code-festival-2015-qualb/submissions/16426799
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
        int n = Console.ReadLine().Split().Select(int.Parse).First();
        var a = Console.ReadLine().Split().GroupBy(x => x).OrderByDescending(x => x.Count()).First();
        Console.WriteLine(a.Count() * 2 > n ? a.Key : "?");
    }
}
