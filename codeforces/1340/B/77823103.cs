// detail: https://codeforces.com/contest/1340/submission/77823103
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
using MethodImplAttribute = System.Runtime.CompilerServices.MethodImplAttribute;
using MethodImplOptions = System.Runtime.CompilerServices.MethodImplOptions;

public static class P   
{
    public static void Main()
    {
        var digs = new int[]
        {
            //               1234567
            Convert.ToInt32("1110111", 2),//0
            Convert.ToInt32("0010010", 2),//1
            Convert.ToInt32("1011101", 2),//2
            Convert.ToInt32("1011011", 2),//3
            Convert.ToInt32("0111010", 2),//4
            Convert.ToInt32("1101011", 2),//5
            Convert.ToInt32("1101111", 2),//6
            Convert.ToInt32("1010010", 2),//7
            Convert.ToInt32("1111111", 2),//8
            Convert.ToInt32("1111011", 2),//9
        };
        int[] popCounts = digs.Select(PopCount).ToArray();
        var nk = Console.ReadLine().Split().Select(int.Parse).ToArray();
        var n = nk[0];
        var count = nk[1];
        var display = Enumerable.Repeat(0, n).Select(_ => Convert.ToInt32(Console.ReadLine(), 2)).Reverse().ToArray();
        //その文字の前に使った奴
        int[] curPlaces = Enumerable.Repeat(-1, n).ToArray();
        curPlaces[0] = 0;

        //i本使ったときにできてるその桁までの最大が欲しい
        //下の桁から求めていけば、最後は貪欲にできる
        //dp[i][j] = (下から!)i桁目までj本使って埋めてる
        int[][] dp = Enumerable.Range(0, n).Select(_ => Enumerable.Repeat(-1, count + 1).ToArray()).ToArray();

        for (int i = 0; i < digs.Length; i++)
        {
            var digBin = digs[i];
            if ((display[0] & digBin) != display[0]) continue;
            var popCnt = PopCount(digBin - display[0]);
            if (dp[0].Length <= popCnt) continue;
            dp[0][popCnt] = i;
        }

        for (int i = 1; i < dp.Length; i++)
        {
            for (int dig = 0; dig < digs.Length; dig++)
            {
                var digBin = digs[dig];
                if ((display[i] & digBin) != display[i]) continue;
                var popCnt = PopCount(digBin - display[i]);
                for (int j = 0; j < dp[i].Length; j++)
                {
                    if (popCnt > j || dp[i - 1][j - popCnt] == -1) continue;
                    dp[i][j] = dig;
                }
            }
        }

        if (dp[n - 1][count] == -1) { Console.WriteLine(-1); return; }

        var res = new List<int>();
        for (int i = dp.Length - 1; i >= 0; i--)
        {
            res.Add(dp[i][count]);
            var popCnt = PopCount(digs[dp[i][count]] - display[i]);
            count -= popCnt;
        }

        Console.WriteLine(string.Join("", res));
        /*
        BigInteger[] max = Enumerable.Repeat(-BigInteger.One, count + 1).ToArray();
        max[0] = 0;
        for (int i = 0; i < n; i++)
        {
            //var curDig = 0;
            var allowedDigs = 
                Enumerable.Range(0, 10)
                .Where(x => (digs[x] & curDig) == curDig)
                .Select(dig => new { dig, count = PopCount(digs[dig] - curDig) }).ToArray();

            for (int j = max.Length - 1; j >= 0; j--)
            {
                var digMax = max[j];
                for (int k = 0; k < allowedDigs.Length; k++)
                {
                    if (j < allowedDigs[k].count) continue;
                    digMax = BigInteger.Max(digMax, max[j - allowedDigs[k].count] * 10 + allowedDigs[k].dig);
                }
                max[j] = digMax;
            }
        }
        Console.WriteLine(max.Last());*/
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    static int PopCount(int n)
    {
        int msb = 0;
        if (n < 0) { n &= int.MaxValue; msb = 1; }
        n = n - ((n >> 1) & 0x55555555);
        n = (n & 0x33333333) + ((n >> 2) & 0x33333333);
        return (int)(((n + (n >> 4) & 0xF0F0F0F) * 0x1010101) >> 24) + msb;
    }
}
