// detail: https://atcoder.jp/contests/nomura2020/submissions/13723306
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
        var a = Console.ReadLine().Split().Select(long.Parse).ToArray();
        var afterLeaves = new long[a.Length];

        for (int i = a.Length - 2; i >= 0; i--)
            afterLeaves[i] = afterLeaves[i + 1] + a[i + 1];
        
        long nodeCount = 1;
        long res = 0;
        for (int i = 0; i < a.Length; i++)
        {
            var item = a[i];
            res += nodeCount;
            nodeCount -= item;
            if (nodeCount < 0)
            {
                Console.WriteLine(-1);
                return;
            }
            nodeCount *= 2;
            nodeCount = Min(nodeCount, afterLeaves[i]);
        }
        Console.WriteLine(res);
    }
}
