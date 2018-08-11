// detail: https://codeforces.com/contest/1020/submission/41478065
using System;
using System.IO;
using System.Linq;
using System.Diagnostics;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using static System.Math;

class P
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        int[] a = Console.ReadLine().Split().Select(int.Parse).ToArray();
        int[] res = new int[n];
        //閉路とそれにつながるループ
        for (int i = 0; i < a.Length; i++)
        {
            bool[] b = new bool[a.Length];
            int s = i;
            while (!b[s])
            {
                b[s] = true;
                s = a[s] - 1;
            }
            res[i] = s + 1;
        }
        Console.WriteLine(string.Join(" ", res));

    }
}