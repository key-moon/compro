// detail: https://atcoder.jp/contests/arc116/submissions/21363746
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
        //適当な葉からDFSして2a行ったら切る を繰り返して被覆可能か
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
        var leafInd = graph.TakeWhile(x => x.Count != 1).Count();
        
        int valid = n;
        int invalid = 0;
        while (valid - invalid > 1)
        {
            var mid = (valid + invalid) / 2;

            int cnt = 0;

            (int, bool) DFS(int node, int par)
            {
                int maxSpare = -1;
                int maxDist = 0;
                foreach (var adj in graph[node])
                {
                    if (adj == par) continue;
                    var (res, safe) = DFS(adj, node);
                    if (safe) maxSpare = Max(maxSpare, res);
                    else maxDist = Max(maxDist, res);
                }
                if (maxSpare < maxDist)
                {
                    if (maxDist == mid)
                    {
                        cnt++;
                        return (mid - 1, true);
                    }
                    return (maxDist + 1, false);
                }
                else
                {
                    return (maxSpare - 1, true);
                }
            }

            var (_, safe) = DFS(leafInd, -1);
            if (!safe) cnt++;

            if (cnt <= k) valid = mid;
            else invalid = mid;
        }
        Console.WriteLine(valid);
    }
}