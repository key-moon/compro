// detail: https://atcoder.jp/contests/panasonic2020/submissions/10887204
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
using MethodImplAttribute = System.Runtime.CompilerServices.MethodImplAttribute;
using MethodImplOptions = System.Runtime.CompilerServices.MethodImplOptions;

public static class P
{
    public static void Main()
    {
        var q = int.Parse(Console.ReadLine());
        for (int i = 0; i < q; i++)
        {
            var abcd = Console.ReadLine().Split().Select(long.Parse).ToArray();
            var y1 = abcd[0] - 1;
            var x1 = abcd[1] - 1;
            var y2 = abcd[2] - 1;
            var x2 = abcd[3] - 1;
            var y = Abs(y1 - y2);
            var x = Abs(x1 - x2);
            if (y < x)
            {
                var tmp1 = x1;
                x1 = y1;
                y1 = tmp1;
                var tmp2 = x2;
                x2 = y2;
                y2 = tmp2;
                var tmp = y;
                y = x;
                x = tmp;
            }
            long maxSize = 0;
            for (long size = 1; ; size *= 3)
            {
                if (size > y) break;
                //y軸の間に黒列を含む
                if (Abs(y1 / size - y2 / size) <= 1) continue;
                //同じ列に居て、黒列である 違う列にいる場合は黒マスを完全に迂回可能
                if (x1 / size != x2 / size || (x1 / size) % 3 != 1) continue;
                maxSize = size;
            }
            if (maxSize == 0)
            {
                Console.WriteLine(y + x);
                continue;
            }
            var edgeA = (x1 / maxSize) * maxSize;
            var edgeB = (x1 / maxSize + 1) * maxSize - 1;
            Console.WriteLine(y + Min(Abs(x1 - edgeA) + Abs(x2 - edgeA), Abs(x1 - edgeB) + Abs(x2 - edgeB)) + 2);
        }
    }
}
