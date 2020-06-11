// detail: https://atcoder.jp/contests/abc079/submissions/14183185
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
        int[] abcd = Console.ReadLine().Select(x => x - '0').ToArray();
        for (int i = 0; i < (1 << 3); i++)
        {
            string s = abcd[0].ToString();
            int res = abcd[0];
            for (int j = 0; j < 3; j++)
            {
                var op = (i >> j & 1);
                s += op == 1 ? '+' : '-';
                s += abcd[j + 1];
                res += (op == 1 ? 1 : -1) * abcd[j + 1];
            }
            if (res == 7)
            {
                Console.WriteLine($"{s}=7");
                return;
            }
        }
        throw new Exception();
    }
}