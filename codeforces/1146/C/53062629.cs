// detail: https://codeforces.com/contest/1146/submission/53062629
using System;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using static System.Math;
using LayoutKind = System.Runtime.InteropServices.LayoutKind;
using StructLayoutAttribute = System.Runtime.InteropServices.StructLayoutAttribute;
using FieldOffsetAttribute = System.Runtime.InteropServices.FieldOffsetAttribute;

static class P
{
    static void Main()
    {
        int t = int.Parse(Console.ReadLine());
        for (int _ = 0; _ < t; _++)
        {
            int n = int.Parse(Console.ReadLine());
            int max = 0;
            for (int i = 0; i < 10; i++)
            {
                List<int> a = new List<int>();
                List<int> b = new List<int>();
                for (int j = 0; j < n; j++)
                {
                    if (((j >> i) & 1) == 1) a.Add(j + 1);
                    else b.Add(j + 1);
                }
                if (a.Count == 0 || b.Count == 0) continue;
                Console.WriteLine($"{a.Count} {b.Count} {string.Join(" ", a)} {string.Join(" ", b)}");
                var res = int.Parse(Console.ReadLine());
                if (res == -1) return;
                max = Max(max, res);
            }
            Console.WriteLine($"-1 {max}");
        }
    }
}
