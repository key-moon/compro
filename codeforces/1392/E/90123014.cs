// detail: https://codeforces.com/contest/1392/submission/90123014
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
        int n = int.Parse(Console.ReadLine());
        var map = Enumerable.Repeat(0, n).Select(_ => new long[n]).ToArray();
        {
            long init = 1;
            for (int i = 1; i < n; i += 2)
            {
                map[i][0] = init;
                for (int j = 1; j < n; j++)
                {
                    map[i][j] = map[i][j - 1] * 2;
                }
                init *= 4;
            }
        }
        Console.WriteLine(string.Join("\n", map.Select(x => string.Join(" ", x))));
        int q = int.Parse(Console.ReadLine());

        for (int i = 0; i < q; i++)
        {
            long val = long.Parse(Console.ReadLine());
            int cury = 0;
            int curx = 0;
            Console.WriteLine($"{cury + 1} {curx + 1}");
            for (int j = 0; j < (n - 1) * 2; j++)
            {
                var isValueZero = (val & 1) == 0;
                if (cury + 1 < n)
                {
                    var isZero = map[cury + 1][curx] == 0;
                    if (isValueZero == isZero)
                    {
                        cury++;
                        goto end;
                    }
                }
                if (curx + 1 < n)
                {
                    var isZero = map[cury][curx + 1] == 0;
                    if (isValueZero == isZero)
                    {
                        curx++;
                        goto end;
                    }
                }
                throw new Exception();
                end:;
                Console.WriteLine($"{cury + 1} {curx + 1}");
                val >>= 1;
            }
        }
    }
}
