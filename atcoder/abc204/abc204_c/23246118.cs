// detail: https://atcoder.jp/contests/abc204/submissions/23246118
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
        var nm = Console.ReadLine().Split().Select(int.Parse).ToArray();
        var n = nm[0];
        var m = nm[1];

        List<int>[] graph = Enumerable.Repeat(0, n).Select(_ => new List<int>()).ToArray();
        for (int i = 0; i < m; i++)
        {
            var st = Console.ReadLine().Split().Select(x => int.Parse(x) - 1).ToArray();
            graph[st[0]].Add(st[1]);
        }

        long res = 0;
        for (int i = 0; i < n; i++)
        {
            bool[] dp = new bool[n];

            Stack<int> stack = new Stack<int>();
            dp[i] = true;
            stack.Push(i);
            while (stack.Count != 0)
            {
                var node = stack.Pop();
                foreach (var adj in graph[node])
                {
                    if (dp[adj]) continue;
                    dp[adj] = true;
                    stack.Push(adj);
                }
            }
            res += dp.Count(x => x);
        }

        Console.WriteLine(res);
    }
}
