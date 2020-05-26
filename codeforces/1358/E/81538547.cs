// detail: https://codeforces.com/contest/1358/submission/81538547
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
        int n = int.Parse(Console.ReadLine());
        var a = Console.ReadLine().Split().Select(long.Parse).ToArray();
        var remain = n - a.Length;
        var x = long.Parse(Console.ReadLine());

        List<long> accums = new List<long>() { 0 };
        for (int i = a.Length - 1; i >= 0; i--)
        {
            var item = (a[i] - x);
            accums.Add(accums.Last() + item);
        }
        accums.RemoveAt(0);
        accums.Reverse();
        for (int i = 0; i < accums.Count; i++)
        {
            if (0 < i) accums[i] = Min(accums[i - 1], accums[i]);
            if (-x * (n - i) < accums[i])
            {
                Console.WriteLine(n - i);
                return;
            }
        }
        Console.WriteLine(-1);
    }
}