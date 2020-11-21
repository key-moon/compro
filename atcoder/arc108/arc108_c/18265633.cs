// detail: https://atcoder.jp/contests/arc108/submissions/18265633
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
        List<(int, int)>[] graph = Enumerable.Repeat(0, n).Select(_ => new List<(int, int)>()).ToArray();
        for (int i = 0; i < m; i++)
        {
            var stc = Console.ReadLine().Split().Select(x => int.Parse(x)).ToArray();
            int s = stc[0] - 1, t = stc[1] - 1, c = stc[2];
            graph[s].Add((t, c));
            graph[t].Add((s, c));
        }
        int[] res = new int[n];

        Stack<int> stack = new Stack<int>();
        stack.Push(0);
        res[0] = 1;
        while (stack.Count != 0)
        {
            var elem = stack.Pop();
            int curCol = res[elem];
            foreach (var (adj, c) in graph[elem])
            {
                if (res[adj] != 0) continue;
                var nCol = c;
                if (c == curCol) nCol = ((nCol == n) ? 1 : (nCol + 1));
                res[adj] = nCol;
                stack.Push(adj);
            }
        }
        Console.WriteLine(string.Join("\n", res));
    }
}