// detail: https://codeforces.com/contest/1352/submission/79500809
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
        var a = Console.ReadLine().Split().Select(int.Parse).ToArray();
        int aInd = 0;
        int bInd = n - 1;
        int min = 0;
        int num = 0;
        int totalSum = a.Sum();
        int aSum = 0;
        int bSum = 0;
        while (true)
        {
            if (totalSum - aSum - bSum <= min)
            {
                if (totalSum - aSum - bSum == 0) goto end;
                num++;
                aSum += totalSum - aSum - bSum;
                goto end;
            }
            var curSum = 0;
            while (curSum <= min) curSum += a[aInd++];
            min = curSum;
            aSum += curSum;
            num++;


            //Console.WriteLine(string.Join(" ", a.Take(bInd + 1).Skip(aInd)));
            if (totalSum - aSum - bSum <= min)
            {
                if (totalSum - aSum - bSum == 0) goto end;
                num++;
                bSum += totalSum - aSum - bSum;
                goto end;
            }
            curSum = 0;
            while (curSum <= min) curSum += a[bInd--];
            min = curSum;
            bSum += curSum;
            num++;

            //Console.WriteLine(string.Join(" ", a.Take(bInd + 1).Skip(aInd)));
        }
        end:;
        Console.WriteLine($"{num} {aSum} {bSum}");
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
