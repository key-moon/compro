// detail: https://atcoder.jp/contests/abc079/submissions/11449923
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
        var magic = Enumerable.Repeat(0, 10).Select(_ => Console.ReadLine().Split().Select(int.Parse).ToArray()).ToArray();
        var map = Enumerable.Repeat(0, hw[0]).Select(_ => Console.ReadLine().Split().Select(int.Parse).ToArray()).ToArray();
        for (int i = 0; i < 10; i++)
            for (int j = 0; j < 10; j++)
                for (int k = 0; k < 10; k++)
                    magic[j][k] = Min(magic[j][k], magic[j][i] + magic[i][k]);
        var res = map.Sum(x => x.Sum(y => y == -1 ? 0 : magic[y][1]));
        Console.WriteLine(res);
    }
}