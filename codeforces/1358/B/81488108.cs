// detail: https://codeforces.com/contest/1358/submission/81488108
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
        int t = int.Parse(Console.ReadLine());
        for (int i = 0; i < t; i++)
        {
            Solve();
        }
    }
    public static void Solve()
    {
        int n = int.Parse(Console.ReadLine());
        int count = 0;
        int pending = 0;
        foreach (var item in Console.ReadLine().Split().Select(int.Parse).GroupBy(x => x).OrderBy(x => x.Key))
        {
            var itemCount = item.Count();
            if (item.Key <= count + pending + itemCount)
            {
                count += (pending + itemCount);
                pending = 0;
            }
            else
            {
                pending += itemCount;
            }
        }
        Console.WriteLine(count + 1);
    }
}
