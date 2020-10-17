// detail: https://codeforces.com/contest/1428/submission/95748604
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
        int n = int.Parse(Console.ReadLine());
        for (int i = 0; i < n; i++)
        {
            Solve();
        }
    }
    static void Solve()
    {
        string s = Console.ReadLine();
        int cura = 0;
        int curb = 0;
        int n = s.Length;
        foreach (var c in s)
        {
            if (c == 'A') cura++;
            else
            {
                if (cura != 0)
                {
                    cura--;
                    n -= 2;
                }
                else if (curb != 0)
                {
                    curb--;
                    n -= 2;
                }
                else
                {
                    curb++;
                }
            }
        }
        Console.WriteLine(n);
    }
}