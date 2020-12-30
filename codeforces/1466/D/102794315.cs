// detail: https://codeforces.com/contest/1466/submission/102794315
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
        int n = int.Parse(Console.ReadLine());
        var w = Console.ReadLine().Split().Select(long.Parse).ToArray();

        List<int>[] graph = Enumerable.Repeat(0, n).Select(_ => new List<int>()).ToArray();
        for (int i = 0; i < n - 1; i++)
        {
            var st = Console.ReadLine().Split().Select(x => int.Parse(x) - 1).ToArray();
            graph[st[0]].Add(st[1]);
            graph[st[1]].Add(st[0]);
        }

        List<long> list = new List<long>();
        for (int i = 0; i < n; i++)
        {
            for (int cnt = 0; cnt < graph[i].Count - 1; cnt++) list.Add(w[i]);
        }

        List<long> res = new List<long>();
        long cursum = w.Sum();
        res.Add(cursum);
        foreach (var item in list.OrderByDescending(x => x))
        {
            cursum += item;
            res.Add(cursum);
        }

        Console.WriteLine(string.Join(" ", res));
    }
}
