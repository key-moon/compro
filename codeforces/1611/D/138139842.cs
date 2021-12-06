// detail: https://codeforces.com/contest/1611/submission/138139842
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
        int t = int.Parse(Console.ReadLine());
        for (int i = 0; i < t; i++)
        {
            Solve();
        }
    }
    static void Solve()
    {
        int n = int.Parse(Console.ReadLine());
        var a = Console.ReadLine().Split().Select(x => int.Parse(x) - 1).ToArray();
        var b = Console.ReadLine().Split().Select(x => int.Parse(x) - 1).ToArray();

        var root = -1;
        for (int i = 0; i < n; i++)
        {
            if (a[i] == i)
            {
                root = i;
                continue;
            }
        }
        var minDist = 1;
        var dist = new int[n];
        var res = new int[n];
        dist[root] = minDist;
        if (b[0] != root)
        {
            Console.WriteLine(-1);
            return;
        }
        foreach (var node in b.Skip(1))
        {
            if (dist[a[node]] == 0)
            {
                Console.WriteLine(-1);
                return;
            }
            dist[node] = minDist + 1;
            res[node] = dist[node] - dist[a[node]];
            minDist++;
        }

        Console.WriteLine(string.Join(" ", res));
    }
}