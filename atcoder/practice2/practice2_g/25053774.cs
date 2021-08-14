// detail: https://atcoder.jp/contests/practice2/submissions/25053774
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
            var st = Console.ReadLine().Split().Select(int.Parse).ToArray();
            graph[st[0]].Add(st[1]);
        }
        var (grouped, componentID) = StronglyConnectedComponent(graph);
        Console.WriteLine(grouped.Length);
        foreach (var group in grouped)
        {
            Console.WriteLine($"{group.Length} {string.Join(" ", group)}");
        }
    }

    static (int[][], int[]) StronglyConnectedComponent(List<int>[] graph)
    {
        int n = graph.Length;
        bool[] arrived = new bool[n];
        List<int> order = new List<int>(n);
        Stack<int> stack = new Stack<int>(Enumerable.Range(0, n).Reverse());
        while (stack.Count != 0)
        {
            var elem = stack.Pop();
            if (elem < 0)
            {
                order.Add(~elem);
                continue;
            }
            if (arrived[elem]) continue;
            arrived[elem] = true;
            stack.Push(~elem);
            foreach (var adj in graph[elem])
            {
                if (arrived[adj]) continue;
                arrived[elem] = true;
                stack.Push(adj);
            }
        }

        List<int>[] reversed = Enumerable.Repeat(0, n).Select(_ => new List<int>()).ToArray();
        for (int s = 0; s < n; s++)
        {
            foreach (var t in graph[s])
            {
                reversed[t].Add(s);
            }
        }

        int[] componentID = Enumerable.Repeat(-1, n).ToArray();
        List<int[]> components = new List<int[]>();
        foreach (var item in order.Reverse<int>())
        {
            if (componentID[item] != -1) continue;
            int currentID = components.Count;
            componentID[item] = currentID;
            List<int> currentComponent = new List<int>();
            stack.Clear();
            stack.Push(item);
            while (stack.Count != 0)
            {
                var node = stack.Pop();
                currentComponent.Add(node);
                foreach (var adj in reversed[node])
                {
                    if (componentID[adj] != -1) continue;
                    componentID[adj] = currentID;
                    stack.Push(adj);
                }
            }
            components.Add(currentComponent.ToArray());
        }
        return (components.ToArray(), componentID);
    }
}