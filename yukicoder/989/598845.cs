// detail: https://yukicoder.me/submissions/598845
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
        var nmk = Console.ReadLine().Split().Select(int.Parse).ToArray();
        var n = nmk[0];
        var m = nmk[1];
        var k = nmk[2];
        var b = Console.ReadLine().Split();
        var op = b[0];
        var row = b.Skip(1).Select(long.Parse).OrderByDescending(x => x).ToArray();
        var col = Enumerable.Repeat(0, n).Select(_ => long.Parse(Console.ReadLine())).ToArray();
        var opF = op == "*" ? (Func<long, long, long>)((x, y) => x * y) : (x, y) => x + y;
        long res = 0;
        for (int i = 0; i < n; i++)
        {
            int valid = -1;
            int invalid = row.Length;
            while (invalid - valid > 1)
            {
                var mid = (valid + invalid) / 2;
                if (k <= opF(row[mid], col[i])) valid = mid;
                else invalid = mid;
            }
            res += invalid;
        }
        Console.WriteLine(res);
    }
}
