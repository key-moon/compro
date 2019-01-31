// detail: https://codeforces.com/contest/1106/submission/49267036
using System;
using System.IO;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using System.Diagnostics;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using System.Runtime.CompilerServices;
using static System.Math;


class P
{
    static void Main()
    {
        Random RNG = new Random();

        int[] nm = Console.ReadLine().Split().Select(int.Parse).ToArray();
        long[] a = Console.ReadLine().Split().Select(long.Parse).ToArray();
        long[] c = Console.ReadLine().Split().Select(long.Parse).ToArray();
        int[][] tds = Enumerable.Repeat(0, nm[1]).Select(_ => Console.ReadLine().Split().Select(int.Parse).ToArray()).ToArray();
        //c_nはa_nこだせる
        //d個tを注文する
        //cがr個残っている時、1個頼むと
        //現状残ってる一番小さい皿 という概念を持っておく必要がある
        int ptr = 0;
        int[] indexes = Enumerable.Range(0, nm[0]).OrderBy(x => RNG.Next()/*Don't try to hack with sort!*/).OrderBy(x => c[x]).ThenBy(x => x).ToArray();
        List<long> costs = new List<long>();
        foreach (var td in tds)
        {
            long cost = 0;
            int t = td[0] - 1;
            long d = td[1];

            long count = Min(a[t], d);
            cost += c[t] * count;
            a[t] -= count;
            d -= count;

            while (0 < d)
            {
                while (ptr < indexes.Length && a[indexes[ptr]] == 0) ptr++;
                if (ptr >= indexes.Length)
                {
                    cost = 0;
                    break;
                }

                count = Min(a[indexes[ptr]], d);
                cost += c[indexes[ptr]] * count;
                a[indexes[ptr]] -= count;
                d -= count;
            }
            costs.Add(cost);
        }
        Console.WriteLine(string.Join("\n", costs));
    }
}