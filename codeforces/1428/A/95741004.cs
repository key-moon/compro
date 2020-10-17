// detail: https://codeforces.com/contest/1428/submission/95741004
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
    static void Solve()
    {
        var xyxy = Console.ReadLine().Split().Select(long.Parse).ToArray();
        var res = Abs(xyxy[0] - xyxy[2]) + Abs(xyxy[1] - xyxy[3]) + 2;
        if (xyxy[0] == xyxy[2] || xyxy[1] == xyxy[3]) res -= 2;
        Console.WriteLine(res);
    }
}
