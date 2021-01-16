// detail: https://atcoder.jp/contests/keyence2021/submissions/19461239
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
        var nk = Console.ReadLine().Split().Select(int.Parse).ToArray();
        var n = nk[0];
        var k = nk[1];
        var a = Console.ReadLine().Split().Select(int.Parse).ToArray();
        long res = 0;
        long nxt = 0;
        int curCnt = k;
        foreach (var group in a.GroupBy(x => x).OrderBy(x => x.Key))
        {
            var key = group.Key;
            var cnt = group.Count();
            if (nxt != key) break;
            var nxtCnt = Min(curCnt, cnt);
            res += (curCnt - nxtCnt) * nxt;
            nxt++;
            curCnt = nxtCnt;
        }
        res += nxt * curCnt;
        Console.WriteLine(res);
    }
}
