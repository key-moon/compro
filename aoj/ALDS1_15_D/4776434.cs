// detail: https://onlinejudge.u-aizu.ac.jp/status/users/keymoon/submissions/1/ALDS1_15_D/judge/4776434/C#
using System;
using System.Linq;

public static class P
{
    public static void Main()
    {
        string s = Console.ReadLine();
        var freq = s.GroupBy(x => x).Select(x => x.Count()).ToList();
        long res = 0;
        while (freq.Count != 1)
        {
            var a = freq.Min();
            freq.Remove(a);
            var b = freq.Min();
            freq.Remove(b);
            res += a + b;
            freq.Add(a + b);
        }
        if (res == 0) res = s.Length;
        Console.WriteLine(res);
    }
}

