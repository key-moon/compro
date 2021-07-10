// detail: https://atcoder.jp/contests/abc209/submissions/24124914
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
        var nq = Console.ReadLine().Split().Select(int.Parse).ToArray();
        var n = nq[0];
        var q = nq[1];

        List<int>[] g = Enumerable.Repeat(0, n).Select(_ => new List<int>()).ToArray();
        for (int i = 0; i < n - 1; i++)
        {
            var st = Console.ReadLine().Split().Select(x => int.Parse(x) - 1).ToArray();
            g[st[0]].Add(st[1]);
            g[st[1]].Add(st[0]);
        }

        int[] dists = new int[n];
        void DFS(int node, int parent)
        {
            foreach (var adj in g[node])
            {
                if (adj == parent) continue;
                dists[adj] = dists[node] + 1;
                DFS(adj, node);
            }
        }
        dists[0] = 0;
        DFS(0, 0);
        for (int i = 0; i < q; i++)
        {
            var cd = Console.ReadLine().Split().Select(int.Parse).ToArray();
            var c = cd[0] - 1;
            var d = cd[1] - 1;

            Console.WriteLine((dists[c] + dists[d]) % 2 == 0 ? "Town" : "Road");
        }
    }
}