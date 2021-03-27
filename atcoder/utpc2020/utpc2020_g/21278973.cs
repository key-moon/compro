// detail: https://atcoder.jp/contests/utpc2020/submissions/21278973
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
        var a = Enumerable.Repeat(0, n).Select(_ => Console.ReadLine().Split().Select(int.Parse).ToArray()).ToArray();

        int m = 1 << n;
        Console.WriteLine(m);
        var sum = Enumerable.Repeat(0, n).Select(_ => new int[n]).ToArray();
        for (int b = 0; b < (1 << n); b++)
        {
            var res = a.Select(x => x.ToArray()).ToArray();
            for (int i = 0; i < n; i++)
            {
                if ((b >> i & 1) != 1) continue;
                for (int j = 0; j < n; j++)
                {
                    res[i][j] *= -1;
                    res[j][i] *= -1;
                }
            }
            for (int i = 0; i < n; i++)
                for (int j = 0; j < n; j++)
                    sum[i][j] += res[i][j];
            Console.WriteLine(string.Join("\n", res.Select(x => string.Join(" ", x))));
        }
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n; j++)
            {
                if (i == j && sum[i][j] != a[i][j] * m) throw new Exception(); 
                if (i != j && sum[i][j] != 0) throw new Exception();
            }
        }
    }
}