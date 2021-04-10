// detail: https://onlinejudge.u-aizu.ac.jp/status/users/keymoon/submissions/1/2018/judge/5350479/C#
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
        while (true)
        {
            var nmp = Console.ReadLine().Split().Select(int.Parse).ToArray();
            var n = nmp[0];
            var m = nmp[1];
            var p = nmp[2];
            if (n == 0) return;
            var x = Enumerable.Repeat(0, n).Select(_ => int.Parse(Console.ReadLine())).ToArray();
            var total = x.Sum() * 100 * (100 - p) / 100;
            Console.WriteLine(x[m - 1] == 0 ? 0 : total / x[m - 1]);
        }
    }
}
