// detail: https://atcoder.jp/contests/abc182/submissions/17950851
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
        var m = Enumerable.Range(2, 1000).Select(x => a.Count(y => y % x == 0)).Max();
        var res = Enumerable.Range(2, 1000).Select(x => a.Count(y => y % x == 0)).TakeWhile(x => x != m);
        Console.WriteLine(res.Count() + 2);
    }
}