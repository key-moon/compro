// detail: https://onlinejudge.u-aizu.ac.jp/status/users/keymoon/submissions/1/3509/judge/4826867/C#
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
        var nq = Console.ReadLine().Split().Select(int.Parse).ToArray();
        var n = nq[0];
        var q = nq[1];
        var sqrtQ = (int)Ceiling(Sqrt(q));
        int[] degree = new int[n];
        Tuple<int, int>[] queries = new Tuple<int, int>[q];
        HashSet<int>[] adjs = Enumerable.Repeat(0, n).Select(_ => new HashSet<int>()).ToArray();

        bool[] isLargeDeg = new bool[n];
        long[] adjDegSum = new long[n];

        for (int i = 0; i < q; i++)
        {
            var uv = Console.ReadLine().Split().Select(int.Parse).ToArray();
            var u = uv[0] - 1;
            var v = uv[1] - 1;
            queries[i] = new Tuple<int, int>(u, v);

            var inserted = adjs[u].Add(v) && adjs[v].Add(u);
            if (!inserted)
            {
                adjs[u].Remove(v);
                adjs[v].Remove(u);
            }

            if (sqrtQ <= adjs[u].Count)
                isLargeDeg[u] = true;
            if (sqrtQ <= adjs[v].Count)
                isLargeDeg[v] = true;
        }

        isLargeDeg = new bool[n];
        int[] largeDegs = Enumerable.Range(0, n).Where(x => isLargeDeg[x]).ToArray();

        for (int i = 0; i < adjs.Length; i++)
            adjs[i].Clear();

        Func<int, long> calc = vertex =>
        {
            long degSum = 0;
            if (isLargeDeg[vertex]) degSum = adjDegSum[vertex];
            else
            {
                foreach (var adj in adjs[vertex])
                    degSum += degree[adj];
            }
            return degSum * degree[vertex];
        };

        Action<int, int> resolveDeg = (vertex, incr) =>
        {
            degree[vertex] += incr;
            foreach (var largeDeg in largeDegs)
            {
                if (adjs[largeDeg].Contains(vertex)) continue;
                adjDegSum[largeDeg] += incr;
            }
        };

        long curRes = 0;
        foreach (var query in queries)
        {
            var u = query.Item1;
            var v = query.Item2;

            curRes -= calc(u);
            curRes -= calc(v);

            var inserted = adjs[u].Add(v) && adjs[v].Add(u);
            if (!inserted)
            {
                adjs[u].Remove(v);
                adjs[v].Remove(u);
            }

            if (!inserted) curRes += degree[u] * degree[v];

            var incr = inserted ? 1 : -1;

            if (isLargeDeg[u]) adjDegSum[u] += incr * degree[v];
            if (isLargeDeg[v]) adjDegSum[v] += incr * degree[u];

            resolveDeg(u, incr);
            resolveDeg(v, incr);

            curRes += calc(u);
            curRes += calc(v);
            if (inserted) curRes -= degree[u] * degree[v];

            Console.WriteLine(curRes);
        }
    }
}



