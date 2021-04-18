// detail: https://atcoder.jp/contests/arc117/submissions/21864232
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
        //差が距離より大きいように
        int n = int.Parse(Console.ReadLine());

        List<(int, int)> edges = new List<(int, int)>();
        List<int>[] graph = Enumerable.Repeat(0, n).Select(_ => new List<int>()).ToArray();
        for (int i = 0; i < n - 1; i++)
        {
            var st = Console.ReadLine().Split().Select(x => int.Parse(x) - 1).ToArray();
            edges.Add((st[0], st[1]));
            @graph[st[0]].Add(st[1]);
            @graph[st[1]].Add(st[0]);
        }

        (int dist, int id) diamDfs(int node, int par)
        {
            var maxDist = 0;
            var maxId = node;
            foreach (var adj in graph[node])
            {
                if (adj == par) continue;
                var (dist, id) = diamDfs(adj, node);
                if (maxDist < dist)
                {
                    maxDist = dist;
                    maxId = id;
                }
            }
            return (maxDist + 1, maxId);
        }

        var (_, p1) = diamDfs(0, -1);
        var (_, p2) = diamDfs(p1, -1);

        Dictionary<(int, int), int> usedSet = new Dictionary<(int, int), int>();

        void use(int a, int b)
        {
            if (a > b) (a, b) = (b, a);
            if (!usedSet.ContainsKey((a, b))) usedSet[(a, b)] = 0;
            usedSet[(a, b)]++;
        }
        int getUsedCnt(int a, int b)
        {
            if (a > b) (a, b) = (b, a);
            if (!usedSet.ContainsKey((a, b))) return 0;
            return usedSet[(a, b)];
        }

        bool subtractDfs(int node, int par)
        {
            bool childHasP2 = node == p2;
            foreach (var adj in graph[node])
            {
                if (adj == par) continue;
                childHasP2 |= subtractDfs(adj, node);
            }
            if (childHasP2 && par != -1) use(node, par);
            return childHasP2;
        }

        subtractDfs(p1, -1);
        
        int[] res = new int[n];
        int nxt = 1;
        void constructDfs(int node, int par)
        {
            res[node] = nxt; nxt++;
            int usedNode = -1;
            foreach (var adj in graph[node])
            {
                if (adj == par) continue;
                var usedCnt = getUsedCnt(node, adj);
                if (2 <= usedCnt) throw new Exception();
                if (usedCnt == 1)
                {
                    if (usedNode != -1) throw new Exception();
                    usedNode = adj;
                    continue;
                }
                use(node, adj);
                constructDfs(adj, node);
                nxt++;
            }
            if (usedNode != -1) constructDfs(usedNode, node);
            if (par != -1) use(node, par);
        }
        constructDfs(p1, -1);

        Console.WriteLine(string.Join(" ", res));
    }
}
