// detail: https://codeforces.com/contest/1470/submission/103453330
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
        Console.SetOut(new StreamWriter(Console.OpenStandardOutput()) { AutoFlush = false });
        int t = int.Parse(Console.ReadLine());
        for (int i = 0; i < t; i++)
        {
            Solve();
        }
        Console.Out.Flush();
    }
    static void Solve()
    {
        var nk = Console.ReadLine().Split().Select(int.Parse).ToArray();
        var n = nk[0];
        var m = nk[1];

        List<int>[] graph = Enumerable.Repeat(0, n).Select(_ => new List<int>()).ToArray();
        for (int i = 0; i < m; i++)
        {
            var st = Console.ReadLine().Split().Select(x => int.Parse(x) - 1).ToArray();
            graph[st[0]].Add(st[1]);
            graph[st[1]].Add(st[0]);
        }
        int[] res = new int[n];
        Stack<int> stack = new Stack<int>();
        stack.Push(0);
        while (stack.Count != 0)
        {
            var elem = stack.Pop();
            if (res[elem] != 0) continue;
            res[elem] = 1;
            foreach (var item in graph[elem])
            {
                if (res[item] == 1) throw new Exception();
                if (res[item] != 0) continue;
                res[item] = -1;
                foreach (var item2 in graph[item])
                {
                    if (res[item2] != 0) continue;
                    stack.Push(item2);
                }
            }
        }
        if (res.Contains(0))
        {
            Console.WriteLine("NO");
            return;
        }
        Console.WriteLine("YES");
        var resList = res.Select((elem, ind) => (elem, ind)).Where(x => x.elem == 1).Select(x => x.ind + 1).ToArray();
        Console.WriteLine(resList.Length);
        Console.WriteLine(string.Join(" ", resList));
    }
}
