// detail: https://codeforces.com/contest/950/submission/36094992
using System;
using System.Linq;
using System.Diagnostics;
using System.Collections.Generic;
class P
{
    static void Main()
    {
        int[] a = Console.ReadLine().Split().Select(int.Parse).ToArray();
        int diff = Math.Abs(a[0] - a[1]);
        int res = 0;
        if (a[2] < diff)
        {
            res = 2 * (Math.Min(a[0], a[1]) + a[2]);
        }
        else
        {
            res = (a.Sum() / 2) * 2;
        }
        Console.WriteLine(res);
    }
}