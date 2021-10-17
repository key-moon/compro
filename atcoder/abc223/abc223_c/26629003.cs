// detail: https://atcoder.jp/contests/abc223/submissions/26629003
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
        int n = int.Parse(Console.ReadLine());
        var cables = Enumerable.Repeat(0, n).Select(_ => Console.ReadLine().Split().Select(int.Parse).ToArray()).Select(x => (x[0], x[1])).ToArray();
        var revCables = cables.Reverse().ToArray();
        double GetLen((int, int)[] cables, double time)
        {
            double res = 0;
            foreach (var (a, b) in cables)
            {
                var length = Min(a, time * b);
                res += length;
                time -= length / b;
                if (time < 1e-9) break;
            }
            return res;
        }
        var totalLen = cables.Sum(x => x.Item1);
        double valid = 0, invalid = long.MaxValue;
        for (int cnt = 0; cnt < 1000; cnt++)
        {
            var mid = (valid + invalid) / 2;
            if (GetLen(cables, mid) + GetLen(revCables, mid) < totalLen) valid = mid;
            else invalid = mid;
        }
        Console.WriteLine(GetLen(cables, valid));
    }
}