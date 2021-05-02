// detail: https://codeforces.com/contest/1515/submission/114902419
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
#if !DEBUG
        Console.SetOut(new StreamWriter(Console.OpenStandardOutput()) { AutoFlush = false });
#endif
        int t = int.Parse(Console.ReadLine());
        for (int i = 0; i < t; i++)
        {
            Solve();
        }
        Console.Out.Flush();
    }
    static void Solve()
    {
        var nlr = Console.ReadLine().Split().Select(int.Parse).ToArray();
        var n = nlr[0];
        var l = nlr[1];
        var r = nlr[2];
        var a = Console.ReadLine().Split().Select(int.Parse).ToArray();
        // cost1を払わないと消せないペア→同族同色/異族異色

        var colors = a.Distinct().ToArray();
        var ls = new Dictionary<int, int>();
        var rs = new Dictionary<int, int>();
        var lcnt = l;
        var rcnt = r;
        int res = 0;
        foreach (var c in colors)
        {
            ls.Add(c, 0);
            rs.Add(c, 0);
        }
        foreach (var item in a.Take(l)) ls[item]++;
        foreach (var item in a.Skip(l)) rs[item]++;

        foreach (var c in colors)
        {
            while (ls[c] != 0 && rs[c] != 0)
            {
                ls[c]--; lcnt--;
                rs[c]--; rcnt--;
            }
        }

        if (lcnt > rcnt) (ls, rs, lcnt, rcnt) = (rs, ls, rcnt, lcnt);

        foreach (var c in colors)
        {
            while (2 <= rs[c])
            {
                if (lcnt >= rcnt) goto end;
                res++;
                rs[c] -= 2; rcnt -= 2;
            }
        }
        end:;
        res += lcnt;
        rcnt -= lcnt;
        lcnt -= lcnt;
        res += rcnt;
        Console.WriteLine(res);
    }
}