// detail: https://atcoder.jp/contests/abc190/submissions/19798046
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
        var nm = Console.ReadLine().Split().Select(int.Parse).ToArray();
        var n = nm[0];
        var m = nm[1];
        List<int>[] graph = Enumerable.Repeat(0, n).Select(_ => new List<int>()).ToArray();
        for (int i = 0; i < m; i++)
        {
            var st = Console.ReadLine().Split().Select(x => int.Parse(x) - 1).ToArray();
            graph[st[0]].Add(st[1]);
            graph[st[1]].Add(st[0]);
        }
        var k = int.Parse(Console.ReadLine());
        var c = Console.ReadLine().Split().Select(x => int.Parse(x) - 1).ToArray();

        var distMat = Enumerable.Range(0, k).Select(_ => Enumerable.Repeat(int.MaxValue / 2, k).ToArray()).ToArray();
        for (int i = 0; i < k; i++)
        {
            int[] dist = Enumerable.Repeat(int.MaxValue / 2, n).ToArray();
            var stack = new Queue<int>();
            dist[c[i]] = 0;
            stack.Enqueue(c[i]);
            while (stack.Count > 0)
            {
                var elem = stack.Dequeue();
                var nxtDist = dist[elem] + 1;
                foreach (var adj in graph[elem])
                {
                    if (dist[adj] <= nxtDist) continue;
                    dist[adj] = nxtDist;
                    stack.Enqueue(adj);
                }
            }
            for (int j = 0; j < k; j++)
            {
                distMat[i][j] = dist[c[j]];
            }
        }

        var dp = Enumerable.Range(0, 1 << k).Select(_ => Enumerable.Repeat(int.MaxValue / 2, k).ToArray()).ToArray();
        for (int i = 0; i < k; i++) dp[1 << i][i] = 0;
        for (int b = 0; b < (1 << k); b++)
        {
            for (int i = 0; i < k; i++)
            {
                if ((b >> i & 1) != 1) continue;
                for (int j = 0; j < k; j++)
                {
                    if ((b >> j & 1) == 1) continue;
                    dp[b | (1 << j)][j] = Min(dp[b | (1 << j)][j], dp[b][i] + distMat[i][j]);
                }
            }
        }
        var res = dp.Last().Min();
        if (res == int.MaxValue / 2) res = -1;
        else res += 1;
        Console.WriteLine(res);
    }
}