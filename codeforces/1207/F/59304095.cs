// detail: https://codeforces.com/contest/1207/submission/59304095
using System;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Debug = System.Diagnostics.Debug;
using static System.Math;

static class P
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());

        var queries = Enumerable.Repeat(0, n).Select(_ =>
        {
            var s = Console.ReadLine().Split();
            return new Query(int.Parse(s[0]), int.Parse(s[1]), int.Parse(s[2]));
        }).ToArray();

        long[] value = new long[500000 + 1];
        long[] queryValueOf = new long[1 << 20];

        StringBuilder builder = new StringBuilder();

        int sqrt = (int)Sqrt(500000);
        for (int i = 0; i < n; i++)
        {
            if (queries[i].Type == 1)
            {
                var target = queries[i].x;
                var delta = queries[i].y;
                for (int j = 1; j < sqrt; j++)
                    queryValueOf[(j << 10) + (target % j)] += delta;
                value[target] += delta;
            }
            else
            {
                var rem = queries[i].x;
                var mod = queries[i].y;
                if (rem < sqrt)
                {
                    builder.AppendLine(queryValueOf[(rem << 10) + mod].ToString());
                }
                else
                {
                    long res = 0;
                    for (int ind = mod; ind < value.Length; ind += rem)
                        res += value[ind];
                    builder.AppendLine(res.ToString());
                }
            }
        }

        Console.Write(builder.ToString());
    }
}

struct Query
{
    public int Type;
    public int x;
    public int y;
    public Query(int type, int x, int y)
    {
        Type = type;
        this.x = x;
        this.y = y;
    }
}
