// detail: https://codeforces.com/contest/1352/submission/79510302
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
        int t = int.Parse(Console.ReadLine());
        for (int i = 0; i < t; i++)
        {
            Solve();
        }
    }
    static void Solve()
    {
        var n = Console.ReadLine().Split().Select(int.Parse).ToArray();
        if (n[0] != 0 && n[2] != 0 && n[1] == 0) throw new Exception();
        if (n[0] != 0 && n[1] == 0)
        {
            Console.WriteLine(string.Join("", Enumerable.Repeat(0, n[0] + 1)));
            return;
        }
        if (n[1] == 0 && n[2] != 0)
        {
            Console.WriteLine(string.Join("", Enumerable.Repeat(1, n[2] + 1)));
            return;
        }
        var a = Enumerable.Repeat(0, n[0] + 1).Concat(Enumerable.Repeat(1, n[2] + 1)).ToList();
        n[1]--;
        for (int i = 0; i < n[1]; i++)
        {
            a.Add(i % 2);
        }

        Console.WriteLine(string.Join("", a));
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
            int res = 0; int sign = 1; while (Buffer[ptr] < 45) Move();
            if (Buffer[ptr] == 45) { Move(); sign = -1; }
            do { res = res * 10 + (Buffer[ptr] ^ 48); Move(); } while (48 <= Buffer[ptr]);
            return res * sign;
        }
    }

    public static long NextLong
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get
        {
            long res = 0; int sign = 1; while (Buffer[ptr] < 45) Move();
            if (Buffer[ptr] == 45) { Move(); sign = -1; }
            do { res = res * 10 + (Buffer[ptr] ^ 48); Move(); } while (48 <= Buffer[ptr]);
            return res * sign;
        }
    }
}