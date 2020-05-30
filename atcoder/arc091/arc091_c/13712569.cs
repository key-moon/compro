// detail: https://atcoder.jp/contests/arc091/submissions/13712569
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
        var nab = Console.ReadLine().Split().Select(int.Parse).ToArray();
        var n = nab[0];
        var a = nab[1];
        var b = nab[2];
        int[] chunks = Enumerable.Repeat(1, b).ToArray();
        var remain = n - b;
        if (remain < 0)
        {
            Console.WriteLine(-1);
            return;
        }
        for (int i = 0; i < chunks.Length; i++)
        {
            var adder = Min(a - chunks[i], remain);
            chunks[i] += adder;
            remain -= adder;
        }
        if (remain != 0 || chunks.Max() != a)
        {
            Console.WriteLine(-1);
            return;
        }
        int curMax = n;
        List<int> res = new List<int>();
        foreach (var chunk in chunks)
        {
            var start = curMax - chunk + 1;
            res.AddRange(Enumerable.Range(start, chunk));
            curMax = start - 1;
        }

        Console.WriteLine(string.Join(" ", res));
    }
}
