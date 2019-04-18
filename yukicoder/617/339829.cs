// detail: https://yukicoder.me/submissions/339829
using System;
using System.IO;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Numerics;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using static System.Math;
using Debug = System.Diagnostics.Debug;
using MethodImplOptions = System.Runtime.CompilerServices.MethodImplOptions;
using MethodImplAttribute = System.Runtime.CompilerServices.MethodImplAttribute;


static class P
{
    static void Main()
    {
        const uint DeBruijnSequence = 0b0000111011010111110011000101001U;
        int[] DeBruijnBitPosition = { 0, 1, 23, 2, 29, 24, 19, 3, 30, 27, 25, 11, 20, 8, 4, 13, 31, 22, 28, 18, 26, 10, 7, 12, 21, 17, 9, 6, 16, 5, 15, 14 };

        var nk = Console.ReadLine().Split().Select(int.Parse).ToArray();
        var n = nk[0];
        var k = nk[1];
        var a = Enumerable.Repeat(0, nk[0]).Select(_ => int.Parse(Console.ReadLine())).ToArray();

        int sum = 0;
        int res = 0;
        for (int i = 1; i < (1 << n); i++)
        {
            int code = i ^ (i >> 1);

            uint lsb = (uint)(i & -i);
            int bitpos = DeBruijnBitPosition[(DeBruijnSequence * lsb) >> 27];

            if (((1 << bitpos) & code) != 0) sum += a[bitpos];
            else sum -= a[bitpos];

            if (sum <= k && res < sum) res = sum;
        }
        Console.WriteLine(res);
    }
}
