// detail: https://codeforces.com/contest/1013/submission/40951742
using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using static System.Math;

class P
{
    static void Main()
    {

        int n = int.Parse(Console.ReadLine());
        long[] a = Console.ReadLine().Split().Select(long.Parse).OrderBy(x => x % 3).OrderBy(x => x).ToArray();
        long res = (a[n - 1] - a[0]) * (a[n * 2 - 1] - a[n]);
        long haba = a.Last() - a.First();
        for (int i = 0; i < n; i++)
        {
            res = Min(res, haba * (a[i + n - 1] - a[i]));
        }
        if (n == 1)
        {
            Console.WriteLine(0);
            return;
        }
        Console.WriteLine(res);
    }
}