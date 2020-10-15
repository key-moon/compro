// detail: https://onlinejudge.u-aizu.ac.jp/status/users/keymoon/submissions/1/ALDS1_14_D/judge/4916046/C#
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
        Console.SetOut(new StreamWriter(Console.OpenStandardOutput()) { AutoFlush = false });
        string s = Console.ReadLine();
        int n = int.Parse(Console.ReadLine());

        var sa = SA(s);
        for (int i = 0; i < n; i++)
        {
            var t = Console.ReadLine();
            int valid = -1, invalid = s.Length;
            while (invalid - valid > 1)
            {
                var mid = (valid + invalid) / 2;

                int sj = sa[mid], tj = 0;
                for (; sj < s.Length && tj < t.Length; sj++, tj++)
                {
                    if (s[sj] != t[tj])
                    {
                        if (s[sj] < t[tj]) valid = mid;
                        else invalid = mid;
                        goto end;
                    }
                }
                // tよりsが長い
                if (tj == t.Length) invalid = mid;
                else valid = mid;
                end:;
            }
            if (invalid < sa.Length && sa[invalid] + t.Length <= s.Length && s.Substring(sa[invalid], t.Length) == t) Console.WriteLine(1);
            else Console.WriteLine(0);
        }
        Console.Out.Flush();
    }

    private static int[] SA(string sm)
    {
        var s = sm.Select(x => (int)x).ToArray();
        var n = s.Length;
        var sa = Enumerable.Range(0, n).ToArray();
        var rnk = s.ToArray();
        var tmp = new int[n];

        for (int k = 1; k < n; k <<= 1)
        {
            Comparison<int> compare = (int x, int y) =>
            {
                if (rnk[x] != rnk[y])
                {
                    return rnk[x] - rnk[y];
                }

                int rx = x + k < n ? rnk[x + k] : -1;
                int ry = y + k < n ? rnk[y + k] : -1;

                return rx - ry;
            };

            Array.Sort(sa, compare);
            tmp[sa[0]] = 0;
            for (int i = 1; i < sa.Length; i++)
            {
                tmp[sa[i]] = tmp[sa[i - 1]] + (compare(sa[i - 1], sa[i]) < 0 ? 1 : 0);
            }
            var a = tmp;
            tmp = rnk;
            rnk = a;
        }

        return sa;
    }
}

