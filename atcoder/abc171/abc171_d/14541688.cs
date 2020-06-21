// detail: https://atcoder.jp/contests/abc171/submissions/14541688
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
        long[] count = new long[100001];
        long sum = 0;
        for (int i = 0; i < a.Length; i++)
        {
            count[a[i]]++;
            sum += a[i];
        }

        var q = int.Parse(Console.ReadLine());
        for (int i = 0; i < q; i++)
        {
            var bc = Console.ReadLine().Split().Select(int.Parse).ToArray();
            var b = bc[0];
            var c = bc[1];
            sum -= count[b] * b;
            sum += count[b] * c;
            count[c] += count[b];
            count[b] = 0;
            Console.WriteLine(sum);
        }
    }
}
