// detail: https://codeforces.com/contest/1470/submission/103435704
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
using MethodImplAttribute = System.Runtime.CompilerServices.MethodImplAttribute;
using MethodImplOptions = System.Runtime.CompilerServices.MethodImplOptions;

public static class P
{
    public static void Main()
    {
        Console.SetOut(new StreamWriter(Console.OpenStandardOutput()) { AutoFlush = false });
        int t = int.Parse(Console.ReadLine());
        for (int i = 0; i < t; i++)
        {
            Solve();
        }
        Console.Out.Flush();
    }
    static void Solve()
    {
        int n = int.Parse(Console.ReadLine());
        var a = Console.ReadLine().Split().Select(int.Parse).ToArray();
        Dictionary<long, int> cnts = new Dictionary<long, int>();
        foreach (var item in a)
        {
            long total = 1;
            foreach (var group in PrimeFactors(item).GroupBy(x => x))
            {
                if (group.Count() % 2 == 0) continue;
                total *= group.Key;
            }
            if (!cnts.ContainsKey(total)) cnts[total] = 0;
            cnts[total]++;
        }
        int initRes = 0;

        int square = 0;
        int nonSqMax = 0;
        foreach (var (val, cnt) in cnts)
        {
            initRes = Max(initRes, cnt);
            var sqrt = (int)Ceiling(Sqrt(val));
            if (cnt % 2 == 0 || val == sqrt * sqrt) square += cnt;
            else nonSqMax = Max(nonSqMax, cnt);
        }
        int res = Max(square, nonSqMax);

        var Q = int.Parse(Console.ReadLine());
        for (int i = 0; i < Q; i++)
        {
            var q = long.Parse(Console.ReadLine());
            if (q == 0) Console.WriteLine(initRes);
            else Console.WriteLine(res);
        }
    }

    static IEnumerable<long> PrimeFactors(long n)
    {
        while ((n & 1) == 0)
        {
            n >>= 1;
            yield return 2;
        }
        for (long i = 3; i * i <= n; i += 2)
        {
            while (n % i == 0)
            {
                n /= i;
                yield return i;
            }
        }
        if (n != 1) yield return n;
    }
}
