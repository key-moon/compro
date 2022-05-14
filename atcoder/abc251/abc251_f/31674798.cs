// detail: https://atcoder.jp/contests/abc251/submissions/31674798
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

        {
            bool[] arrived = new bool[n];
            Stack<(int, int)> stack = new Stack<(int, int)>();
            stack.Push((0, -1));
            while (stack.Count != 0)
            {
                var (node, par) = stack.Pop();
                if (arrived[node]) continue;
                arrived[node] = true;
                if (par != -1) Console.WriteLine($"{node + 1} {par + 1}");
                foreach (var adj in graph[node])
                {
                    if (arrived[adj]) continue;
                    stack.Push((adj, node));
                }
            }
        }

        {
            bool[] arrived = new bool[n];
            Queue<(int, int)> stack = new Queue<(int, int)>();
            stack.Enqueue((0, -1));
            while (stack.Count != 0)
            {
                var (node, par) = stack.Dequeue();
                if (arrived[node]) continue;
                arrived[node] = true;
                if (par != -1) Console.WriteLine($"{node + 1} {par + 1}");
                foreach (var adj in graph[node])
                {
                    if (arrived[adj]) continue;
                    stack.Enqueue((adj, node));
                }
            }
        }
    }
}