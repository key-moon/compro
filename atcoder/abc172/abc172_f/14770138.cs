// detail: https://atcoder.jp/contests/abc172/submissions/14770138
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
#if DEBUG
        Solve(4, 3, 3);
        for (int i = 1; i < 16; i++)
        {
            for (int j = 1; j < 16; j++)
            {
                for (int k = 0; k < 16; k++)
                {
                    var resa = Stupid(i, j, k);
                    var resb = Solve(i, j, k);
                    if (resa != resb)
                    {
                        Console.WriteLine($"{i} {j} {k}");
                    }
                }
            }
        }
#endif
        int n = int.Parse(Console.ReadLine());
        var a = Console.ReadLine().Split().Select(long.Parse).ToArray();
        var p = a[0];
        var q = a[1];
        var r = a.Aggregate(0L, (x, y) => x ^ y) ^ p ^ q;
        Console.WriteLine(Solve(p, q, r));
    }

    static long Stupid(long p, long q, long r)
    {
        for (int i = 0; i < p; i++)
        {
            if (((p - i) ^ (q + i)) == r) return i;
        }
        return -1;
    }

    static long Solve(long p, long q, long r)
    {
        long[][] dp = Enumerable.Range(0, 2).Select(_ => new long[2] { long.MaxValue >> 1, long.MaxValue >> 1 }).ToArray();
        dp[0][0] = 0;
        for (int bit = 0; bit <= 40; bit++)
        {
            var pbit = p >> bit & 1;
            var qbit = q >> bit & 1;
            var rbit = r >> bit & 1;
            var defBit = pbit ^ qbit ^ rbit;

            long[][] newdp = Enumerable.Range(0, 2).Select(_ => new long[2] { long.MaxValue >> 1, long.MaxValue >> 1 }).ToArray();

            for (int i = 0; i <= 1; i++)
            {
                for (int j = 0; j <= 1; j++)
                {
                    var bitChange = i ^ j;
                    if (defBit != bitChange) continue;
                    var ni = i == 1 && pbit == 0 ? 1 : 0;
                    var nj = j == 1 && qbit == 1 ? 1 : 0;
                    //そのまま
                    newdp[ni][nj] = Min(newdp[ni][nj], dp[i][j]);
                    //引く
                    //既に繰り下がりが置きてる時は
                    var nni = i == 0 && pbit == 1 ? 0 : 1;
                    var nnj = j == 0 && qbit == 0 ? 0 : 1;
                    newdp[nni][nnj] = Min(newdp[nni][nnj], dp[i][j] + (1L << bit));
                }
            }
            dp = newdp;
        }
        var res = dp.Min(x => x.Min());
        if (p <= res) res = -1;
        return res;
    }
}