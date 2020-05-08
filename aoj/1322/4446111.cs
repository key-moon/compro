// detail: https://onlinejudge.u-aizu.ac.jp/status/users/keymoon/submissions/1/1322/judge/4446111/C#
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
        while (true) Solve();
    }

    static int h, w;
    static string[] expr;

    public static void Solve()
    {
        h = int.Parse(Console.ReadLine());
        if (h == 0) Environment.Exit(0);
        expr = Enumerable.Repeat(0, h).Select(_ => Console.ReadLine()).ToArray();
        w = expr[0].Length;
        Console.WriteLine(Eval(0, h - 1, 0, w - 1));
    }

    static ModInt Eval(int ymin, int ymax, int xmin, int xmax)
    {
        int baseY = -1;
        while (true)
        {
            for (int i = ymin; i <= ymax; i++)
            {
                if (expr[i][xmin] != '.') baseY = i;
            }
            if (baseY != -1) break;
            xmin++;
        }

        int x = xmin;
        List<ModInt> nums = new List<ModInt>() { EvalSingleTerm(baseY, ymin, ymax, ref x) };
        List<char> ops = new List<char>();
        while (true)
        {
            x += 2;
            if (x > xmax) break;
            var op = expr[baseY][x];
            if (op != '+' && op != '-' && op != '*') break;
            x += 2;
            if (x > xmax) break;
            var num = EvalSingleTerm(baseY, ymin, ymax, ref x);
            if (op == '*') nums[nums.Count - 1] *= num;
            else
            {
                ops.Add(op);
                nums.Add(num);
            }
        }

        var res = nums[0];
        for (int i = 1; i < nums.Count; i++)
        {
            if (ops[i - 1] == '+') res += nums[i];
            else res -= nums[i];
        }

        return res;
    }

    static ModInt EvalSingleTerm(int baseY, int ymin, int ymax, ref int x)
    {
        if (expr[baseY][x] == '-')
        {
            if (expr[baseY][x + 1] != '-')
            {
                x += 2;
                return -EvalSingleTerm(baseY, ymin, ymax, ref x);
            }
            else
            {
                var xmin = x + 1;
                for (; x + 1 < w && expr[baseY][x + 1] == '-'; x++) ;
                return Eval(ymin, baseY - 1, xmin, x - 1) / Eval(baseY + 1, ymax, xmin, x - 1);
            }
        }

        ModInt res;
        if (expr[baseY][x] == '(')
        {
            var depth = 0;
            var xmin = x + 2;
            for (; x < w; x++)
            {
                if (expr[baseY][x] == '(') depth++;
                if (expr[baseY][x] == ')') depth--;
                if (depth == 0) break;
            }
            res = Eval(ymin, ymax, xmin, x - 2);
        }
        else res = expr[baseY][x] - '0';

        if (ymin <= baseY - 1 && x + 1 < w && expr[baseY - 1][x + 1] != '.') res = Power(res, expr[baseY - 1][++x] - '0');
        return res;
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
    public const int Mod = 2011;
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

