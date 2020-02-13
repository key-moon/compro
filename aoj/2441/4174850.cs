// detail: https://onlinejudge.u-aizu.ac.jp/status/users/keymoon/submissions/1/2441/judge/4174850/C#
//#undef DEBUG
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
using MethodImplAttribute = System.Runtime.CompilerServices.MethodImplAttribute;
using MethodImplOptions = System.Runtime.CompilerServices.MethodImplOptions;

public static class P
{
    public static void Main()
    {
        ulong n = ulong.Parse(Console.ReadLine()) - 1;
        ulong valid = 0;
        ulong invalid = (ulong)1e18;
        while (invalid - valid > 1)
        {
            var mid = (valid + invalid) / 2;
            if (GetLengthUntil(mid) <= n) valid = mid;
            else invalid = mid;
        }
        var curInd = GetLengthUntil(valid);
        string s = "";
        for (ulong i = valid + 1; i < valid + 20; i++)
        {
            if (i % 3 == 0) s += "Fizz";
            if (i % 5 == 0) s += "Buzz";
            if (i % 3 != 0 && i % 5 != 0) s += i;
        }
        Console.WriteLine(s.Substring((int)(n - curInd), 20));
    }
    static ulong GetLengthUntil(ulong n)
    {
        ulong res = 0;
        for (ulong Base = 1, digit = 1; Base <= n; Base *= 10, digit++)
        {
            var lowerBound = Base - 1;
            var upperBound = Min(Base * 10 - 1, n);
            var fizzBuzzCount = upperBound / 15 - lowerBound / 15;
            var fizzCount = upperBound / 3 - lowerBound / 3 - fizzBuzzCount;
            var buzzCount = upperBound / 5 - lowerBound / 5 - fizzBuzzCount;
            var numCount = upperBound - lowerBound - (fizzBuzzCount + fizzCount + buzzCount);
            res += numCount * digit + fizzCount * 4 + buzzCount * 4 + fizzBuzzCount * 8;
        }
        return res;
    }
}

