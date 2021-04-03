// detail: https://codeforces.com/contest/1503/submission/111876193
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
        int t = int.Parse(Console.ReadLine());
        for (int i = 0; i < t; i++)
        {
            Solve();
        }
    }
    static void Solve()
    {
        int n = int.Parse(Console.ReadLine());
        string s = Console.ReadLine();
        var oneCount = s.Count(x => x == '1');
        var zeroCount = s.Count(x => x == '0');
        if (oneCount % 2 != 0 || zeroCount % 2 != 0)
        {
            Console.WriteLine("NO");
            return;
        }
        StringBuilder a = new StringBuilder();
        StringBuilder b = new StringBuilder();
        int curOne = 0;
        int curZero = 0;
        int depth = 0;
        for (int i = 0; i < s.Length; i++)
        {
            if (s[i] == '1')
            {
                curOne++;
                var c = oneCount < curOne * 2 ? ')' : '(';
                if (c == '(') depth++;
                else depth--;
                a.Append(c);
                b.Append(c);
            }
            if (s[i] == '0')
            {
                curZero++;
                var (c1, c2) = curZero % 2 == 1 ? (')', '(') : ('(', ')');
                if (c1 == '(') depth++;
                else depth--;
                a.Append(c1);
                b.Append(c2);
            }
            if (depth < 0)
            {
                Console.WriteLine("NO");
                return;
            }
        }
        Console.WriteLine("YES");
        Console.WriteLine(a.ToString());
        Console.WriteLine(b.ToString());
    }
}