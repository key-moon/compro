// detail: https://atcoder.jp/contests/abc070/submissions/16040959
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

        List<(int, long)>[] graph = Enumerable.Repeat(0, n).Select(_ => new List<(int, long)>()).ToArray();
        for (int i = 0; i < n - 1; i++)
        {
            var stc = Console.ReadLine().Split().Select(x => int.Parse(x) - 1).ToArray();
            graph[stc[0]].Add((stc[1], stc[2] + 1));;
            graph[stc[1]].Add((stc[0], stc[2] + 1));
        }

        var qk = Console.ReadLine().Split().Select(int.Parse).ToArray();
        var q = qk[0];
        var k = qk[1] - 1;
        long[] dists = Enumerable.Repeat(-1L, n).ToArray();
        Stack<int> stack = new Stack<int>();
        stack.Push(k);
        dists[k] = 0;
        while (stack.Count > 0)
        {
            var elem = stack.Pop();

            foreach (var (id, cost) in graph[elem])
            {
                if (dists[id] != -1) continue;
                dists[id] = dists[elem] + cost;
                stack.Push(id);
            }
        }

        for (int i = 0; i < q; i++)
        {
            var xy = Console.ReadLine().Split().Select(x => int.Parse(x) - 1).ToArray();
            Console.WriteLine(dists[xy[0]] + dists[xy[1]]);
        }
    }
}