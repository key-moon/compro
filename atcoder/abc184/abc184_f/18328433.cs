// detail: https://atcoder.jp/contests/abc184/submissions/18328433
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
        var nt = Console.ReadLine().Split().Select(int.Parse).ToArray();
        var n = nt[0];
        var t = nt[1];
        var a = Console.ReadLine().Split().Select(long.Parse).ToArray();
        IEnumerable<long> Enumerate(long[] arr)
        {
            for (int i = 0; i < (1 << arr.Length); i++)
            {
                long sum = 0;
                for (int j = 0; j < arr.Length; j++)
                {
                    if ((i >> j & 1) == 1) sum += arr[j];
                }
                if (sum <= t) yield return sum;
            }
        }
        var fst = Enumerate(a.Take(n / 2).ToArray()).OrderBy(x => x).ToArray();
        var snd = Enumerate(a.Skip(n / 2).ToArray()).OrderByDescending(x => x).ToArray();
        int j = 0;
        long res = 0;
        for (int i = 0; i < fst.Length; i++)
        {
            while (j < snd.Length && t < fst[i] + snd[j]) j++;
            if (j < snd.Length) res = Max(res, fst[i] + snd[j]);
        }
        Console.WriteLine(res);
    }
}