// detail: https://codeforces.com/contest/808/submission/106358265
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
        bool Judge(long[] a)
        {
            var sum = a.Sum();
            if (sum % 2 == 1) return false;
            var target = sum / 2;
            HashSet<long> used = new HashSet<long>();
            long cur = 0;
            foreach (var item in a)
            {
                cur += item;
                used.Add(item);
                if (used.Contains(cur - target)) return true;
            }
            return false;
        }
        Console.WriteLine(Judge(a) || Judge(a.Reverse().ToArray()) ? "YES" : "NO");
    }
}