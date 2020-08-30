// detail: https://codeforces.com/contest/1396/submission/91362957
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
        if (n == 1)
        {
            Console.WriteLine("1 1");
            Console.WriteLine(-a[0]);
            Console.WriteLine("1 1");
            Console.WriteLine(0);
            Console.WriteLine("1 1");
            Console.WriteLine(0);
            return;
        }
        long[] addNum = new long[n];
        for (int i = 0; i < a.Length; i++)
            addNum[i] = ((a[i] % n + n) % n) * (n - 1);

        Console.WriteLine($"1 {n - 1}");
        Console.WriteLine(string.Join(" ", addNum.Take(n - 1)));

        Console.WriteLine($"2 {n}");
        Console.WriteLine(string.Join(" ", Enumerable.Repeat(0L, n - 2).Concat(addNum.Skip(n - 1))));

        a = a.Zip(addNum, (x, y) => x + y).ToArray();
        if (a.Any(x => x % n != 0)) throw new Exception();
        Console.WriteLine($"1 {n}");
        Console.WriteLine(string.Join(" ", a.Select(x => -x)));
    }
}