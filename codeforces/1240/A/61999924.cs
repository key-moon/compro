// detail: https://codeforces.com/contest/1240/submission/61999924
using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using static System.Math;
using MethodImplOptions = System.Runtime.CompilerServices.MethodImplOptions;
using MethodImplAttribute = System.Runtime.CompilerServices.MethodImplAttribute;

public static class P
{
    public static void Main()
    {
        int q = int.Parse(Console.ReadLine());

        for (int i = 0; i < q; i++)
        {
            Console.WriteLine(Solve());
        }
    }
    static int Solve()
    {
        int n = int.Parse(Console.ReadLine());
        var p = Console.ReadLine().Split().Select(x => long.Parse(x) / 100).OrderByDescending(x => x).ToArray();
        var paccum = new long[n + 1];
        for (int i = 0; i < p.Length; i++)
        {
            paccum[i + 1] = paccum[i] + p[i];
        }
        var xa = Console.ReadLine().Split().Select(int.Parse).ToArray();
        var X = xa[0];
        var a = xa[1];
        var yb = Console.ReadLine().Split().Select(int.Parse).ToArray();
        var Y = yb[0];
        var b = yb[1];
        if (X < Y)
        {
            var tmp = X;
            X = Y;
            Y = tmp;
            tmp = a;
            a = b;
            b = tmp;
        }
        //should be X > Y
        var lcm = LCM(a, b);
        var k = long.Parse(Console.ReadLine());
        if (Val(paccum, X, a, Y, b, lcm, n) < k) return -1;

        int invalid = 0;
        int valid = n;
        while (valid - invalid > 1)
        {
            var mid = (valid + invalid) / 2;
            if (k <= Val(paccum, X, a, Y, b, lcm, mid)) valid = mid;
            else invalid = mid;
        }
        return valid;
    }
    static long Val(long[] paccum, int X, int a, int Y, int b, long lcm, int count)
    {
        var both = count / lcm;
        var acount = count / a - both;
        var bcount = count / b - both;
        var res = paccum[both] * (X + Y);
        res += (paccum[acount + both] - paccum[both]) * X;
        res += (paccum[acount + bcount + both] - paccum[both + acount]) * Y;
        return res;
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
}

