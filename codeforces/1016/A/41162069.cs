// detail: https://codeforces.com/contest/1016/submission/41162069
using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using static System.Math;

class P
{
    static void Main()
    {
        int[] nm = Console.ReadLine().Split().Select(int.Parse).ToArray();
        long[] a = Console.ReadLine().Split().Select(long.Parse).ToArray();
        long[] res = new long[nm[0]];
        long currentPage = 0;
        for (int i = 0; i < nm[0]; i++)
        {
            currentPage += a[i];
            res[i] = currentPage / nm[1];
            currentPage = currentPage % nm[1];
        }
        Console.WriteLine(string.Join(" ", res));
    }
}