// detail: https://codeforces.com/contest/702/submission/103529963
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
        var a = Console.ReadLine().Split().Select(int.Parse).ToArray();
        int res = 0;
        int last = -1;
        int streak = 0;
        foreach (var item in a)
        {
            if (last >= item)
            {
                res = Max(res, streak);
                streak = 0;
            }
            streak++;
            last = item;
        }
        res = Max(res, streak);
        Console.WriteLine(res);
    }
}
