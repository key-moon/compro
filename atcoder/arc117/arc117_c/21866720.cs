// detail: https://atcoder.jp/contests/arc117/submissions/21866720
using System;
using System.Linq;

public static class P
{
    public static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        var s = Console.ReadLine();
        ModInt res = 0;

        ModInt curComb = 1;
        int threeCnt = 0;
        for (int i = 0; i < s.Length; i++)
        {
            var number = s[i] switch { 'R' => 0, 'W' => 1, 'B' => 2 };
            if (threeCnt == 0) res += number * curComb;
            if (i == s.Length - 1) continue;

            var num = s.Length - i - 1;
            var den = i + 1;

            while (num != 0 && num % 3 == 0) { threeCnt++; num /= 3; }
            while (den != 0 && den % 3 == 0) { threeCnt--; den /= 3; }

            if (num != 0) curComb *= num;
            if (den != 0) curComb /= den;

        }


        if (n % 2 == 0) res = -res;
        Console.WriteLine((int)res switch { 0 => 'R', 1 => 'W', 2 => 'B' });
    }
}


struct ModInt
{
    public const int Mod = 3;
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
