// detail: https://onlinejudge.u-aizu.ac.jp/status/users/keymoon/submissions/1/DSL_2_E/judge/4060391/C#
using System;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Debug = System.Diagnostics.Debug;
using static System.Math;
using static Reader;
using System.Runtime.CompilerServices;
using MethodImplOptions = System.Runtime.CompilerServices.MethodImplOptions;
using MethodImplAttribute = System.Runtime.CompilerServices.MethodImplAttribute;

static class P
{
    static void Main()
    {
        BIT<int> bit = new BIT<int>(NextInt + 1, 0, (x, y) => x + y);
        int q = NextInt;
        StringBuilder builder = new StringBuilder();
        for (int i = 0; i < q; i++)
        {
            if (NextInt == 0)
            {
                var l = NextInt;
                var r = NextInt;
                var x = NextInt;
                bit.Operate(l, x);
                bit.Operate(r + 1, -x);
            }
            else
            {
                builder.AppendLine(bit.Query(NextInt).ToString());
            }
        }
        Console.Write(builder.ToString());
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
            do { res = res * 10 + (Buffer[ptr] ^ 48); Move(); } while (48 <= Buffer[ptr]);
            return res;
        }
    }
}

class BIT<T>
{
    public readonly int Size;
    T Identity;
    T[] Elements;
    Func<T, T, T> Merge;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public BIT(int size, T identity, Func<T, T, T> merge)
    {
        Size = size;
        Identity = identity;
        Merge = merge;
        Elements = new T[Size + 1];
        for (int i = 0; i < Elements.Length; i++)
            Elements[i] = identity;
    }
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public T Query(int r)
    {
        T res = Identity;
        for (; r > 0; r -= r & -r)
            res = Merge(res, Elements[r]);
        return res;
    }
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Operate(int i, T x)
    {
        for (; i < Elements.Length; i += i & -i)
            Elements[i] = Merge(Elements[i], x);
    }
}



