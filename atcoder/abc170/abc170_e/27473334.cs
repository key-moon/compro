// detail: https://atcoder.jp/contests/abc170/submissions/27473334
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
        SortedSet<long>[] boxes = Enumerable.Repeat(0, 200001).Select(_ => new SortedSet<long>()).ToArray();
        long[] rate = new long[n];
        int[] aff = new int[n];
        for (int i = 0; i < n; i++)
        {
            var ab = Console.ReadLine().Split().Select(long.Parse).ToArray();
            var a = ab[0];
            var b = (int)ab[1];
            rate[i] = (a * 1000000) + i;
            aff[i] = b;
            boxes[aff[i]].Add(rate[i]);
        }
        SortedSet<long> maxes = new SortedSet<long>();
        void TryAdd(int ind)
        {
            if (boxes[ind].Count != 0) Trace.Assert(maxes.Add(boxes[ind].Max));
        }
        void TryRemove(int ind)
        {
            if (boxes[ind].Count != 0) Trace.Assert(maxes.Remove(boxes[ind].Max));
        }

        for (int i = 0; i < boxes.Length; i++) TryAdd(i);
        
        for (int i = 0; i < q; i++)
        {
            var cd = Console.ReadLine().Split().Select(int.Parse).ToArray();
            var c = cd[0] - 1;
            var d = cd[1];
            TryRemove(aff[c]);
            boxes[aff[c]].Remove(rate[c]);
            TryAdd(aff[c]);

            aff[c] = d;
            TryRemove(aff[c]);
            boxes[aff[c]].Add(rate[c]);
            TryAdd(aff[c]);
            Console.WriteLine(maxes.Min / 1000000);
        }
    }
}