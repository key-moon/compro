// detail: https://codeforces.com/contest/710/submission/104679360
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
        var input = Console.ReadLine().Split().Select(long.Parse).ToArray();
        var a1 = input[0];
        var b1 = input[1];
        var a2 = input[2];
        var b2 = input[3];
        var L = input[4];
        var R = input[5];
        var gcd = ExtGCD(a1, a2, out long k, out long l);
        if ((b2 - b1) % gcd != 0)
        {
            Console.WriteLine(0);
            return;
        }
        k *= (b2 - b1) / gcd;
        l *= (b2 - b1) / gcd; l *= -1;
        var kStep = a2 / gcd;
        var lStep = a1 / gcd;
        {
            var maxStep = Min(k / kStep, l / lStep);
            k -= maxStep * kStep;
            l -= maxStep * lStep;
        }
        {
            var maxStep = Max(-k / kStep, -l / lStep);
            k += maxStep * kStep;
            l += maxStep * lStep;
        }
        while (k < 0 || l < 0) { k += kStep; l += lStep; }
        var start = a1 * k + b1;
        var step = LCM(a1, a2);
        long GetCount(long X) => X < start ? 0 : (X - start) / step + 1;
        var res = GetCount(R) - GetCount(L - 1);
        Console.WriteLine(res);
    }

    static long LCM(long a, long b) { return a / GCD(a, b) * b; }
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