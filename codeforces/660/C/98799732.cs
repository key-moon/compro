// detail: https://codeforces.com/contest/660/submission/98799732
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
        var nk = Console.ReadLine().Split().Select(int.Parse).ToArray();
        var n = nk[0];
        var k= nk[1];
        var a = Console.ReadLine().Split().Select(int.Parse).ToArray();
        int[] zeroCount = new int[n + 1];
        for (int i = 0; i < a.Length; i++)
            zeroCount[i + 1] = zeroCount[i] + (1 - a[i]);
        int max = -1;
        int maxInd = -1;
        for (int start = 0; start < n; start++)
        {
            var valid = start;
            var invalid = n + 1;
            while (invalid - valid > 1)
            {
                var mid = (invalid + valid) / 2;
                if (zeroCount[mid] - zeroCount[start] <= k)
                    valid = mid;
                else
                    invalid = mid;
            }
            var res = valid - start;
            if (max < res)
            {
                max = res;
                maxInd = start;
            }
        }
        Console.WriteLine(max);
        Array.Fill(a, 1, maxInd, max);
        Console.WriteLine(string.Join(" ", a));
    }
}

