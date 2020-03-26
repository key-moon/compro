// detail: https://codeforces.com/contest/1328/submission/74405891
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
using MethodImplAttribute = System.Runtime.CompilerServices.MethodImplAttribute;
using MethodImplOptions = System.Runtime.CompilerServices.MethodImplOptions;

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
        var x = Console.ReadLine();
        List<char> a = new List<char>();
        List<char> b = new List<char>();
        bool alreadyHas1 = false;
        foreach (var c in x)
        {
            if (alreadyHas1)
            {
                a.Add('0');
                b.Add(c);
                continue;
            }
            if (c == '2')
            {
                a.Add('1');
                b.Add('1');
                continue;
            }
            if (c == '0')
            {
                a.Add('0');
                b.Add('0');
                continue;
            }
            if (c == '1')
            {
                a.Add('1');
                b.Add('0');
                alreadyHas1 = true;
                continue;
            }
        }

        Console.WriteLine(string.Join("", a));
        Console.WriteLine(string.Join("", b));
    }
}
