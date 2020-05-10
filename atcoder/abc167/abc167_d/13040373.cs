// detail: https://atcoder.jp/contests/abc167/submissions/13040373
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
        var nk = Console.ReadLine().Split().Select(long.Parse).ToArray();
        var a = Console.ReadLine().Split().Select(x => int.Parse(x) - 1).ToArray();
        var n = (int)nk[0];
        var k = nk[1];
        int[] count = Enumerable.Repeat(-1, n).ToArray();
        int cur = 0;
        count[cur] = 0;
        while (true)
        {
            if (count[a[cur]] != -1)
            {
                var period = (count[cur] + 1) - count[a[cur]];
                k = (k - count[a[cur]]) % period + count[a[cur]];
                Console.WriteLine(count.TakeWhile(x => x != k).Count() + 1);
                return;
            }
            count[a[cur]] = count[cur] + 1;
            cur = a[cur];
            if (count[cur] == k)
            {
                Console.WriteLine(cur + 1);
                return;
            }
        }
    }
}
