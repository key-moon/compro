// detail: https://codeforces.com/contest/1320/submission/72174726
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
        List<int>[] invgraph = Enumerable.Repeat(0, n).Select(_ => new List<int>()).ToArray();
        for (int i = 0; i < m; i++)
        {
            var st = Console.ReadLine().Split().Select(x => int.Parse(x) - 1).ToArray();
            graph[st[0]].Add(st[1]);
            invgraph[st[1]].Add(st[0]);
        }

        var k = int.Parse(Console.ReadLine());
        var p = Console.ReadLine().Split().Select(x => int.Parse(x) - 1).ToArray();

        var distanceFromGoal = Enumerable.Repeat((long)int.MaxValue, n).ToArray();
        distanceFromGoal[p.Last()] = 0;
        Queue<int> queue = new Queue<int>();
        queue.Enqueue(p.Last());
        while (queue.Count > 0)
        {
            var elem = queue.Dequeue();
            var nextDistance = distanceFromGoal[elem] + 1;
            foreach (var item in invgraph[elem])
            {
                if (distanceFromGoal[item] <= nextDistance) continue;
                distanceFromGoal[item] = nextDistance;
                queue.Enqueue(item);
            }
        }

        var lastPlace = p.First();
        var max = 0;
        var min = 0;
        foreach (var place in p.Skip(1))
        {
            if (distanceFromGoal[lastPlace] <= distanceFromGoal[place])
            {
                min++;
                max++;
            }
            else if (2 <= graph[lastPlace].Count(x => distanceFromGoal[x] == distanceFromGoal[place]))
            {
                max++;
            }
            lastPlace = place;
        }
        Console.WriteLine($"{min} {max}");
    }
}
