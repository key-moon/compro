// detail: https://atcoder.jp/contests/abc157/submissions/10433685
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
        var nm = Console.ReadLine().Split().Select(int.Parse).ToArray();
        var n = nm[0];
        var c = Enumerable.Repeat(0, nm[1]).Select(_ => Console.ReadLine().Split().Select(int.Parse).ToArray()).ToArray();
        for (int i = 0; i < 1000; i++)
        {
            var s = i.ToString();
            if (s.Length != n) continue;
            if (!c.All(x => s[x[0] - 1] - '0' == x[1])) continue;
            Console.WriteLine(i);
            return;
        }
        Console.WriteLine(-1);
    }
}
