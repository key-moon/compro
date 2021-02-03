// detail: https://codeforces.com/contest/808/submission/106357324
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
        var nk = Console.ReadLine().Split().Select(int.Parse).ToArray();
        var a = Console.ReadLine().Split().Select(long.Parse).ToArray();
        var sum = a.Take(nk[1]).Sum();
        var totalSum = sum;
        for (int i = 0; i < nk[0] - nk[1]; i++)
        {
            sum -= a[i];
            sum += a[i + nk[1]];
            totalSum += sum;
        }
        Console.WriteLine(totalSum / (double)(nk[0] - nk[1] + 1));
    }
}
