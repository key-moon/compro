// detail: https://atcoder.jp/contests/abc159/submissions/11108181
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
        var hwk = Console.ReadLine().Split().Select(int.Parse).ToArray();
        var h = hwk[0];
        var w = hwk[1];
        var k = hwk[2];
        var s = Enumerable.Repeat(0, h).Select(_ => Console.ReadLine().Select(x => x == '1').ToArray()).ToArray();
        var leastOp = int.MaxValue;
        for (int id = 0; id < (1 << (h - 1)); id++)
        {
            var curOp = PopCount(id);
            var iSectionCount = curOp + 1;
            int[] sectionH = new int[h];
            for (int j = 0; j < h - 1; j++) sectionH[j + 1] = sectionH[j] + (id >> j & 1);
            int[] curChocos = new int[iSectionCount];
            for (int j = 0; j < w; j++)
            {
                for (int i = 0; i < h; i++)
                {
                    if (s[i][j]) curChocos[sectionH[i]]++;
                }
                if (curChocos.Any(x => x > k))
                {
                    curOp++;
                    for (int i = 0; i < curChocos.Length; i++) curChocos[i] = 0;
                    for (int i = 0; i < h; i++) if (s[i][j]) curChocos[sectionH[i]]++;
                    if (curChocos.Any(x => x > k)) goto end;
                }
            }
            leastOp = Min(leastOp, curOp);
            end:;
        }
        Console.WriteLine(leastOp);
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
