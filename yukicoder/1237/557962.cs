// detail: https://yukicoder.me/submissions/557962
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
        int n = (int)NextLong;
        var a = new long[n];
        for (int i = 0; i < a.Length; i++)
            a[i] = NextLong;
        if (a.Contains(0))
        {
            Console.WriteLine(-1);
            return;
        }

        long res = 1;
        foreach (var item in a)
        {
            long factorial = 1;
            for (int i = 1; i <= item; i++)
            {
                factorial *= i;
                if (32 <= factorial) goto over;
            }
            
            for (int i = 0; i < factorial; i++)
            {
                res *= item;
                if (1000000007 < res) goto over;
            }
        }

        Console.WriteLine(1000000007 % res);
        return;

        over:;
        Console.WriteLine(1000000007);
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
