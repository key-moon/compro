// detail: https://codeforces.com/contest/1208/submission/59461945
using System;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Debug = System.Diagnostics.Debug;
using static System.Math;
using MethodImplOptions = System.Runtime.CompilerServices.MethodImplOptions;
using MethodImplAttribute = System.Runtime.CompilerServices.MethodImplAttribute;

static class P
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        var res = Enumerable.Repeat(0, n).Select(_ => new int[n]).ToArray();

        var item = 0;
        for (int i = 0; i < n; i += 2)
        {
            for (int j = 0; j < n; j += 2)
            {
                res[i][j] = item++;
                res[i][j + 1] = item++;
                res[i + 1][j] = item++;
                res[i + 1][j + 1] = item++;
            }
        }
        //if (res.Aggregate(Enumerable.Repeat(0, n), (x, y) => x.Zip(y, (a, b) => a ^ b)).Any(x => x != 0) || res.Any(x => x.Aggregate(0, (a, b) => a ^ b) != 0)) throw new Exception();
        Console.WriteLine(string.Join("\n", res.Select(x => string.Join(" ", x))));
    }
}
