// detail: https://atcoder.jp/contests/abl/submissions/17033697
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
        var (a, b, c, d) = (NextLong, NextLong, NextLong, NextLong);
        bool Valid(long n) => a <= n && n <= b && c <= n && n <= d;
        if (Valid(a) || Valid(b) || Valid(c) || Valid(d)) Console.WriteLine("Yes");
        else Console.WriteLine("No");
    }
}


static class Reader
{
    const int BUF_SIZE = 1 << 12;
    static Stream Stream = Console.OpenStandardInput();
    static byte[] Buffer = new byte[BUF_SIZE];
    static int ptr = BUF_SIZE - 1;
    static void Move() { if (++ptr >= Buffer.Length) { Stream.Read(Buffer, 0, BUF_SIZE); ptr = 0; } }


    public static long NextLong
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get
        {
            long res = 0; while (Buffer[ptr] < 48) Move();
            do { res = res * 10 + (long)(Buffer[ptr] ^ 48); Move(); } while (48 <= Buffer[ptr]);
            return res;
        }
    }
}
