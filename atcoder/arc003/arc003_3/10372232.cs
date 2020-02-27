// detail: https://atcoder.jp/contests/arc003/submissions/10372232
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
        var map = Enumerable.Repeat(0, nm[0]).SelectMany(_ => Console.ReadLine()).ToArray();

        var start = Array.IndexOf(map, 's');
        var goal = Array.IndexOf(map, 'g');

        var brightness = map.Select(x => x == '#' ? 0 : x == 'g' ? 100 : x - '0').ToArray();

        List<int>[] graph = Enumerable.Repeat(0, nm[0] * nm[1]).Select(_ => new List<int>()).ToArray();
        for (int i = 0; i < nm[0] - 1; i++)
            for (int j = 0; j < nm[1]; j++)
            { var id = i * nm[1] + j; graph[id].Add(id + nm[1]); graph[id + nm[1]].Add(id); }
        for (int i = 0; i < nm[0]; i++)
            for (int j = 0; j < nm[1] - 1; j++)
            { var id = i * nm[1] + j; graph[id].Add(id + 1); graph[id + 1].Add(id); }

        bool[] arrived = new bool[map.Length];
        {
            Stack<int> stack = new Stack<int>();
            stack.Push(start);
            while (stack.Count > 0)
            {
                var item = stack.Pop();
                foreach (var adj in graph[item])
                {
                    if (arrived[adj]) continue;
                    if (map[adj] == '#') continue;
                    arrived[adj] = true;
                    stack.Push(adj);
                }
            }
            if (!arrived[goal])
            {
                Console.WriteLine(-1);
                return;
            }
        }

        var valid = 0.0;
        var invalid = 10.0;
        var listBuffer = new List<int>[] { new List<int>(), new List<int>() };
        int top = 0;
        for (int _ = 0; _ < 100; _++)
        {
            var mid = (valid + invalid) / 2;

            bool isValid = false;
            {
                for (int i = 0; i < arrived.Length; i++) arrived[i] = false;
                var queue = listBuffer[top ^= 1];
                queue.Clear();
                queue.Add(start);
                for (var darkness = 0.99; queue.Count != 0; darkness *= 0.99)
                {
                    var newQueue = listBuffer[top ^= 1];
                    newQueue.Clear();
                    foreach (var node in queue)
                    {
                        foreach (var adj in graph[node])
                        {
                            if (arrived[adj]) continue;
                            if (darkness * brightness[adj] < mid) continue;
                            arrived[adj] = true;
                            newQueue.Add(adj);
                        }
                    }
                    queue = newQueue;
                }
                isValid = arrived[goal];
            }
            if (isValid) valid = mid;
            else invalid = mid;
        }
        Console.WriteLine(valid);
    }
}
