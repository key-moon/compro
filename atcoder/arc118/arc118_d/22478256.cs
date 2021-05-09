// detail: https://atcoder.jp/contests/arc118/submissions/22478256
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using static System.Math;

public static class P
{
    public static void Main()
    {
#if FALSE
        var ps = Primes((int)1e5).ToArray();
        foreach (var _p in ps)
        {
            Random rng = new Random(1337);
            for (int i = 0; i < 100000; i++)
            {
                var _a = rng.Next() % (_p - 1) + 1;
                var _b = rng.Next() % (_p - 1) + 1;
                Solve(_a, _b, _p);
            }
            Console.WriteLine(_p);
        }
#endif

        var pab = Console.ReadLine().Split().Select(int.Parse).ToArray();
        var p = pab[0];
        var a = pab[1];
        var b = pab[2];
        var res = Solve(a, b, p);
        if (res is null) Console.WriteLine("No");
        else
        {
            Console.WriteLine("Yes");
            Console.WriteLine(string.Join(" ", res));
        }
    }
    static ModInt[] Solve(int a, int b, int p)
    {
        ModInt.Mod = p;
        if (p == 2) return new ModInt[] { 1, 1 };
        int e = FindE(p);
        int loga = -1;
        int logb = -1;
        {
            ModInt m = 1;
            for (int i = 0; i < p; i++)
            {
                if (m == a) loga = i;
                if (m == b) logb = i;
                m *= e;
            }
        }
        var phi = p - 1;
        var astep = GCD(phi, loga);
        var bstep = GCD(phi, logb);

        // ステップが互いに素でないなら作れない それはそう
        // 互いに疎なら、片方の周期が2の倍数になる(phi%2==0より)
        // よって、そのほう
        if (GCD(astep, bstep) != 1) return null;

        var aperiod = phi / astep;
        var bperiod = phi / bstep;

        if (aperiod % 2 == 0)
        {
            (a, b, astep, bstep, aperiod, bperiod) = (b, a, bstep, astep, bperiod, aperiod);
        }
        if (bperiod % 2 != 0) throw new Exception();
        ModInt[] res = new ModInt[p];
        res[0] = 1;
        int ind = 1;
        int iter = 0;
        if (aperiod == phi)
        {
            for (int i = 0; i < aperiod; i++)
            {
                res[ind] = res[ind - 1] * a;
                ind++;
            }
        }
        else
        {
            var aRound = phi / bperiod - 1;
            while (ind < p)
            {
                for (int i = 0; i < aRound; i++)
                {
                    if (iter % 2 == 0) res[ind] = res[ind - 1] * a;
                    if (iter % 2 == 1) res[ind] = res[ind - 1] / a;
                    ind++;
                }
                res[ind] = res[ind - 1] * b;
                ind++;
                iter++;
            }
        }
        if (res.Take(p - 1).Select(x => (int)x).Distinct().Count() != p - 1) throw new Exception();
        if (res[0] != 1 || res[^1] != 1) throw new Exception();
        return res;
    }

    static int FindE(int p)
    {
        int e;
        for (e = 2; e < p; e++)
        {
            long m = e;
            for (int i = 1; i < p - 1; i++)
            {
                if (m == 1) goto end;
                m *= e;
                m %= p;
            }
            break;
            end:;
        }
        return e;
    }

    static long GCD(long a, long b)
    {
        while (true)
        {
            if (b == 0) return a;
            a %= b;
            if (a == 0) return b;
            b %= a;
        }
    }


    public static IEnumerable<int> Primes(int n)
    {
        if (n < 2) yield break;
        yield return 2;
        ulong[] bitArray = new ulong[(n + 1) / 2 / 64 + 1];

        int[] smallPrimes = { 3, 5, 7, 11, 13, 17, 19, 23, 29, 31, 37, 41, 43, 47, 53, 59, 61 };
        foreach (var prime in smallPrimes)
        {
            if (n < prime) yield break;
            yield return prime;

            ulong[] mask = new ulong[prime];
            for (int j = (prime - 3) >> 1; j < (prime << 6); j += prime)
                mask[j >> 6] |= 1UL << j;

            int maskInd = 0;
            for (int i = 0; i < bitArray.Length; i++)
            {
                bitArray[i] |= mask[maskInd];
                if (++maskInd >= prime) maskInd = 0;
            }
        }

        int[] deBruijnIndex = { 0, 1, 59, 2, 60, 40, 54, 3, 61, 32, 49, 41, 55, 19, 35, 4, 62, 52, 30, 33, 50, 12, 14, 42, 56, 16, 27, 20, 36, 23, 44, 5, 63, 58, 39, 53, 31, 48, 18, 34, 51, 29, 11, 13, 15, 26, 22, 43, 57, 38, 47, 17, 28, 10, 25, 21, 37, 46, 9, 24, 45, 8, 7, 6 };
        int maxInd = n / 2;
        for (int i = 0; i < bitArray.Length; i++)
        {
            for (ulong bit = ~bitArray[i]; bit != 0; bit &= bit - 1)
            {
                int index = i << 6 | deBruijnIndex[((bit & (~bit + 1)) * 0x03F566ED27179461UL) >> 58];
                int prime = (index << 1) + 3;
                if (n < prime) yield break;
                yield return prime;
                for (int ind = index; ind <= maxInd; ind += prime)
                    bitArray[ind >> 6] |= 1UL << ind;
            }
        }
    }
}


struct ModInt
{
    public static int Mod;
    public static long POSITIVIZER => ((long)Mod) << 31;
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
    public static ModInt operator *(ModInt a, ModInt b) => new ModInt() { Data = a.Data * b.Data % Mod };
    public static ModInt operator /(ModInt a, ModInt b) => new ModInt() { Data = a.Data * GetInverse(b) % Mod };
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


[StructLayout(LayoutKind.Explicit)]
class Random
{
    [FieldOffset(0)]
    private byte __byte;
    [FieldOffset(0)]
    private sbyte __sbyte;
    [FieldOffset(0)]
    private char __char;
    [FieldOffset(0)]
    private short __short;
    [FieldOffset(0)]
    private ushort __ushort;
    [FieldOffset(0)]
    private int __int;
    [FieldOffset(0)]
    private uint __uint;
    [FieldOffset(0)]
    private long __long;
    [FieldOffset(0)]
    private ulong __ulong;

    public byte Byte { get { Update(); return __byte; } }
    public sbyte SByte { get { Update(); return __sbyte; } }
    public char Char { get { Update(); return __char; } }
    public short Short { get { Update(); return __short; } }
    public ushort UShort { get { Update(); return __ushort; } }
    public int Int { get { Update(); return __int; } }
    public uint UInt { get { Update(); return __uint; } }
    public long Long { get { Update(); return __long; } }
    public ulong ULong { get { Update(); return __ulong; } }
    public double Double { get { return (double)ULong / ulong.MaxValue; } }

    [FieldOffset(0)]
    private ulong _xorshift;

    public Random() : this((ulong)DateTime.Now.Ticks) { }
    public Random(ulong seed) { SetSeed(seed); }
    public void SetSeed(ulong seed) => _xorshift = seed * 0x3141592c0ffeeul;

    public int Next() => Int & 2147483647;
    public void Update()
    {
        _xorshift ^= _xorshift << 7;
        _xorshift ^= _xorshift >> 9;
    }
}
