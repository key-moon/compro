// detail: https://codeforces.com/contest/1013/submission/40943281
using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using static System.Math;

class P
{
    static void Main()
    {
        int[] nx = Console.ReadLine().Split().Select(int.Parse).ToArray();
        int n = nx[0];
        int x = nx[1];
        int[] a = Console.ReadLine().Split().Select(int.Parse).ToArray();
        int[] aCount = new int[100001];
        int[] xaCount = new int[100001];
        for (int i = 0; i < a.Length; i++)
        {
            aCount[a[i]]++;
            xaCount[a[i] & x]++;
        }
        int min = 1333;
        for (int i = 0; i < aCount.Length; i++)
        {
            if (aCount[i] >= 2) min = Min(min, 0);
            else if (xaCount[i] >= 2 && aCount[i] >= 1) min = Min(min, 1);
            else if (xaCount[i] >= 2 && aCount[i] < 1) min = Min(min, 2);
        }
        if (min == 1333) min = -1;
        Console.WriteLine(min);
    }
}