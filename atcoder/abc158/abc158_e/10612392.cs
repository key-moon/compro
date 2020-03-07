// detail: https://atcoder.jp/contests/abc158/submissions/10612392
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
        var np = Console.ReadLine().Split().Select(int.Parse).ToArray();
        var s = Console.ReadLine();
        var p = np[1];
        var res = 0L;
        if (p == 2 || p == 5)
        {
            for (int i = 0; i < s.Length; i++)
            {
                if ((s[i] - '0') % p == 0)
                {
                    res += i + 1;
                }
            }
            Console.WriteLine(res);
            return;
        }
        var accum = new int[s.Length + 1];
        accum[accum.Length - 1] = 0;
        var pow = 1;
        for (int i = s.Length - 1; i >= 0; i--)
        {
            accum[i] = accum[i + 1] + (s[i] - '0') * pow;
            accum[i] %= p;
            pow *= 10;
            pow %= p;
        }
        foreach (var item in accum.GroupBy(x => x))
        {
            long count = item.Count();
            res += count * (count - 1) / 2;
        }
        Console.WriteLine(res);
    }
}
