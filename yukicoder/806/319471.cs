// detail: https://yukicoder.me/submissions/319471
using System;
using System.IO;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using static System.Math;
using Debug = System.Diagnostics.Debug;


class Ph
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        int[][] a = Enumerable.Repeat(0, n - 1).Select(_ => Console.ReadLine().Split().Select(int.Parse).ToArray()).ToArray();
        Assert(3 <= n && n <= 1e5);
        Assert(a.Length == n - 1);
        Assert(a.All(x => x.All(y => 1 <= y && y <= n)));
        var answer = Solve(n, a);
        Console.WriteLine(answer);
    }

    static int Solve(int n, int[][] a) => a.SelectMany(x => x).GroupBy(x => x).Sum(x => Max(0, x.Count() - 2));

    //直径から伸びている部分木の本数
    static int Lie1(int n, int[][] a)
    {
        return 0;
    }

    static void Assert(bool condition)
    {
        if (!condition) throw new Exception();
    }
}