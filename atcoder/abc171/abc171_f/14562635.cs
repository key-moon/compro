// detail: https://atcoder.jp/contests/abc171/submissions/14562635
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
        Factorial[0] = 1;
        for (int i = 1; i < Factorial.Length; i++) Factorial[i] = Factorial[i - 1] * i;
        InvFactorial[InvFactorial.Length - 1] = 1 / Factorial[Factorial.Length - 1];
        for (int i = InvFactorial.Length - 2; i >= 0; i--) InvFactorial[i] = InvFactorial[i + 1] * (i + 1);
        Power25[0] = 1;
        Power26[0] = 1;
        for (int i = 1; i < Power25.Length; i++)
        {
            Power25[i] = Power25[i - 1] * 25;
            Power26[i] = Power26[i - 1] * 26;
        }

        //Console.WriteLine(Solve(1000000, 1000000));

        int n = int.Parse(Console.ReadLine());
        var s = Console.ReadLine().Select(x => x - 'a').ToArray();

        Console.WriteLine(Solve(n, s.Length));
        return;

        int count = 0;
        foreach (var item in Gen(n + s.Length))
        {
            int ind = 0;
            foreach (var c in item)
            {
                if (s.Length <= ind) goto end;
                if (s[ind] == c)
                    ind++;
            }
            if (s.Length <= ind) goto end;
            //Console.WriteLine(string.Join(" ", item));
            continue;
            end:;

            count++;
        }
        Console.WriteLine(count);
    }

    static ModInt Solve(int n, int length)
    {
        var totalLangth = length + n;
        ModInt res = 0;

        for (int endAt = length - 1; endAt < totalLangth; endAt++)
        {
            ModInt curRes = 1;
            var success = length - 1;
            var failed = endAt - success;
            curRes *= (Factorial[success + failed] * InvFactorial[success] * InvFactorial[failed]) * Power25[failed];
            var extra = totalLangth - endAt - 1;
            curRes *= Power26[extra];
            res += curRes;
        }

        return res;
    }


    static ModInt[] Factorial = new ModInt[2000001];
    static ModInt[] InvFactorial = new ModInt[2000001];
    static ModInt[] Power25 = new ModInt[2000001];
    static ModInt[] Power26 = new ModInt[2000001];

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

    static IEnumerable<IEnumerable<int>> Gen(int length)
    {
        if (length == 0) return new[] { new int[0] };
        return Gen(length - 1).SelectMany(x =>
        {
            //var fix = x.ToArray();
            var fix = x;
            return Enumerable.Range(0, 26).Select(y => fix.Append(y));
        });
    }
}

struct ModInt
{
    public const int Mod = 1000000007;
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
