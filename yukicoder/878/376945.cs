// detail: https://yukicoder.me/submissions/376945
using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Numerics;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using static System.Math;
using MethodImplOptions = System.Runtime.CompilerServices.MethodImplOptions;
using MethodImplAttribute = System.Runtime.CompilerServices.MethodImplAttribute;

public static class P
{
    public static void Main()
    {
        var nq = Console.ReadLine().Split().Select(int.Parse).ToArray();
        var n = nq[0];
        var q = nq[1];
        var a = Console.ReadLine().Split().Select(int.Parse).ToArray();
        //Mo
        var chunkSize = (int)Ceiling(Sqrt(n));
        var res = new int[q];
        var queries = Enumerable.Range(0, q).Select(Index => new { Index, Elem = Query.Parse(Console.ReadLine()) }).ToArray();
        foreach (var query in queries.Where(x => chunkSize >= x.Elem.Length))
        {
            int count = 0;
            int curMax = 0;
            for (int i = query.Elem.L; i <= query.Elem.R; i++)
            {
                if (curMax < a[i])
                {
                    curMax = a[i];
                    count++;
                }
            }
            res[query.Index] = count;
        }
        foreach (var chunk in queries.Where(x => chunkSize < x.Elem.Length).GroupBy(x => x.Elem.L / chunkSize))
        {
            List<int> highCand = new List<int>();
            var chunkEnd = Min(n - 1, (chunk.Key + 1) * chunkSize);
            highCand.Add(-1);
            var curInd = chunkEnd;
            foreach (var query in chunk.OrderBy(x => x.Elem.R))
            {
                while (curInd <= query.Elem.R)
                {
                    if (highCand.Last() < a[curInd])
                        highCand.Add(a[curInd]);
                    curInd++;
                }
                int count = 0;
                int curMax = 0;
                for (int i = query.Elem.L; i < chunkEnd; i++)
                {
                    if (curMax < a[i])
                    {
                        curMax = a[i];
                        count++;
                    }
                }
                res[query.Index] = count + highCand.Count - (~highCand.BinarySearch(curMax));
            }
        }
        Console.WriteLine(string.Join("\n", res));
    }
}

struct Query
{
    public int L;
    public int R;
    public int Length => R - L + 1;
    public static Query Parse(string s)
    {
        var qlr = s.Split().Select(int.Parse).ToArray();
        return new Query()
        {
            L = qlr[1] - 1,
            R = qlr[2] - 1,
        };
    }
}
