// detail: https://atcoder.jp/contests/abc144/submissions/11441113
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
        var min = long.MaxValue;
        for (long i = 1; i * i <= n; i++)
        {
            if (n % i != 0) continue;
            min = Min(min, n / i + i - 2);
        }
        Console.WriteLine(min);
    }
}
