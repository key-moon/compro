// detail: https://codeforces.com/contest/1609/submission/137227087
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
        var nq = Console.ReadLine().Split().Select(int.Parse).ToArray();
        var n = nq[0];
        var q = nq[1];
        char[] s = Console.ReadLine().ToArray();
        bool IsABC(int ind)
        {
            if (ind < 0) return false;
            if (s.Length <= ind + 2) return false;
            return s[ind] == 'a' && s[ind + 1] == 'b' && s[ind + 2] == 'c';
        }
        int aroundABCCnt(int ind)
        {
            int res = 0;
            for (int i = -2; i <= 2; i++) if (IsABC(ind + i)) res++;
            return res;
        }
        int cnt = 0;
        for (int i = 0; i < s.Length - 2; i++) if (IsABC(i)) cnt++;
        for (int i = 0; i < q; i++)
        {
            var query = Console.ReadLine().Split();
            var pos = int.Parse(query[0]) - 1;
            var c = query[1][0];
            cnt -= aroundABCCnt(pos);
            s[pos] = c;
            cnt += aroundABCCnt(pos);
            Console.WriteLine(cnt);
        }
        Console.Out.Flush();
    }
}