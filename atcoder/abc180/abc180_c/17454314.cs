// detail: https://atcoder.jp/contests/abc180/submissions/17454314
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
        var n = long.Parse(Console.ReadLine());
        List<long> l = new List<long>();
        for (long i = 1; i * i <= n; i++)
        {
            if (n % i != 0) continue;
            l.Add(i);
            l.Add(n / i);
        }

        Console.WriteLine(string.Join("\n", l.Distinct().OrderBy(x => x)));
    }
    
}