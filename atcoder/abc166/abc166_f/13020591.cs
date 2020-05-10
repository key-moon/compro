// detail: https://atcoder.jp/contests/abc166/submissions/13020591
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Immutable;
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
        var nabc = Console.ReadLine().Split().Select(int.Parse).ToArray();
        var (n, a, b, c) = (nabc[0], nabc[1], nabc[2], nabc[3]);
        ImmutableStack<char>[] dp = new ImmutableStack<char>[5 * 5 * 5];
        static int Encode(int a, int b, int c) => (Min(a, 4) * 5 + Min(b, 4)) * 5 + Min(c, 4);
        dp[Encode(a, b, c)] = ImmutableStack<char>.Empty;
        for (int _ = 0; _ < n; _++)
        {
            var s = Console.ReadLine();
            ImmutableStack<char>[] newdp = new ImmutableStack<char>[5 * 5 * 5];
            int da = 0, db = 0, dc = 0;
            switch (s)
            {
                case "AB":
                    da = 1; db = -1;
                    break;
                case "BC":
                    db = 1; dc = -1;
                    break;
                case "AC":
                    da = 1; dc = -1;
                    break;
            }
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    for (int k = 0; k < 5; k++)
                    {
                        var obj = dp[Encode(i, j, k)];
                        if (obj is null) continue;
                        if (i + da >= 0 && j + db >= 0 && k + dc >= 0) 
                            newdp[Encode(i + da, j + db, k + dc)] = obj.Push(s[0]);
                        if (i - da >= 0 && j - db >= 0 && k - dc >= 0) 
                            newdp[Encode(i - da, j - db, k - dc)] = obj.Push(s[1]);
                    }
                }
            }
            dp = newdp;
        }
        var res = dp.FirstOrDefault(x => x != null);
        if (res == null)
        {
            Console.WriteLine("No");
            return;
        }
        Console.WriteLine("Yes");
        foreach (var item in res.Reverse())
        {
            Console.WriteLine(item);
        }
    }
}

