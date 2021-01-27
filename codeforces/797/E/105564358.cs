// detail: https://codeforces.com/contest/797/submission/105564358
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
        var a = Console.ReadLine().Split().Select(int.Parse).ToArray();
        int[][] smallRes = Enumerable.Repeat(0, 301).Select(_ => new int[n]).ToArray();
        for (int k = 1; k < smallRes.Length; k++)
        {
            var res = smallRes[k];
            for (int i = n - 1; i >= 0; i--)
            {
                var next = i + a[i] + k;
                res[i] = res.Length <= next ? 1 : res[next] + 1;
            }
        }
        var q = int.Parse(Console.ReadLine());
        for (int i = 0; i < q; i++)
        {
            var pk = Console.ReadLine().Split().Select(int.Parse).ToArray();
            var p = pk[0] - 1;
            var k = pk[1];
            int res;
            if (k < smallRes.Length)
            {
                res = smallRes[k][p];
            }
            else
            {
                res = 0;
                while (p < n)
                {
                    p = p + a[p] + k;
                    res++;
                }
            }
            Console.WriteLine(res);
        }
    }
}