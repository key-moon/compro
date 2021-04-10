// detail: https://atcoder.jp/contests/agc053/submissions/21607218
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
        var s = Console.ReadLine();
        var a = Console.ReadLine().Split().Select(int.Parse).ToArray();

        //while (true) Test();

        var k = a.Zip(a.Skip(1), (x, y) => Abs(x - y)).Min();
        Console.WriteLine(k);
        for (int i = 0; i < k; i++)
        {
            List<int> res = new List<int>();
            for (int j = 0; j <= n; j++)
            {
                res.Add(a[j] / k + (i < a[j] % k ? 1 : 0));
            }
            Console.WriteLine(string.Join(" ", res));
        }
    }
    static void Test()
    {
        int n = 10;
        var r = new Random();
        a:;
        var a = Enumerable.Range(0, n + 1).Select(x => r.Next(1, 100)).ToArray();
        var signs = a.Zip(a.Skip(1), (x, y) => Sign(x - y)).ToArray();
        if (signs.Any(x => x == 0)) goto a;

        var k = a.Zip(a.Skip(1), (x, y) => Abs(x - y)).Min();
        for (int i = 0; i < k; i++)
        {
            List<int> res = new List<int>();
            for (int j = 0; j <= n; j++)
            {
                res.Add(a[j] / k + (i < a[j] % k ? 1 : 0));
            }
            if (res.Any(x => x < 0)) throw new Exception();
            var mysigns = res.Zip(res.Skip(1), (x, y) => Sign(x - y)).ToArray();
            if (mysigns.Zip(signs, (x, y) => x == y).Any(x => !x)) throw new Exception();
        }
    }
}