// detail: https://codeforces.com/contest/1439/submission/98725131
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
        var nmk = Console.ReadLine().Split().Select(int.Parse).ToArray();
        var n = nmk[0];
        var m = nmk[1];
        var k = nmk[2];

        HashSet<int>[] graph = Enumerable.Repeat(0, n).Select(_ => new HashSet<int>()).ToArray();
        for (int i = 0; i < m; i++)
        {
            var st = Console.ReadLine().Split().Select(x => int.Parse(x) - 1).ToArray();
            graph[st[0]].Add(st[1]);
            graph[st[1]].Add(st[0]);
        }
        //すべての頂点がk本以上の辺を持っている→頂点数は10^5/k個
        //kはat most sqrt(n)

        Stack<int> shouldRemove = new Stack<int>();
        HashSet<int> remain = new HashSet<int>(Enumerable.Range(0, n));
        HashSet<int> cliqueCands = new HashSet<int>();
        for (int i = 0; i < n; i++)
        {
            if (graph[i].Count == k - 1) cliqueCands.Add(i);
            if (graph[i].Count < k - 1) shouldRemove.Push(i);
        }
        do
        {
            while (shouldRemove.Count != 0)
            {
                var elem = shouldRemove.Pop();
                foreach (var adj in graph[elem])
                {
                    if (graph[adj].Remove(elem) && cliqueCands.Remove(adj)) shouldRemove.Push(adj);
                    if (graph[adj].Count == k - 1) cliqueCands.Add(adj);
                }
                graph[elem].Clear();
                remain.Remove(elem);
                cliqueCands.Remove(elem);
            }

            //全部k-1以上になったらfind cliques
            foreach (var cand in cliqueCands)
            {
                if (graph[cand].Count != k - 1) continue;
                var res = graph[cand].Append(cand).ToArray();
                for (int i = 0; i < res.Length; i++)
                {
                    for (int j = i + 1; j < res.Length; j++)
                    {
                        if (!graph[res[i]].Contains(res[j])) goto invalid;
                    }
                }
                Console.WriteLine(2);
                Console.WriteLine(string.Join(" ", res.Select(x => x + 1)));
                return;
                invalid:;
                //クリークにならないものは消す
                shouldRemove.Push(cand);
            }
            cliqueCands.Clear();
        }
        while (shouldRemove.Count != 0);

        if (remain.Count == 0)
        {
            Console.WriteLine(-1);
            return;
        }
        else
        {
            Console.WriteLine($"1 {remain.Count}");
            Console.WriteLine(string.Join(" ", remain.Select(x => x + 1)));
            return;
        }
    }
}
