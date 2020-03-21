// detail: https://atcoder.jp/contests/agc043/submissions/11053632
//#define A
#undef DEBUG
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
using MethodImplAttribute = System.Runtime.CompilerServices.MethodImplAttribute;
using MethodImplOptions = System.Runtime.CompilerServices.MethodImplOptions;

public static class P
{
    public static void Main()
    {
#if A
        for (int i = 11; i < 30; i++)
        {
            for (int _ = 0; _ < 10000; _++)
            {
                Random rng = new Random();
                var _a = Enumerable.Repeat(0, i).Select(_ => rng.Next() % 3 + 1).ToArray();
                var res2 = SolveStupid(_a);
                if (res2 == 2) continue;
                var res1 = Solve(_a);
                if (res1 != res2)
                {
                    Console.WriteLine(i);
                    Console.WriteLine(string.Join("", _a));
                }
            }
        }
#endif
        var n = int.Parse(Console.ReadLine());
        var a = Console.ReadLine().Select(x => x - '0').ToArray();
#if DEBUG
        SolveStupid(a);
#endif
        if (n < 10)
        {
            Console.WriteLine(SolveStupid(a));
            return;
        }
        Console.WriteLine(Solve(a));
    }

    public static int SolveStupid(int[] a)
    {
        int p = 0;
        while (a.Length > 1)
        {
            a = Simulate(a);
#if DEBUG
            p++;
            Console.Write(string.Join("", Enumerable.Repeat(" ", p)));
            Console.WriteLine(string.Join(" ", a));
#endif
        }
        return a[0];
    }

    public static int Solve(int[] a)
    {
        for (int i = 0; i < 5; i++)
        {
            a = Simulate(a);
        }
        var oneFlag = a.Contains(1);
        if (!oneFlag)
        {
            a = a.Select(x => x == 0 ? 0 : 1).ToArray();
        }
        int cur2Count = 0;
        var res = a[0];
        for (int i = 1, j = a.Length - 1; i <= a.Length - 1; i++, j--)
        {
            cur2Count += Count(j);
            cur2Count -= Count(i);
            if (cur2Count == 0) res += a[i];
        }
        return (res % 2) * (oneFlag ? 1 : 2);
    }

    public static int Count(int n)
    {
        int count2 = 0;
        while ((n & 1) == 0)
        {
            count2++;
            n >>= 1;
        }
        return count2;
    }

    static int[] Simulate(int[] a)
    {
        return a.Zip(a.Skip(1), (x, y) => Abs(x - y)).ToArray();
    }
}
