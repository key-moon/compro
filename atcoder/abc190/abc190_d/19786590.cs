// detail: https://atcoder.jp/contests/abc190/submissions/19786590
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
        long n = long.Parse(Console.ReadLine());
        var n2 = n * 2;
        bool Valid(long len)
        {
            return (n2 / len - len + 1) % 2 == 0;
        }
        HashSet<long> res = new HashSet<long>();
        for (long len = 1; len * len < (n * 2); len++)
        {
            if (n2 % len != 0) continue;
            if (Valid(len)) res.Add(len);
            if (Valid(n2 / len)) res.Add(n2 / len);
        }

        //Console.WriteLine(string.Join(" ", res));
        Console.WriteLine(res.Count);
    }
}