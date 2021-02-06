// detail: https://atcoder.jp/contests/abc191/submissions/19962724
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
        var hw = Console.ReadLine().Split().Select(int.Parse).ToArray();
        var h = hw[0];
        var w = hw[1];
        var up = string.Join("", Enumerable.Repeat('.', w + 2));
        var s = Enumerable.Repeat(0, h).Select(_ => $".{Console.ReadLine()}.").Prepend(up).Append(up).ToArray();
        int res = 0;
        for (int i = 0; i <= h; i++)
        {
            for (int j = 0; j <= w; j++)
            {
                var cnt = new[] { s[i][j], s[i][j + 1], s[i + 1][j], s[i + 1][j + 1] }.Count(x => x == '.');
                if (cnt == 1 || cnt == 3) res++;
            }
        }
        Console.WriteLine(res);
        
    }
}