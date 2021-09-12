// detail: https://codeforces.com/contest/1566/submission/128605492
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
        int t = int.Parse(Console.ReadLine());
        for (int i = 0; i < t; i++)
        {
            Solve();
        }
        Console.Out.Flush();
    }
    static void Solve()
    {
        int n = int.Parse(Console.ReadLine());
        string s1 = Console.ReadLine();
        string s2 = Console.ReadLine();
        
        int none = 0;
        int has0 = -100;
        int has1 = -100;
        foreach (var (c1, c2) in s1.Zip(s2))
        {
            int newNone = int.MinValue, newHas0 = int.MinValue, newHas1 = int.MinValue;
            if (c1 == '0' && c2 == '0')
            {
                newNone = Max(newNone, none + 1);
                newNone = Max(newNone, has0 + 1);
                newNone = Max(newNone, has1 + 2);

                newHas0 = Max(newHas0, none);
                newHas0 = Max(newHas0, has0);
                newHas0 = Max(newHas0, has1);
            }
            else if (c1 == '1' && c2 == '1')
            {
                newNone = Max(newNone, none);
                newNone = Max(newNone, has0 + 2);
                newNone = Max(newNone, has1);

                newHas1 = Max(newHas1, none);
                newHas1 = Max(newHas1, has0);
                newHas1 = Max(newHas1, has1);
            }
            else
            {
                newNone = Max(newNone, none + 2);
                newNone = Max(newNone, has0 + 2);
                newNone = Max(newNone, has1 + 2);
            }
            none = Max(none, newNone);
            has0 = Max(has0, newHas0);
            has1 = Max(has1, newHas1);
        }
        var res = int.MinValue;
        res = Max(res, none);
        res = Max(res, has0 + 1);
        res = Max(res, has1);
        Console.WriteLine(res);
    }
}