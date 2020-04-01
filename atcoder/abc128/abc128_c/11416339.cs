// detail: https://atcoder.jp/contests/abc128/submissions/11416339
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
using MethodImplAttribute = System.Runtime.CompilerServices.MethodImplAttribute;
using MethodImplOptions = System.Runtime.CompilerServices.MethodImplOptions;


public static class P
{
    static void Main()
    {
        var nm = Console.ReadLine().Split().Select(int.Parse).ToArray();
        var n = nm[0];
        var m = nm[1];
        int[] switches = Enumerable.Repeat(0, m).Select(_ =>
             Console.ReadLine().Split().Select(int.Parse).Skip(1).Aggregate(0, (x, y) => x | (1 << (y - 1)))
        ).ToArray();
        int[] mod = Console.ReadLine().Split().Select(int.Parse).ToArray();
        var res = 0;
        for (int i = 0; i < (1 << n); i++)
        {
            for (int j = 0; j < switches.Length; j++)
            {
                if ((PopCount(switches[j] & i) & 1) != mod[j]) goto end;
            }
            res++;
            end:;
        }
        Console.WriteLine(res);
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
