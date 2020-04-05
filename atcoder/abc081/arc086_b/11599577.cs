// detail: https://atcoder.jp/contests/abc081/submissions/11599577
using System;
using System.Linq;

public static class P
{
    public static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        var a = Console.ReadLine().Split().Select(int.Parse).ToArray();
        var min = a.Min();
        var max = a.Max();
        Console.WriteLine(2 * n);
        if (min + max < 0)
        {
            var minInd = Array.IndexOf(a, min) + 1;
            Console.WriteLine($"{minInd} {minInd}");
            for (int i = 1; i <= n; i++) Console.WriteLine($"{minInd} {i}");
            for (int i = n; i >= 2; i--) Console.WriteLine($"{i} {i - 1}");
        }
        else
        {
            var maxInd = Array.IndexOf(a, max) + 1;
            Console.WriteLine($"{maxInd} {maxInd}");
            for (int i = 1; i <= n; i++) Console.WriteLine($"{maxInd} {i}");
            for (int i = 1; i <= n - 1; i++) Console.WriteLine($"{i} {i + 1}");
        }
    }
}
