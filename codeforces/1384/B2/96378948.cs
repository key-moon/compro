// detail: https://codeforces.com/contest/1384/submission/96378948
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
        var nkl = Console.ReadLine().Split().Select(long.Parse).ToArray();
        var n = nkl[0];
        var k = nkl[1]; //period
        var l = nkl[2]; //drawn limit
        var d = Console.ReadLine().Split().Select(long.Parse).ToArray();

        //0   1          k-1  k  k+1
        //k, k-1, k-2, .. 1,  0,  1, ... k - 1
        long cur = 0;
        //ヤバい時にいられる場所まで駆け抜けられるか
        for (int i = 0; i < d.Length; i++)
        {
            if (d[i] + k <= l) cur = 0;
            else
            {
                cur++;
                var limitRaise = l - d[i];
                if (d[i] > l || k + limitRaise < cur)
                {
                    Console.WriteLine("No");
                    return;
                }
                //wait until
                var firstPossible = k - limitRaise;
                cur = Max(firstPossible, cur);
            }
        }
        Console.WriteLine("Yes");
    }
}