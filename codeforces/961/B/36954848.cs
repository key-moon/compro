// detail: https://codeforces.com/contest/961/submission/36954848
using System;
using System.Linq;
using System.Collections.Generic;
using static System.Math;

class P
{
    static void Main()
    {
        int k = Console.ReadLine().Split().Select(int.Parse).ToArray()[1];
        int[] a = Console.ReadLine().Split().Select(int.Parse).ToArray();
        bool[] t = Console.ReadLine().Split().Select(x => x == "1").ToArray();
        int count = a.Where((_, x) => t[x]).Sum();
        for (int i = 0; i < k; i++)
        {
            if (!t[i])
            {
                count += a[i];
            }
        }
        int max = count;
        for (int i = 0; i < a.Length - k; i++)
        {
            if (!t[i])
            {
                count -= a[i];
            }
            if(!t[i + k])
            {
                count += a[i + k];
            }
            max = Max(max, count);
        }
        Console.WriteLine(max);
    }   
}