// detail: https://onlinejudge.u-aizu.ac.jp/status/users/keymoon/submissions/1/ALDS1_7_B/judge/4774206/C#
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

        int[] siblings = Enumerable.Repeat(-1, n).ToArray();
        int[] parents = Enumerable.Repeat(-1, n).ToArray();
        List<int>[] childs = Enumerable.Repeat(0, n).Select(_ => new List<int>()).ToArray();
        for (int i = 0; i < n; i++)
        {
            var data = Console.ReadLine().Split().Select(int.Parse).ToArray();
            var id = data[0];
            var l = data[1];
            var r = data[2];
            for (int _ = 0; _ < 2; _++)
            {
                if (l != -1)
                {
                    siblings[l] = r;
                    parents[l] = id;
                    childs[id].Add(l);
                }
                { var tmp = l; l = r; r = tmp; }
            }
        }

        int[] depths = new int[n];
        int[] heights = new int[n];
        Action<int> dfs = null;
        dfs = node =>
        {
            foreach (var item in childs[node])
            {
                depths[item] = depths[node] + 1;
                dfs(item);
                heights[node] = Max(heights[node], heights[item] + 1);
            }
        };
        dfs(Array.IndexOf(parents, -1));
        for (int i = 0; i < n; i++)
        {
            var degree = childs[i].Count;
            Console.WriteLine($"node {i}: parent = {parents[i]}, sibling = {siblings[i]}, degree = {degree}, depth = {depths[i]}, height = {heights[i]}, {(parents[i] == -1 ? "root" : degree == 0 ? "leaf" : "internal node")}");
        }
    }
}
