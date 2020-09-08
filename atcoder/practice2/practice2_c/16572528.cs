// detail: https://atcoder.jp/contests/practice2/submissions/16572528
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
using static Reader;
using static System.Math;
using MethodImplAttribute = System.Runtime.CompilerServices.MethodImplAttribute;
using MethodImplOptions = System.Runtime.CompilerServices.MethodImplOptions;
public static class P
{
    public static void Main()
    {
        int t = NextInt;
        for (int i = 0; i < t; i++)
            Console.WriteLine(FloorSum(NextInt, NextInt, NextInt, NextInt));
    }

    public static long FloorSum(long n, long m, long a, long b)
    {
        long ans = 0;
        while (true)
        {
            if (a >= m)
            {
                ans += (n - 1) * n * (a / m) / 2;
                a %= m;
            }
            if (b >= m)
            {
                ans += n * (b / m);
                b %= m;
            }

            long yMax = (a * n + b) / m;
            long xMax = yMax * m - b;
            if (yMax == 0) return ans;
            ans += (n - (xMax + a - 1) / a) * yMax;
            (n, m, a, b) = (yMax, a, m, (a - xMax % a) % a);
        }
    }
}


static class Reader
{
    const int BUF_SIZE = 1 << 12;
    static Stream Stream = Console.OpenStandardInput();
    static byte[] Buffer = new byte[BUF_SIZE];
    static int ptr = BUF_SIZE - 1;
    static void Move() { if (++ptr >= Buffer.Length) { Stream.Read(Buffer, 0, BUF_SIZE); ptr = 0; } }


    public static int NextInt
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get
        {
            int res = 0; while (Buffer[ptr] < 48) Move();
            do { res = res * 10 + (int)(Buffer[ptr] ^ 48); Move(); } while (48 <= Buffer[ptr]);
            return res;
        }
    }
}
