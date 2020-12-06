// detail: https://codeforces.com/contest/1450/submission/100574251
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
        for (int i = 0; i < n; i++)
        {
            Solve();
        }
    }
    static void Solve()
    {
        var n = int.Parse(Console.ReadLine());
        var a = Console.ReadLine().Split().Select(int.Parse).ToArray();
        int begin = a[0];
        int prev = a[0];
        if (n + 1 < a.GroupBy(x => x).Max(x => x.Count()) * 2)
        {
            Console.WriteLine(-1);
            return;
        }
        List<(int, int)> tuples = new List<(int, int)>();
        void Add()
        {
            var (s, t) = (begin, prev);
            if (s > t) (s, t) = (t, s);
            tuples.Add((s, t));
        }
        for (int i = 1; i < a.Length; i++)
        {
            if (prev == a[i])
            {
                Add();
                begin = a[i];
            }
            prev = a[i];
        }
        Add();
        int res = tuples.Count - 1;
        var single = tuples.Where(x => x.Item1 == x.Item2).Select(x => x.Item1).ToArray();
        if (single.Length == 0)
        {
            Console.WriteLine(res);
            return;
        }
        var mostSingleGroup = single.GroupBy(x => x).OrderByDescending(x => x.Count()).First();
        var mostSingleKey = mostSingleGroup.Key;
        var mostSingle = mostSingleGroup.Count();
        var remainSingle = single.Length - mostSingle;

        var unusedSingle = Max(mostSingle - remainSingle, 0);

        var remainDouble = tuples.Where(x => x.Item1 != x.Item2 && x.Item1 != mostSingleKey && x.Item2 != mostSingleKey).Count();
        res += Max(0, unusedSingle - remainDouble - 1);

        if (n <= res) throw new Exception();
        Console.WriteLine(res);
    }
}
