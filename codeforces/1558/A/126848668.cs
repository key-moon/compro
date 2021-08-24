// detail: https://codeforces.com/contest/1558/submission/126848668
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
        var ab = Console.ReadLine().Split().Select(int.Parse).ToArray();
        var a = ab[0];
        var b = ab[1];
        var total = a + b;
        var res = new List<int>();
        if (total % 2 == 1)
        {
            res.AddRange(Solve(total / 2, total / 2 + 1, a, b));
            res.AddRange(Solve(total / 2 + 1, total / 2, a, b));
        }
        else
        {
            res.AddRange(Solve(total / 2, total / 2, a, b));
        }
        Console.WriteLine(res.Count);
        Console.WriteLine(string.Join(" ", res.OrderBy(x => x)));
    }
    static IEnumerable<int> Solve(int serve, int recieve, int win, int lose)
    {
        int min = Abs(serve - win);
        int max = win + lose - Abs(serve - lose);
        for (int i = min; i <= max; i += 2)
        {
            yield return i;
        }
    }
}
