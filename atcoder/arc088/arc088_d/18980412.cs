// detail: https://atcoder.jp/contests/arc088/submissions/18980412
//□□□□□□□□□□□□□□□□□□□□□□□□□□□□□□□□□□□□□□□□□□□□□
//■□□□□□■□□□□□□□□□□□□□□□□□□□□□□□□□□□□□□□□□□□□□□
//■■□□□■■□□□□□□□□□□□□□□□□□□□□□□□□□□□□□□□□□□□□□□
//■□■□■□■□□□□□□□□□□□□□□□□□□□□□□□□□□□□□□□□□□□□□□
//■□■□■□■□□□□□□□□□□□□□□□□□□□□□□□□□□□□□□□□□□□□□□
//■□■□■□■□□□□■■■□□□□■■■□■■□□□■■■□■■□□□■■■□□■■■□
//■□□■□□■□□□■□□□■□□□□□■■□□■□□□□■■□□■□□□■□□□□■□□
//■□□■□□■□□■□□□□□■□□□□■□□□■□□□□■□□□■□□□□■□□□■□□
//■□□■□□■□□■■■■■■■□□□□■□□□□□□□□■□□□□□□□□■□□■□□□
//■□□□□□■□□■□□□□□□□□□□■□□□□□□□□■□□□□□□□□□■□■□□□
//■□□□□□■□□■□□□□□□□□□□■□□□□□□□□■□□□□□□□□□□■□□□□
//■□□□□□■□□■□□□□□■□□□□■□□□□□□□□■□□□□□□□□□□■□□□□
//■□□□□□■□□□■□□□□■□□□□■□□□□□□□□■□□□□□□□□□■□□□□□
//■■□□□■■□□□□■■■■□□□■■■■■■□□□■■■■■■□□□■□□■□□□□□
//□□□□□□□□□□□□□□□□□□□□□□□□□□□□□□□□□□□□■□■□□□□□□
//□□□□□□□□□□□□□□□□□□□□□□□□□□□□□□□□□□□□□■□□□□□□□
//□□□□□□□□□□□□□□□□□□□□□□□□□□□□□□□□□□□□
//■■■□■■■□□□□□□□□□□□□□□□□□□□□□□□□□□□□□
//□■□□□■□□□□□□□□□□□□□□□□□□□□□□□□□□□□□□
//□■□□□■□□□□□□□□□□□□□□□□□□□□□□□□□□□□□□
//□□■□■□□□□□□□□□□□□□□□□□□□□□□□□□□□□□□□
//□□■□■□□□□□■■□■■□□□□□■■■■□□□□□■■■□■□□
//□□□■□□□□□■□□■□□■□□□■□□□□■□□□■□□□■■□□
//□□■□■□□□□■□□■□□■□□□□□□□□■□□□■□□□□■□□
//□□■□■□□□□■□□■□□■□□□□■■■■■□□□■□□□□□□□
//□□■□■□□□□■□□■□□■□□□■□□□□■□□□□■■■■□□□
//□■□□□■□□□■□□■□□■□□■□□□□□■□□□□□□□□■□□
//□■□□□■□□□■□□■□□■□□■□□□□□■□□■□□□□□■□□
//■□□□□□■□□■□□■□□■□□■□□□□■■□□■■□□□□■□□
//■■□□□■■□□■■□■■□■■□□■■■■□■■□■□■■■■□□□
//□□□□□□□□□□□□□□□□□□□□□□□□□□□□□□□□□□□□
//□□□□□□□□□□□□□□□□□□□□□□□□□□□□□□□□□□□□

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
        int n = int.Parse(Console.ReadLine());

        List<int>[] graph = Enumerable.Repeat(0, n).Select(_ => new List<int>()).ToArray();
        for (int i = 0; i < n - 1; i++)
        {
            var st = Console.ReadLine().Split().Select(x => int.Parse(x) - 1).ToArray();
            graph[st[0]].Add(st[1]);
            graph[st[1]].Add(st[0]);
        }

        var cnt = graph.Sum(x => (x.Count - 1) / 2) + 1;

        int DFS(int root, int prev, int mid, ref bool res)
        {
            if (!res) return -1;

            List<int> edges = new List<int>();
            foreach (var adj in graph[root])
            {
                if (prev == adj) continue;
                edges.Add(DFS(adj, root, mid, ref res) + 1);
            }

            if (!res) return -1;
            edges.Sort();
            if (edges.Any() && mid < edges.Last()) { res = false; return -1; }

            redo:;
            int spare = edges.Count % 2;
            int[] pair = new int[edges.Count / 2];
            int[] groupId = new int[edges.Count];
            int invalidCnt = 0;
            for (int i = 0; i < pair.Length; i++)
            {
                pair[i] = edges[i + spare] + edges[edges.Count - 1 - i];
                groupId[i + spare] = i;
                groupId[edges.Count - 1 - i] = i;
                if (mid < pair[i]) invalidCnt++;
            }

            if (spare == 0)
            {
                if (invalidCnt == 0) return 0;
                if (prev == -1) { res = false; return -1; }
                edges.RemoveAt(edges.Count - 1);
                goto redo;
            }

            if (invalidCnt == 0) return edges[0];
            for (int i = 1; i < edges.Count; i++)
            {
                if (mid < pair[groupId[i]]) invalidCnt--;
                pair[groupId[i]] -= edges[i];

                groupId[i - 1] = groupId[i];

                pair[groupId[i - 1]] += edges[i - 1];
                if (mid < pair[groupId[i - 1]]) invalidCnt++;

                if (invalidCnt == 0) return edges[i];
            }
            res = false;
            return -1;
        }

        int valid = n;
        int invalid = 0;
        while (valid - invalid > 1)
        {
            bool res = true;
            var mid = (valid + invalid) / 2;
            DFS(0, -1, mid, ref res);
            if (res) valid = mid;
            else invalid = mid;
        }
        Console.WriteLine($"{cnt} {valid}");
    }
}
