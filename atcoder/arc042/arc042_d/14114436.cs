// detail: https://atcoder.jp/contests/arc042/submissions/14114436
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
using static System.Math;
public static class P
{
    public static void Main()
    {
        var xpab = Console.ReadLine().Split().Select(int.Parse).ToArray();
        var x = xpab[0];
        var p = xpab[1];
        var a = xpab[2];
        var b = xpab[3];
        ModInt.Mod = p;
        var redundantOffset = (a / p) * p;
        a -= redundantOffset;
        b -= redundantOffset;
        Console.WriteLine(b - a < (1 << 25) ? SmallGap(x, p, a, b) : BigGap(x, p, a, b));
    }

    public static int BigGap(int x, int p, int a, int b)
    {
        //1,2,3…を追加していく 
        for (int i = 1; ; i++)
        {
            var log = Log(i, x);
            if ((a <= log && log <= b) ||
                (a <= log + p && log + p <= b)) return i;
        }
    }

    static int Log(ModInt a, ModInt b)
    {
        const int PACKET_SIZE = 65536;
        ModInt current = 1;
        Dictionary<ModInt, int> babySteps = new Dictionary<ModInt, int>();
        for (int i = 0; i < PACKET_SIZE; i++)
        {
            if (babySteps.ContainsKey(current))
            {
                if (babySteps.ContainsKey(a)) return babySteps[a];
                else return -1;
            }
            babySteps.Add(current, i);
            current *= b;
        }
        ModInt singleGiantStep = current;
        current = 1;
        for (int i = 0; i < ModInt.Mod; i += PACKET_SIZE)
        {
            var babyStep = a / current;
            if (babySteps.ContainsKey(babyStep)) return i + babySteps[babyStep];
            current *= singleGiantStep;
        }
        return -1;
    }

    public static int SmallGap(int x, int p, int a, int b)
    {
        var num = Power(x, a);
        int min = (int)num;
        for (int i = a + 1; i <= b; i++)
        {
            num *= x;
            if (num < min) min = (int)num;
        }
        return min;
    }

    static ModInt Power(ModInt n, long m)
    {
        ModInt pow = n;
        ModInt res = 1;
        while (m > 0)
        {
            if ((m & 1) == 1) res *= pow;
            pow *= pow;
            m >>= 1;
        }
        return res;
    }
}


struct ModInt
{
    static int mod;
    static long POSITIVIZER;
    public static int Mod
    {
        get { return mod; }
        set { mod = value; POSITIVIZER = ((long)mod) << 31; }
    }
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
