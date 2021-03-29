// detail: https://codeforces.com/contest/846/submission/111318316
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
        int zeroCnt = 0;
        int zeroAndOneCnt = 0;
        foreach (var item in a)
        {
            if (item == 0)
            {
                zeroCnt++;
            }
            else
            {
                zeroAndOneCnt = Max(zeroCnt + 1, zeroAndOneCnt + 1);
            }
        }
        Console.WriteLine(Max(zeroAndOneCnt, zeroCnt));
    }
}
