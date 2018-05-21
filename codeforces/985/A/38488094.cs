// detail: https://codeforces.com/contest/985/submission/38488094
using System;
using System.Linq;
using System.Diagnostics;
using System.Collections.Generic;
using static System.Math;

class P
{
    static void Main()
    {
        //偶数
        int n = int.Parse(Console.ReadLine());
        int[] p = Console.ReadLine().Split().Select(x => int.Parse(x) - 1).OrderBy(x => x).ToArray();
        int even = 0;
        int odd = 0;
        for (int i = 0; i < p.Length; i++)
        {
            even += Abs(p[i] - (i * 2));
            odd += Abs(p[i] - ((i * 2) + 1));
            //Debug.WriteLine($"{even} {odd} {(i * 2)} {(i * 2) + 1}");
        }
        Console.WriteLine(Min(even, odd));


    }
}