// detail: https://codeforces.com/contest/1427/submission/95107013
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
        int n = int.Parse(Console.ReadLine());
        for (int i = 0; i < n; i++)
        {
            Solve();
        }
        Console.Out.Flush();
    }
    static void Solve()
    {
        var nk = Console.ReadLine().Split().Select(int.Parse).ToArray();
        var k = nk[1];
        var s = Console.ReadLine();
        if (s.Count(x => x == 'W') == 0)
        {
            Console.WriteLine(Max(0, Min(s.Length, k) * 2 - 1));
            return;
        }
        List<int> blanks = new List<int>();
        bool hasWin = false;
        int streak = 0;
        int res = Min(s.Count(x => x == 'L'), k) * 2;
        for (int i = 0; i < s.Length; i++)
        {
            if (s[i] == 'W')
            {
                if (streak == 0 && i != 0) res++;
                if (streak != 0)
                {
                    if (hasWin) blanks.Add(streak);
                }
                res++;
                streak = 0;
                hasWin = true;
            }
            else streak++;
        }
        
        foreach (var blank in blanks.OrderBy(x => x))
        {
            if (k < blank) break;
            res++;
            k -= blank;
        }

        Console.WriteLine(res);
    }
}