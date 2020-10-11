// detail: https://atcoder.jp/contests/arc105/submissions/17350569
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
        int n = int.Parse(Console.ReadLine());
        var a = Console.ReadLine().Split().Select(int.Parse).ToArray();

        if (n % 2 == 1)
        {
            Console.WriteLine("Second");
            return;
        }
        if (n % 2 == 0)
        {
            Array.Sort(a);
            for (int i = 0; i < a.Length; i += 2)
            {
                if (a[i] != a[i + 1])
                {
                    Console.WriteLine("First");
                    return;
                }
            }
            Console.WriteLine("Second");
        }

        //first視点では…
        //nが奇数→xorを0にしたい
        //nが偶数→xorを0にしたくない
        
        //偶数個→ミラー戦法ができない限りは先手はxorを0でなくできる
    }
}
