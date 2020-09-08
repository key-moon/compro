// detail: https://atcoder.jp/contests/exawizards2019/submissions/16570706
using System;
using System.IO;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Numerics;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using static System.Math;
using Debug = System.Diagnostics.Debug;
using LayoutKind = System.Runtime.InteropServices.LayoutKind;
using MethodImplOptions = System.Runtime.CompilerServices.MethodImplOptions;
using MethodImplAttribute = System.Runtime.CompilerServices.MethodImplAttribute;
using System.Runtime.Intrinsics.X86;

static class P
{
    static void Main()
    {
        var nx = Console.ReadLine().Split().Select(int.Parse).ToArray();
        long X = nx[1];
        //ちゅーごくじょーよてーり
        //オーダーによってSの終端が決定する
        //まず影響するのは降順のみなことは自明に分かって、
        //で、「次」を選ぶことができる順番は
        //「確率」「期待値」
        //aを取り除いた場合、その後に適用できるのはそれ以前全て。

        List<int> s = Console.ReadLine().Split().Select(int.Parse).OrderByDescending(x => x).ToList();
        ModInt[] dp = new ModInt[X + 1];
        dp[X] = 1;
        long remain = s.Count - 1;
        foreach (var mod in s)
        {
            ModInt[] newDP = new ModInt[X + 1];

            for (int i = 0; i < dp.Length; i++)
            {
                newDP[i % mod] += dp[i];
                newDP[i] += dp[i] * remain;
            }
            remain--;
            dp = newDP;
        }
        ModInt res = 0;
        for (int i = 0; i < dp.Length; i++)
        {
            res += dp[i] * i;
        }
        Console.WriteLine(res);
    }
}


struct ModInt
{
    public const int Mod = 1000000007;
    private static Barrett Barrett = new Barrett(Mod);
    const long POSITIVIZER = ((long)Mod) << 31;
    long Data;
    public ModInt(long data) { if ((Data = data % Mod) < 0) Data += Mod; }
    public static implicit operator long(ModInt modInt) => modInt.Data;
    public static implicit operator ModInt(long val) => new ModInt(val);
    public static ModInt operator +(ModInt a, int b) => new ModInt() { Data = (a.Data + b + POSITIVIZER) % Mod };
    public static ModInt operator +(ModInt a, long b) => new ModInt(a.Data + b);
    public static ModInt operator +(ModInt a, ModInt b) { long res = a.Data + b.Data; return new ModInt() { Data = res >= Mod ? res - Mod : res }; }
    public static ModInt operator -(ModInt a, int b) => new ModInt() { Data = (a.Data - b + POSITIVIZER) % Mod };
    public static ModInt operator -(ModInt a, long b) => new ModInt(a.Data - b);
    public static ModInt operator -(ModInt a, ModInt b) { long res = a.Data - b.Data; return new ModInt() { Data = res < 0 ? res + Mod : res }; }
    public static ModInt operator *(ModInt a, int b) => new ModInt(a.Data * b);
    public static ModInt operator *(ModInt a, long b) => a * new ModInt(b);
    public static ModInt operator *(ModInt a, ModInt b) => new ModInt() { Data = Barrett.Mul((uint)a.Data, (uint)b.Data) };
    public static ModInt operator /(ModInt a, ModInt b) => new ModInt() { Data = Barrett.Mul((uint)a.Data, (uint)GetInverse(b)) };
    public static bool operator ==(ModInt a, ModInt b) => a.Data == b.Data;
    public static bool operator !=(ModInt a, ModInt b) => a.Data != b.Data;
    public override string ToString() => Data.ToString();
    public override bool Equals(object obj) => (ModInt)obj == this;
    public override int GetHashCode() => (int)Data;
    static long GetInverse(long a)
    {
        long div, p = Mod, x1 = 1, y1 = 0, x2 = 0, y2 = 1;
        while (true)
        {
            if (p == 1) return x2 + Mod; div = a / p; x1 -= x2 * div; y1 -= y2 * div; a %= p;
            if (a == 1) return x1 + Mod; div = p / a; x2 -= x1 * div; y2 -= y1 * div; p %= a;
        }
    }
}

public class Barrett
{
    public uint Mod { get; private set; }
    private ulong IM;
    public Barrett(uint m)
    {
        Mod = m;
        IM = unchecked((ulong)-1) / m + 1;
    }

    public uint Mul(uint a, uint b)
    {
        ulong z = a;
        z *= b;
        if (!Bmi2.X64.IsSupported) return (uint)(z % Mod);
        var x = Bmi2.X64.MultiplyNoFlags(z, IM);
        var v = unchecked((uint)(z - x * Mod));
        if (Mod <= v) v += Mod;
        return v;
    }
}
