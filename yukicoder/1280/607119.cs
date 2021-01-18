// detail: https://yukicoder.me/submissions/607119
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
        var nmc = Console.ReadLine().Split().Select(long.Parse).ToArray();
        var c = nmc[2]; 
        var a = Console.ReadLine().Split().Select(long.Parse).OrderByDescending(x => x).ToArray();
        var b = Console.ReadLine().Split().Select(long.Parse).OrderByDescending(x => x).ToArray();
        double res = 0;
        for (int i = 0; i < a.Length; i++)
        {
            int valid = -1;
            int invalid = b.Length;
            while ((invalid - valid) > 1)
            {
                var mid = (invalid + valid) / 2;
                if (c < a[i] * b[mid]) valid = mid;
                else invalid = mid;
            }
            res += (double)invalid / b.Length;
        }
        res /= a.Length;
        Console.WriteLine(res);
    }
}