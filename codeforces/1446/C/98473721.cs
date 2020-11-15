// detail: https://codeforces.com/contest/1446/submission/98473721
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
        var a = Console.ReadLine().Split().Select(long.Parse).OrderBy(x => x).ToArray();
        /*long[][] packets = new long[32][];
        int ind = 0;
        packets[ind++] = a.Where(x => x == 0).ToArray();
        for (long sz = 1; sz < int.MaxValue; sz *= 2)
        {
            packets[ind++] = a.Where(x => sz <= x && x < sz * 2).ToArray();
        }*/
        int max = 0;
        foreach (var item in a)
        {
            long prevlb = item, prevub = item;
            int res = 0;
            for (int i = 0; i < 32; i++)
            {
                var lb = (item >> i) << i;
                var ub = lb + (1L << i);

                var curlb = prevlb == lb ? prevub : lb;
                var curub = prevlb == lb ? ub : prevlb;

                var ind = Array.BinarySearch(a, curlb);
                if (ind < 0) ind = ~ind;
                if (ind < n && a[ind] < curub) res++;
                (prevlb, prevub) = (lb, ub);
            }
            max = Max(max, res);
        }
        Console.WriteLine(n - max);
    }
}