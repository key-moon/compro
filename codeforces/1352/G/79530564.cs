// detail: https://codeforces.com/contest/1352/submission/79530564
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
        int n = int.Parse(Console.ReadLine());
        if (n <= 3)
        {
            Console.WriteLine(-1);
            return;
        }
        if (n == 7)
        {
            Console.WriteLine("5 1 3 6 2 4 7");
            return;
        }
        bool special = false;
        if (n % 4 == 3)
        {
            special = true;
            n -= 6;
        }
        int begin = -1;
        var seq = Enumerable.Repeat(new[] { +3, +2, -3, +2 }, n / 4).Aggregate(Enumerable.Empty<int>(), (x, y) => x.Concat(y));
        if (n % 4 >= 1) seq = seq.Concat(new[] { +2 });
        bool flag = false;
        if (n % 4 == 2) flag = true;
        if (special) seq = seq.Concat(new[] { +3, +2, -4, +3, +2, -4 });
        List<int> res = new List<int>();
        foreach (var item in seq) res.Add(begin += item);
        if (flag) res = new[] { 1 }.Concat(res.Select(x => x + 1)).ToList();
        if (special) n += 6;
        //if (res.Min() != 1 || res.Max() != n || res.Distinct().Count() != n) throw new Exception();
        Console.WriteLine(string.Join(" ", res));
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