// detail: https://codeforces.com/contest/1270/submission/67895017
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
using MethodImplAttribute = System.Runtime.CompilerServices.MethodImplAttribute;
using MethodImplOptions = System.Runtime.CompilerServices.MethodImplOptions;

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
    static void Solve()
    {
        var n = int.Parse(Console.ReadLine());
        var a = Console.ReadLine().Split().Select(long.Parse).ToArray();
        List<long> res = new List<long>();
        var X = a.Aggregate(0L, (x, y) => x ^ y);
        res.Add(X);

        //xor=0, sum=S+X
        //xor=S+X, sum=S+X+S+X
        res.Add(a.Sum() + X);
        Console.WriteLine(res.Count);
        Console.WriteLine(string.Join(" ", res));
    }
}
