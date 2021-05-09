// detail: https://atcoder.jp/contests/arc118/submissions/22477106
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
        var knm = Console.ReadLine().Split().Select(long.Parse).ToArray();
        var k = knm[0];
        var n = knm[1];
        var m = knm[2];
        var a = Console.ReadLine().Split().Select(long.Parse).Select(x => x * m).ToArray();
        long nm = n * m;

        long[] Build(long diff)
        {
            long curSum = 0;
            long[] b = new long[k];
            for (int i = 0; i < b.Length; i++)
            {
                // b[i] / m < a[i] / n を超えない b を作る
                // b[i] * n < a[i] * m
                b[i] = (a[i] / n) * n;
                if (diff < a[i] - b[i]) b[i] += n;
                if (diff < b[i] - a[i]) return null;
                curSum += b[i];
            }
            
            for (int i = 0; i < b.Length && 0 < nm - curSum; i++)
            {
                var available = a[i] + diff - b[i];
                var use = Min(nm - curSum, available / n * n);
                b[i] += use;
                curSum += use;
            }
            if (nm != curSum) return null;
            return b;
        }
        long valid = nm + 1;
        long invalid = -1;
        while (valid - invalid > 1)
        {
            var mid = (valid + invalid) / 2;
            if (Build(mid) is null) invalid = mid;
            else valid = mid;
        }
        var res = Build(valid);

        Console.WriteLine(string.Join(" ", res.Select(x => x / n)));
    }
}