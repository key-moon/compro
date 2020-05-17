// detail: https://atcoder.jp/contests/abc168/submissions/13341562
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
        Console.WriteLine("Yes");

        List<int>[] graph = Enumerable.Repeat(0, n).Select(_ => new List<int>()).ToArray();
        for (int i = 0; i < m; i++)
        {
            var st = Console.ReadLine().Split().Select(x => int.Parse(x) - 1).ToArray();
            graph[st[0]].Add(st[1]);
            graph[st[1]].Add(st[0]);
        }

        int[] res = new int[n];
        res[0] = -1;
        Queue<int> stack = new Queue<int>();
        stack.Enqueue(0);
        while (stack.Count != 0)
        {
            var elem = stack.Dequeue();
            foreach (var item in graph[elem])
            {
                if (res[item] != 0) continue;
                res[item] = elem + 1;
                stack.Enqueue(item);
            }
        }


        Console.WriteLine(string.Join("\n", res.Skip(1)));
    }
}
