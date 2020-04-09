// detail: https://codeforces.com/contest/877/submission/75986823
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using static Reader;
using MethodImplAttribute = System.Runtime.CompilerServices.MethodImplAttribute;
using MethodImplOptions = System.Runtime.CompilerServices.MethodImplOptions;
using System.Text.RegularExpressions;

public static class P
{
    public static void Main()
    {
        var s = Console.ReadLine();   
        Console.WriteLine(Regex.Matches(s, "(Danil|Olya|Slava|Ann|Nikita)").Count == 1 ? "Yes" : "No");
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
            do { res = res * 10 + (Buffer[ptr] ^ 48); Move(); } while (48 <= Buffer[ptr]);
            return res;
        }
    }
}