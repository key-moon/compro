// detail: https://atcoder.jp/contests/abc161/submissions/11953824
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
        int k = int.Parse(Console.ReadLine());
        var curDig = new List<long>(Enumerable.Range(1, 9).Select(x => (long)x));
        var res = new List<long>(curDig);
        while (res.Count < k)
        {
            var next = new List<long>();
            foreach (var item in curDig)
            {
                var lastDig = item % 10;
                if (lastDig != 0) next.Add(item * 10 + lastDig - 1);
                next.Add(item * 10 + lastDig);
                if (lastDig != 9) next.Add(item * 10 + lastDig + 1);
            }
            res.AddRange(next);
            curDig = next;
        }
        Console.WriteLine(res[k - 1]);
    }
}