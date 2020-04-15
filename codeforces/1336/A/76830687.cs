// detail: https://codeforces.com/contest/1336/submission/76830687
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
        var nk = Console.ReadLine().Split().Select(int.Parse).ToArray();
        var n = nk[0];
        var k = nk[1];

        List<int>[] graph = Enumerable.Repeat(0, n).Select(_ => new List<int>()).ToArray();
        for (int i = 0; i < n - 1; i++)
        {
            var st = Console.ReadLine().Split().Select(x => int.Parse(x) - 1).ToArray();
            graph[st[0]].Add(st[1]);
            graph[st[1]].Add(st[0]);
        }

        long[] depth = new long[n];
        int[] parents = new int[n];
        int[] order = new int[n];
        var index = 0;
        Stack<int> stack = new Stack<int>();
        stack.Push(0);
        parents[0] = -1;
        while (stack.Count > 0)
        {
            var node = stack.Pop();
            order[index++] = node;
            for (int i = 0; i < graph[node].Count; i++)
            {
                var adjacent = graph[node][i];
                if (adjacent == parents[node]) continue;
                stack.Push(adjacent);
                depth[adjacent] = depth[node] + 1;
                parents[adjacent] = node;
            }
        }

        int[] subtreeSize = new int[n];
        for (int i = order.Length - 1; i >= 0; i--)
        {
            var elem = order[i];
            foreach (var item in graph[elem])
                subtreeSize[elem] += subtreeSize[item];
            depth[elem] -= subtreeSize[elem];
            subtreeSize[elem]++;
        }

        Console.WriteLine(depth.OrderByDescending(x => x).Take(k).Sum());
    }
}

