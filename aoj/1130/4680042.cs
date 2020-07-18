// detail: https://onlinejudge.u-aizu.ac.jp/status/users/keymoon/submissions/1/1130/judge/4680042/C#
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
        while (true)
        {
            var wh = Console.ReadLine().Split().Select(int.Parse).ToArray();
            var w = wh[0];
            var h = wh[1];
            if (w == 0) break;
            var map = Enumerable.Repeat(0, h).SelectMany(_ => Console.ReadLine()).ToArray();

            List<int>[] graph = Enumerable.Repeat(0, h * w).Select(_ => new List<int>()).ToArray();
            for (int i = 0; i < h - 1; i++)
                for (int j = 0; j < w; j++)
                { var id = i * w + j; graph[id].Add(id + w); graph[id + w].Add(id); }
            for (int i = 0; i < h; i++)
                for (int j = 0; j < w - 1; j++)
                { var id = i * w + j; graph[id].Add(id + 1); graph[id + 1].Add(id); }

            var sInd = Array.IndexOf(map, '@');


            int res = 0;
            var arrived = new bool[w * h];
            Stack<int> stack = new Stack<int>();
            stack.Push(sInd);
            arrived[sInd] = true;
            while (stack.Count != 0)
            {
                var elem = stack.Pop();
                res++;
                foreach (var item in graph[elem])
                {
                    if (map[item] == '#') continue;
                    if (arrived[item]) continue;
                    arrived[item] = true;
                    stack.Push(item);
                }
            }
            Console.WriteLine(res);
        }
    }
}
