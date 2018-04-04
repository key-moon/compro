// detail: https://codeforces.com/contest/961/submission/36952398
using System;
using System.Linq;
using System.Collections.Generic;
using static System.Math;

class P
{
    static void Main()
    {
        int max = Console.ReadLine().Split().Select(int.Parse).ToArray()[0];
        int[] a = new int[max];
        int[] c = Console.ReadLine().Split().Select(int.Parse).ToArray();
        for (int i = 0; i < c.Length; i++)
        {
            a[c[i] - 1]++;
        }
        Console.WriteLine(a.Min());

    }
}