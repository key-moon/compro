// detail: https://yukicoder.me/submissions/426348
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
        var a = NextInt;
        var b = NextInt;
        var c = NextInt;
        var d = NextInt;
        var e = NextInt;
        var f = NextInt;
        var g = NextInt;
        for (int i1 = 0; i1 <= a; i1++)
        for (int i2 = 0; i2 <= b; i2++)
        for (int i3 = 0; i3 <= c; i3++)
        for (int i4 = 0; i4 <= d; i4++)
        for (int i5 = 0; i5 <= e; i5++)
        for (int i6 = 0; i6 <= f; i6++)
            if (500 * i1 + 100 * i2 + 50 * i3 + 10 * i4 + 5 * i5 + i6 == g)
            {
                Console.WriteLine("YES");
                return;
            }
        Console.WriteLine("NO");
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
