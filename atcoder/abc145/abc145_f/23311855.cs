// detail: https://atcoder.jp/contests/abc145/submissions/23311855
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
        var sorted = a.Append(0).Append((int)1e9).Distinct().OrderBy(x => x).ToArray();
        var compDic = sorted.Select((elem, ind) => (elem, ind)).ToDictionary(x => x.elem, x => x.ind);

        var compressed = a.Select(x => compDic[x]).ToArray();

        // dp[i][j] := i回変更して、dic[j]だけ露出している時の最小操作回数
        long[][] dp = Enumerable.Repeat(0, k + 1).Select(_ => Enumerable.Repeat(long.MaxValue / 2, compDic.Count).ToArray()).ToArray();
        dp[0][compDic[0]] = 0;
        foreach (var item in a)
        {
            var compressedItem = compDic[item];
            long[][] newdp = Enumerable.Repeat(0, k + 1).Select(_ => Enumerable.Repeat(long.MaxValue / 2, compDic.Count).ToArray()).ToArray();
            for (int i = 0; i <= k; i++)
            {
                for (int j = 0; j < compDic.Count; j++)
                {
                    // 高さを一つ前に合わせる
                    if (i < k) newdp[i + 1][j] = Min(newdp[i + 1][j], dp[i][j]);
                    newdp[i][compressedItem] = Min(newdp[i][compressedItem], dp[i][j] + Max(0, item - sorted[j]));
                }
            }
            dp = newdp;
        }
        Console.WriteLine(dp.Min(x => x.Min()));
    }
}