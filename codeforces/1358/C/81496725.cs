// detail: https://codeforces.com/contest/1358/submission/81496725
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
        var nums = Console.ReadLine().Split().Select(long.Parse).ToArray();
        var x = nums[2] - nums[0];
        var y = nums[3] - nums[1];
        Console.WriteLine(x * y + 1);
    }
}
