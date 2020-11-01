// detail: https://atcoder.jp/contests/abc181/submissions/17819254
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
        var s = Console.ReadLine();
        if (s.Length <= 3)
        {
            string[] cands = new[] { s };
            if (s.Length == 3)
            {
                cands = new[]
                {
                    $"{s[0]}{s[1]}{s[2]}",
                    $"{s[0]}{s[2]}{s[1]}",
                    $"{s[1]}{s[0]}{s[2]}",
                    $"{s[1]}{s[2]}{s[0]}",
                    $"{s[2]}{s[0]}{s[1]}",
                    $"{s[2]}{s[1]}{s[0]}"
                };
            }
            if (s.Length == 2)
            {
                cands = new[]
                {
                    $"{s[0]}{s[1]}",
                    $"{s[1]}{s[0]}",
                };
            }
            foreach (var item in cands)
            {
                var n = int.Parse(string.Join("", item));
                if (n % 8 == 0)
                {
                    Console.WriteLine("Yes");
                    return;
                }
            }
            Console.WriteLine("No");
            return;
        }
        int[] cnts = Enumerable.Range(0, 10).Select(x => s.Count(y => y - '0' == x)).ToArray();
        for (int i = 1000; i < 2000; i += 8)
        {
            var t = i.ToString().Substring(1);
            for (int j = 0; j < 10; j++)
            {
                if (cnts[j] < t.Count(x => x - '0' == j)) goto end;
            }
            Console.WriteLine("Yes");
            return;
            end:;
        }
        Console.WriteLine("No");
    }
}