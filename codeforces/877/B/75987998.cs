// detail: https://codeforces.com/contest/877/submission/75987998
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
        string s = Console.ReadLine();
        int[] aAccum = new int[s.Length + 1];
        int[] bAccum = new int[s.Length + 1];
        for (int i = 0; i < s.Length; i++) aAccum[i + 1] = aAccum[i] + (s[i] == 'a' ? 1 : 0);
        for (int i = 0; i < s.Length; i++) bAccum[i + 1] = bAccum[i] + (s[i] == 'b' ? 1 : 0);
        var res = aAccum[s.Length];
        for (int i = 0; i < s.Length; i++)
        {
            for (int j = i; j < s.Length; j++)
            {
                var a = aAccum[i] + (aAccum[s.Length] - aAccum[j + 1]) + (bAccum[j + 1] - bAccum[i]);
                res = Max(a, res);
            }
        }
        Console.WriteLine(res);
    }
}