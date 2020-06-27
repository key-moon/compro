// detail: https://onlinejudge.u-aizu.ac.jp/status/users/keymoon/submissions/1/1368/judge/4620757/C#
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
    static int[][] table;
    public static void Main()
    {
        table = Enumerable.Repeat(0, 10).Select(_ => Console.ReadLine().Split().Select(int.Parse).ToArray()).ToArray();
        //Console.WriteLine(Operation(new List<int>() { 2,0,1,6 }));
        int res = 0;
        for (int num = 0; num < 10000; num++)
        {
            var debug = false;
            var s = num.ToString().PadLeft(4, '0').Select(x => x - '0').ToList();
            s.Add(Operation(s));
            var origs = s.ToList();
            for (int j = 0; j < s.Count; j++)
            {
                for (int k = 0; k < 10; k++)
                {
                    if (s[j] == k) continue;
                    var old = s[j];
                    s[j] = k;
                    if (Validation(s))
                    {
                        if (debug) Console.WriteLine(string.Join(" ", s));
                        goto end;
                    }
                    s[j] = old;
                }
            }
            for (int j = 0; j < s.Count - 1; j++)
            {
                var k = j + 1;
                if (s[j] == s[k]) continue;
                var tmp = s[j];
                s[j] = s[k];
                s[k] = tmp;
                if (Validation(s))
                {
                    if (debug) Console.WriteLine(string.Join(" ", s));
                    goto end;
                }
                tmp = s[j];
                s[j] = s[k];
                s[k] = tmp;
            }
            continue;
            end:;
            if (debug) Console.WriteLine($"orig : {string.Join(" ", origs)}\n");
            res++;
        }
        Console.WriteLine(res);
    }
    public static int Operation(List<int> a)
    {
        var res = 0;
        for (int i = 0; i < a.Count; i++)
        {
            res = table[res][a[i]];
        }
        return res;
    }
    public static bool Validation(List<int> a)
    {
        return Operation(a) == 0;
    }
}
