// detail: https://codeforces.com/contest/781/submission/87421507
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

        List<int>[] graph = Enumerable.Repeat(0, n).Select(_ => new List<int>()).ToArray();
        for (int i = 0; i < n - 1; i++)
        {
            var st = Console.ReadLine().Split().Select(x => int.Parse(x) - 1).ToArray();
            graph[st[0]].Add(st[1]);
            graph[st[1]].Add(st[0]);
        }

        var color = graph.Max(x => x.Count + 1);
        Console.WriteLine(color);
        int[] res = new int[n];
        int[] prevColor = new int[n];
        Stack<int> stack = new Stack<int>();
        res[0] = 1;
        stack.Push(0);
        while (stack.Count != 0)
        {
            int curColor = 1;
            var elem = stack.Pop();
            foreach (var adj in graph[elem])
            {
                if (res[adj] != 0) continue;
                while (curColor == res[elem] || curColor == prevColor[elem]) curColor++;
                res[adj] = curColor;
                curColor++;
                prevColor[adj] = res[elem];
                stack.Push(adj);
            }
        }

        Console.WriteLine(string.Join(" ", res));
    }
}
