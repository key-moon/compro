// detail: https://atcoder.jp/contests/arc020/submissions/16408656
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
        int n = int.Parse(Console.ReadLine());
        var data = Enumerable.Repeat(0, n).Select(_ => Console.ReadLine().Split().Select(int.Parse).ToArray()).Select(x => (x[0], x[1])).ToArray();
        int b = int.Parse(Console.ReadLine());
        ModInt.SetMod(b);
        long digits = 0;
        var pow10 = new ModInt[11];
        pow10[0] = 1;
        for (int i = 1; i < pow10.Length; i++)
            pow10[i] = pow10[i - 1] * 10;
        ModInt res = 0;
        foreach (var (a, L) in data.Reverse())
        {
            var aDigit = a.ToString().Length;
            var offset = Power(10, digits);
            Matrix2x2 mat = new Matrix2x2()
            {
                aa = pow10[aDigit], ab = 1,
                ba = 0, bb = 1
            };
            var powed = Matrix2x2.Power(mat, L);
            res += a * powed.ab * offset;
            digits += (long)aDigit * L;
        }
        Console.WriteLine(res);
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

struct Matrix2x2
{
    public ModInt aa, ab;
    public ModInt ba, bb;
    public static Matrix2x2 operator *(Matrix2x2 l, Matrix2x2 r) =>
        new Matrix2x2()
        {
            aa = l.aa * r.aa + l.ab * r.ba, ab = l.aa * r.ab + l.ab * r.bb,
            ba = l.ba * r.aa + l.bb * r.ba, bb = l.ba * r.ab + l.bb * r.bb,
        };

    public static Matrix2x2 Power(Matrix2x2 n, long m)
    {
        Matrix2x2 pow = n;
        Matrix2x2 res = new Matrix2x2()
        {
            aa = 1, ab = 0,
            ba = 0, bb = 1
        };
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
    public static int Mod { get; private set; }
    public static long POSITIVIZER;
    public static void SetMod(int mod) => POSITIVIZER = ((long)(Mod = mod)) << 31;
    static ModInt() => SetMod(1000000007);
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
    public static bool operator ==(ModInt a, ModInt b) => a.Data == b.Data;
    public static bool operator !=(ModInt a, ModInt b) => a.Data != b.Data;
    public override string ToString() => Data.ToString();
    public override bool Equals(object obj) => (ModInt)obj == this;
    public override int GetHashCode() => (int)Data;
}
