// detail: https://onlinejudge.u-aizu.ac.jp/status/users/keymoon/submissions/1/DSL_1_B/judge/4336214/C#
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using static Reader;
using MethodImplAttribute = System.Runtime.CompilerServices.MethodImplAttribute;
using MethodImplOptions = System.Runtime.CompilerServices.MethodImplOptions;

public static class P
{
    public static void Main()
    {
        Console.SetOut(new StreamWriter(Console.OpenStandardOutput()) { AutoFlush = false });
        var n = NextInt;
        var q = NextInt;
        var uf = new PotentializedUnionFind<int>(n, (x, y) => x + y, x => -x, 0);
        for (int i = 0; i < q; i++)
        {
            if (NextInt == 0)
            {
                uf.TryUnite(NextInt, NextInt, NextInt);
            }
            else
            {
                var a = NextInt;
                var b = NextInt;
                Console.WriteLine(uf.Find(a) == uf.Find(b) ? uf.GetPotential(b, a).ToString() : "?");
            }
        }
        Console.Out.Flush();
    }
}

class PotentializedUnionFind<T> where T : IEquatable<T>
{
    public int Size { get; private set; }
    public int GroupCount { get; private set; }
    public IEnumerable<int> AllRepresents => Parent.Where((x, y) => x == y);
    int[] Sizes;
    int[] Parent;
    T[] Value;
    Func<T, T, T> Operate;
    Func<T, T> Inverse;
    T Identity;

    public PotentializedUnionFind(int count, Func<T, T, T> operate, Func<T, T> inverse, T identity)
    {
        Size = count;
        GroupCount = count;
        Parent = new int[count];
        Sizes = new int[count];
        Value = new T[count];
        for (int i = 0; i < count; i++) { Sizes[Parent[i] = i] = 1; Value[i] = identity; }
        Operate = operate;
        Inverse = inverse;
        Identity = identity;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public bool TryUnite(int x, int y, T distance)
    {
        T xd, yd;
        int xp = Find(x, out xd);
        int yp = Find(y, out yd);

        if (yp == xp) return Operate(distance, yd).Equals(xd);

        GroupCount--;
        if (Sizes[xp] < Sizes[yp])
        {
            Value[xp] = Operate(Operate(Inverse(xd), distance), yd);
            Parent[xp] = yp;
            Sizes[yp] += Sizes[xp];
        }
        else
        {
            Value[yp] = Operate(Operate(Inverse(yd), Inverse(distance)), xd);
            Parent[yp] = xp;
            Sizes[xp] += Sizes[yp];
        }
        return true;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public int GetSize(int x) => Sizes[Find(x)];

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public T GetPotential(int x, int y)
    {
        T xd, yd;
        int xp = Find(x, out xd);
        int yp = Find(y, out yd);
        if (yp == xp) return Operate(Inverse(xd), yd);
        else return Identity;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public int Find(int x)
    {
        while (x != Parent[x]) { Value[x] = Operate(Value[x], Value[Parent[x]]); Parent[x] = Parent[Parent[x]]; x = Parent[x]; }
        return x;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private int Find(int x, out T potential)
    {
        potential = Identity;
        while (x != Parent[x])
        {
            Value[x] = Operate(Value[x], Value[Parent[x]]);
            Parent[x] = Parent[Parent[x]];
            potential = Operate(potential, Value[x]);
            x = Parent[x];
        }
        return x;
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


