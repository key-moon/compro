// detail: https://atcoder.jp/contests/aising2020/submissions/15164650
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
        //int n = 200000;
        //string s = string.Join("", Enumerable.Repeat('1', n));

        int n = int.Parse(Console.ReadLine());
        var s = Console.ReadLine();
        var popcnt = s.Count(x => x == '1');

        int remainwp1 = 0;
        int remainwm1 = 0;

        var remainswp1 = new int[n + 1];
        remainswp1[0] = 1;
        var remainswm1 = new int[n + 1];
        remainswm1[0] = popcnt <= 1 ? 0 : 1;
        for (int i = 1; i <= n; i++)
        {
            var dig =  s[n - i] - '0';
            remainswp1[i] = (remainswp1[i - 1] * 2) % (popcnt + 1);
            remainwp1 = (remainwp1 + (dig * remainswp1[i - 1])) % (popcnt + 1);
            if (popcnt > 1)
            {
                remainswm1[i] = (remainswm1[i - 1] * 2) % (popcnt - 1);
                remainwm1 = (remainwm1 + (dig * remainswm1[i - 1])) % (popcnt - 1);
            }
        }

        int[] table = new int[200000 + 5];

        for (int i = 1; i < table.Length; i++)
        {
            table[i] = table[i % PopCount(i)] + 1;
        }


        Console.SetOut(new StreamWriter(Console.OpenStandardOutput()) { AutoFlush = false });

        for (int i = 0; i < n; i++)
        {
            if (s[i] == '1')
            {
                if (popcnt <= 1)
                {
                    Console.WriteLine(0);
                    continue;
                }
                var remain = remainwm1 + (popcnt - 1) - remainswm1[n - i - 1];
                if (remain >= (popcnt - 1)) remain -= popcnt - 1;
                Console.WriteLine(table[remain] + 1);
            }
            else
            {
                var remain = remainwp1 + remainswp1[n - i - 1];
                if (remain >= (popcnt + 1)) remain -= popcnt + 1;
                Console.WriteLine(table[remain] + 1);
            }
        }
        Console.Out.Flush();
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    static int PopCount(int n)
    {
        n = n - ((n >> 1) & 0x55555555);
        n = (n & 0x33333333) + ((n >> 2) & 0x33333333);
        return (((n + (n >> 4) & 0xF0F0F0F) * 0x1010101) >> 24);
    }
}
