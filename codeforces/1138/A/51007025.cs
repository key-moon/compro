// detail: https://codeforces.com/contest/1138/submission/51007025
using System;
using System.IO;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using System.Diagnostics;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using static System.Math;
using MethodImplOptions = System.Runtime.CompilerServices.MethodImplOptions;
using MethodImplAttribute = System.Runtime.CompilerServices.MethodImplAttribute;

class P
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        var a = Console.ReadLine().Split().Select(int.Parse).ToList();
        int currentStreak = 0;
        int lastStreak = 0;
        int kind = 0;
        int max = 0;
        for (int i = 0; i < a.Count; i++)
        {
            if(kind != a[i])
            {
                max = Max(max, Min(currentStreak, lastStreak) * 2);
                lastStreak = currentStreak;
                currentStreak = 0;
                kind = a[i];
            }
            currentStreak++;
        }
        max = Max(max, Min(currentStreak, lastStreak) * 2);
        
        Console.WriteLine(max);
    }
}
