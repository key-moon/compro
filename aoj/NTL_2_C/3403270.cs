// detail: https://onlinejudge.u-aizu.ac.jp/status/users/keymoon/submissions/1/NTL_2_C/judge/3403270/C#
using System;
using System.Linq;
using System.Numerics;
using System.Collections.Generic;
using static System.Math;
using System.Collections;

class P
{
    static void Main()
    {
        var ab = Console.ReadLine().Split().Select(BigInteger.Parse).ToList();
        Console.WriteLine(ab[0] * ab[1]);
    }
}
