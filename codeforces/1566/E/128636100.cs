// detail: https://codeforces.com/contest/1566/submission/128636100
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
        //(\sum_{node \in bud} ord(node)-1) + 1
        // 全てのノードについて、その子の(葉の個数-1)の合計+1
        int n = int.Parse(Console.ReadLine());

        List<int>[] @graph = Enumerable.Repeat(0, n).Select(_ => new List<int>()).ToArray();
        for (int i = 0; i < n - 1; i++)
        {
            var st = Console.ReadLine().Split().Select(x => int.Parse(x) - 1).ToArray();
            @graph[st[0]].Add(st[1]);
            @graph[st[1]].Add(st[0]);
        }
        int[] par = new int[n];
        bool[] leafable = new bool[n];
        Stack<int> stack = new Stack<int>();
        Stack<int> rev = new Stack<int>();
        par[0] = -1;
        stack.Push(0);
        rev.Push(0);
        while (stack.Count != 0)
        {
            var node = stack.Pop();
            rev.Push(node);
            foreach (var adj in graph[node])
            {
                if (adj == par[node]) continue;
                par[adj] = node;
                stack.Push(adj);
            }
        }
        while (rev.Count != 0)
        {
            var node = rev.Pop();
            leafable[node] = true;
            foreach (var adj in graph[node])
            {
                if (adj == par[node]) continue;
                if (leafable[adj]) leafable[node] = false;
            }
        }
        int res = 1;
        for (int node = 0; node < n; node++)
        {
            int curRes = 0;
            foreach (var adj in graph[node])
            {
                if (adj == par[node]) continue;
                if (leafable[adj]) curRes++;
            }
            if (0 < curRes) curRes--;
            res += curRes;
        }
        Console.WriteLine(res);
    }
}