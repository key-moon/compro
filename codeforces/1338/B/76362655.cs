// detail: https://codeforces.com/contest/1338/submission/76362655
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
        var n = int.Parse(Console.ReadLine());
        List<int>[] graph = Enumerable.Repeat(0, n).Select(_ => new List<int>()).ToArray();
        for (int i = 0; i < n - 1; i++)
        {
            var st = Console.ReadLine().Split().Select(x => int.Parse(x) - 1).ToArray();
            graph[st[0]].Add(st[1]);
            graph[st[1]].Add(st[0]);
        }
        var min = GetMin(n, graph);
        var max = GetMax(n, graph);
        Console.WriteLine($"{min} {max}");
    }
    public static int GetMin(int n, List<int>[] graph)
    {
        bool[] haveLeaf = new bool[n];
        for (int i = 0; i < graph.Length; i++)
        {
            if (graph[i].Count == 1) haveLeaf[i] = true;
        }
        int[] distance = new int[n];
        var orig = haveLeaf.TakeWhile(x => !x).Count();
        distance[orig] = 1;
        Stack<int> stack = new Stack<int>();
        stack.Push(orig);
        while (stack.Count > 0)
        {
            var elem = stack.Pop();
            foreach (var item in graph[elem])
            {
                if (distance[item] != 0) continue;
                distance[item] = distance[elem] + 1;
                stack.Push(item);
            }
        }
        for (int i = 0; i < n; i++)
        {
            if (distance[i] % 2 == 0 && haveLeaf[i]) return 3;
        }
        return 1;
    }
    public static int GetMax(int n, List<int>[] graph)
    {
        var taboo = graph.Where(x => x.Count == 1).Select(x => x[0]).GroupBy(x => x).Sum(x => x.Count() - 1);
        return n - 1 - taboo;
    }
}