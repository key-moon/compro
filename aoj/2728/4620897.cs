// detail: https://onlinejudge.u-aizu.ac.jp/status/users/keymoon/submissions/1/2728/judge/4620897/C#
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
    static long UB;
    static long N;
    public static void Main()
    {
        string s = Console.ReadLine();
        N = long.Parse(s);
        int[] canUse = Enumerable.Repeat(1, 10).ToArray();
        var dig = (long)Math.Pow(10, s.Length - 1);
        UB = dig * 10;

        Console.WriteLine(Solve(0, dig, canUse).ToString().PadLeft(s.Length, '0'));
    }

    static long GetDiff(long a, long b) => Min(Abs(a - b), UB - Abs(a - b));

    static long Solve(long num, long currentDig, int[] canUse)
    {
        if (currentDig == 0) return num;

        List<Tuple<long, int>> reses = new List<Tuple<long, int>>();
        for (int i = 0; i < 10; i++)
        {
            if (canUse[i] <= 0) continue;
            var diff = GetDiff(N, num + i * currentDig);
            reses.Add(new Tuple<long, int>(diff, i));
        }

        reses.Sort();reses.Reverse();
        long finalDiff = 0;
        long res = -1;

        Action<Tuple<long, int>> update = item =>
        {
            var i = item.Item2;

            var nextCanUse = canUse.ToArray();
            nextCanUse[i]--;
            var curRes = Solve(num + i * currentDig, currentDig / 10, nextCanUse);
            var diff = GetDiff(N, curRes);
            if (diff > finalDiff || (diff == finalDiff && curRes < res))
            {
                finalDiff = diff;
                res = curRes;
            }
        };

        foreach (var item in reses.OrderByDescending(x => x.Item1).ThenBy(x => x.Item2).Take(3))
        {
            update(item);
        }

        return res;
    }
}



struct Top2<T> where T : IComparable
{
    public T First;
    public T Second;
    public Top2(T first, T second) { First = first; Second = second; }
    public static Top2<T> Merge(Top2<T> a, Top2<T> b)
    {
        if (a.First.CompareTo(b.First) > 0)
            return new Top2<T>(a.First, a.Second.CompareTo(b.First) > 0 ? a.Second : b.First);
        else
            return new Top2<T>(b.First, b.Second.CompareTo(a.First) > 0 ? b.Second : a.First);
    }
    public static Top2<T> Merge(Top2<T> a, T b)
    {
        if (a.Second.CompareTo(b) > 0) return a;
        if (a.First.CompareTo(b) > 0) return new Top2<T>(a.First, b);
        return new Top2<T>(b, a.First);
    }
    public static Top2<T> operator |(Top2<T> a, Top2<T> b) => Merge(a, b);
    public static Top2<T> operator |(Top2<T> a, T b) => Merge(a, b);
}
