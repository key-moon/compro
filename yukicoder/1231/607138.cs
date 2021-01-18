// detail: https://yukicoder.me/submissions/607138
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
        var a = Console.ReadLine().Split().Select(long.Parse).ToArray();
        int[][] steps = Enumerable.Repeat(0, 10).Select(_ => Enumerable.Repeat(int.MaxValue / 2, 10).ToArray()).ToArray();
        foreach (var group in a.GroupBy(x => x % 10))
        {
            var key = group.Key;
            var count = group.Count();
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j <= Min(10, count); j++)
                {
                    var nxt = (i + j * key) % 10;
                    steps[i][nxt] = Min(steps[i][nxt], j);
                }
            }
        }
        for (int i = 0; i < 10; i++)
            for (int j = 0; j < 10; j++)
                for (int k = 0; k < 10; k++)
                    steps[j][k] = Min(steps[j][k], steps[j][i] + steps[i][k]);
        Console.WriteLine(n - steps[0][a.Sum() % 10]);
    }
}