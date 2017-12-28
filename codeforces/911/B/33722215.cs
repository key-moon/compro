// detail: https://codeforces.com/contest/911/submission/33722215
﻿using System; 
using System.Linq;
using System.Collections.Generic;

class P
{
    static void Main()
    {
        int[] NAB = Console.ReadLine().Split().Select(int.Parse).ToArray();
        int N = NAB[0];
        int A = NAB[1];
        int B = NAB[2];
        int max = 0;
        for (int i = 1; i < N; i++)
        {
            max = Math.Max(max, Math.Min((A / i), (B / (N - i))));
        }
        Console.WriteLine(max);
    }
}