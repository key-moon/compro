// detail: https://yukicoder.me/submissions/426351
using System;
using System.IO;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using System.Diagnostics;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using static System.Math;
using MethodImplOptions = System.Runtime.CompilerServices.MethodImplOptions;
using MethodImplAttribute = System.Runtime.CompilerServices.MethodImplAttribute;
using static Reader;

static class P
{
    static void Main()
    {
        long p = NextInt;
        long q = NextInt;
        long r = NextInt;
        long a = NextInt;
        long b = NextInt;
        long c = NextInt;
        long min = long.MinValue;
        long max = long.MaxValue;
        min = Max(min, p * a - p + 1);
        max = Min(max, p * a);
        min = Max(min, q * (a + b) - q + 1);
        max = Min(max, q * (a + b));
        min = Max(min, r * (a + b + c) - r + 1);
        max = Min(max, r * (a + b + c));
        if (min > max)
        {
            Console.WriteLine(-1);
            return;
        }
        Console.WriteLine($"{min} {max}");
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
