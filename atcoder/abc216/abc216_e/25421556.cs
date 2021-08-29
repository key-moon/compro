// detail: https://atcoder.jp/contests/abc216/submissions/25421556
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
        long k = nk[1];
        var a = Console.ReadLine().Split().Select(long.Parse).ToArray();
        // より大きい要素を使った時に回数を超えないか
        long valid = int.MaxValue;
        long invalid = -1;
        while (valid - invalid > 1)
        {
            var mid = (valid + invalid) / 2;

            var sum = a.Sum(x => Max(0, x - mid));
            if (sum <= k) valid = mid;
            else invalid = mid;
        }
        long res = 0;
        {
            foreach (var item in a)
            {
                var cnt = Max(item - valid, 0);
                res += cnt * valid;
                res += cnt * (cnt + 1) / 2;
            }
            var remain = k - a.Sum(x => Max(0, x - valid));
            res += remain * valid;
        }
        Console.WriteLine(res);
    }
}