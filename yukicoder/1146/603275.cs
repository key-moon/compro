// detail: https://yukicoder.me/submissions/603275
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
        var n = int.Parse(Console.ReadLine());
        var a = Enumerable.Repeat(0, n).Select(_ => int.Parse(Console.ReadLine())).ToArray();
        int res = 0;
        for (int i = 0; i < n; i++)
        {
            for (int j= i + 1; j < n; j++)
            {
                var tmpGcd = GCD(a[i], a[j]);
                for (int k = j + 1; k < n; k++)
                {
                    if (GCD(tmpGcd, a[k]) == 1) res++;
                }
            }
        }
        Console.WriteLine(res);
    }

    static long GCD(long a, long b)
    {
        while (true)
        {
            if (b == 0) return a;
            a %= b;
            if (a == 0) return b;
            b %= a;
        }
    }
}
