// detail: https://onlinejudge.u-aizu.ac.jp/status/users/keymoon/submissions/1/0435/judge/5497619/C#
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

        List<int>[] g = Enumerable.Repeat(0, n).Select(_ => new List<int>()).ToArray();
        List<int>[] invg = Enumerable.Repeat(0, n).Select(_ => new List<int>()).ToArray();
        for (int i = 0; i < m; i++)
        {
            var st = Console.ReadLine().Split().Select(x => int.Parse(x) - 1).ToArray();
            g[st[0]].Add(st[1]);
            invg[st[1]].Add(st[0]);
        }
        List<int> tpSorted = new List<int>();
        int[] inCnt = invg.Select(x => x.Count).ToArray();

        Stack<int> _stack = new Stack<int>();
        _stack.Push(0);
        while (_stack.Count != 0)
        {
            var elem = _stack.Pop();
            tpSorted.Add(elem);
            foreach (var adj in g[elem])
            {
                inCnt[adj]--;
                if (inCnt[adj] != 0) continue;
                _stack.Push(adj);
            }
        }


        Action<List<int>[], int, int[], long[], long[]> calc = (graph, begin, sorted, cnt, sumLen) =>
        {
            Stack<int> stack = new Stack<int>();
            cnt[begin] = 1;
            stack.Push(begin);
            foreach (var elem in sorted)
            {
                foreach (var adj in graph[elem])
                {
                    sumLen[adj] += sumLen[elem] + cnt[elem];
                    cnt[adj] += cnt[elem];
                }
            }
        };

        long[] cntFromStart = new long[n];
        long[] sumLenFromStart = new long[n];
        calc(g, 0, tpSorted.ToArray(), cntFromStart, sumLenFromStart);

        long[] cntFromEnd = new long[n];
        long[] sumLenFromEnd = new long[n];
        calc(invg, n - 1, tpSorted.Reverse<int>().ToArray(), cntFromEnd, sumLenFromEnd);

        for (int i = 0; i < n; i++)
        {
            var res = cntFromStart[i] * sumLenFromEnd[i] + cntFromEnd[i] * sumLenFromStart[i];
            Console.WriteLine(res);
        }
    }
}

