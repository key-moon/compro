// detail: https://codeforces.com/contest/1375/submission/85954554
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
        int t = int.Parse(Console.ReadLine());
        for (int i = 0; i < t; i++)
        {
            Solve();
        }
    }
    static Random rng = new Random();
    static void Solve()
    {
        int n = int.Parse(Console.ReadLine());
        var a = Console.ReadLine().Split().Select(int.Parse).ToArray();
        //int n = 5;
        //var a = Enumerable.Range(0, n + 1).OrderBy(x => rng.Next()).Skip(1).ToArray();
        List<int> ops = new List<int>();
        while (true)
        {
            var mex = Enumerable.Range(0, n + 1).Except(a).Min();
            if (mex == n)
            {
                var ind = a.TakeWhile((x, y) => x == y).Count();
                if (ind == n) break;
                a[ind] = mex;
                ops.Add(ind);
            }
            else
            {
                a[mex] = mex;
                ops.Add(mex);
            }
        }
        if (n * 2 < ops.Count) throw new Exception();
        Console.WriteLine(ops.Count);
        Console.WriteLine(string.Join(" ", ops.Select(x => x + 1)));
    }
}
