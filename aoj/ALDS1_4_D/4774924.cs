// detail: https://onlinejudge.u-aizu.ac.jp/status/users/keymoon/submissions/1/ALDS1_4_D/judge/4774924/C#
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
        var nk = Console.ReadLine().Split().Select(int.Parse).ToArray();
        var n = nk[0];
        var k = nk[1];
        var w = Enumerable.Repeat(0, n).Select(_ => int.Parse(Console.ReadLine())).ToArray();
        long valid = int.MaxValue;
        long invalid = 0;
        while (valid - invalid > 1)
        {
            var mid = (valid + invalid) / 2;

            int ptr = 0;
            for (int i = 0; i < k; i++)
            {
                long total = mid;
                while (ptr < w.Length && 0 <= total - w[ptr]) total -= w[ptr++];
            }
            if (ptr == w.Length) valid = mid;
            else invalid = mid;
        }
        Console.WriteLine(valid);
    }
}

