// detail: https://yukicoder.me/submissions/487692
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
        var mod1 = 998244353;
        ModInt.Mod = mod1;
        var nq = Console.ReadLine().Split().Select(int.Parse).ToArray();
        var n = nq[0];
        var q = nq[1];
        var a = Console.ReadLine().Split().Select(x => new ModInt(int.Parse(x))).ToArray();
        var b = new ModInt[n];
        foreach (var item in Console.ReadLine().Split().Select(int.Parse).ToArray())
        {
            b[item == 0 ? 0 : n - item] += 1;
        }
        ModInt.Mod = mod1;
        var res1 = NumberTheoreticTransform.Convolute(a, b);
        var mod2 = 469762049;
        ModInt.Mod = mod2;
        var res2 = NumberTheoreticTransform.Convolute(a, b);

        var inv = 1 / new ModInt(mod1);
        var fftres = res1.Zip(res2, (x, y) => (long)(((int)y - (int)x) * inv) * mod1 + (int)x).ToArray();
        long[] res = new long[n];
        for (int i = 0; i < n; i++)
        {
            long item = 0;
            if (i < fftres.Length) item += fftres[i];
            if (n + i < fftres.Length) item += fftres[n + i];
            res[i] = item;
        }

        Console.WriteLine(string.Join(" ", res));
    }


    static long ExtGCD(long a, long b, out long x, out long y)
    {
        long div;
        long x1 = 1, y1 = 0, x2 = 0, y2 = 1;
        while (true)
        {
            if (b == 0) { x = x1; y = y1; return a; }
            div = a / b; x1 -= x2 * div; y1 -= y2 * div; a %= b;
            if (a == 0) { x = x2; y = y2; return b; }
            div = b / a; x2 -= x1 * div; y2 -= y1 * div; b %= a;
        }
    }
}

class NumberTheoreticTransform
{
    const int primitive_root = 3;
    static NumberTheoreticTransform() { }
    public static ModInt[] Convolute(ModInt[] A, ModInt[] B)
    {
        int sz = A.Length + B.Length - 1;
        int N = 1; while (N < sz) N <<= 1;

        var G = new ModInt[N];
        Array.Copy(A, G, A.Length);
        var H = new ModInt[N];
        Array.Copy(B, H, B.Length);

        NTT(G); NTT(H);
        for (int i = 0; i < N; i++) G[i] *= H[i];
        NTT(G, -1);

        Array.Resize(ref G, sz);
        return G;
    }
    static void NTT(ModInt[] F, int rev = 1)
    {
        int N = F.Length;

        ModInt h = ModInt.Pow(primitive_root, (ModInt.Mod - 1) / N);
        if (rev == -1) h = 1 / h;
        for (int i = 0, j = 1; j < N - 1; j++)
        {
            for (int k = N >> 1; k > (i ^= k); k >>= 1) ;
            if (j < i)
            {
                var tmp = F[i];
                F[i] = F[j];
                F[j] = tmp;
            }
        }

        for (int i = 2; i <= N; i <<= 1)
        {
            int m = i >> 1;
            // zeta = exp(rev * PI / m * i)
            ModInt zeta = ModInt.Pow(h, N / i);

            for (int j = 0; j < N; j += i)
            {
                ModInt zeta_pow = 1;
                for (int u = j, v = j + m; v < j + i; u++, v++)
                {
                    ModInt vl = F[u], vr = zeta_pow * F[v];
                    F[u] = vl + vr;
                    F[v] = vl - vr;
                    zeta_pow = zeta_pow * zeta;
                }
            }
        }

        if (rev == -1)
        {
            ModInt n_inv = (ModInt)1 / N;
            for (int i = 0; i < F.Length; i++)
            {
                F[i] *= n_inv;
            }
        }
    }
}


struct ModInt
{
    public static int mod;
    public static int Mod
    {
        get { return mod; }
        set { POSITIVIZER = ((long)value) << 31; mod = value; }
    }

    static long POSITIVIZER;
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


    public static ModInt Pow(ModInt n, long m)
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
