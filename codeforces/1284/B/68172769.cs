// detail: https://codeforces.com/contest/1284/submission/68172769
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
        int n = int.Parse(Console.ReadLine());
        var l = Enumerable.Repeat(0, n).Select(_ => Seq.Parse(Console.ReadLine())).ToArray();
        var nonAsecnt = l.Where(x => !x.IsAscent).ToArray();
        long res = 0;
        long ascentCount = n - nonAsecnt.Length;
        res += ascentCount * n + n * ascentCount - ascentCount * ascentCount;
        var orderByMax = nonAsecnt.OrderBy(x => x.Max).ToArray();
        var orderByMin = nonAsecnt.OrderBy(x => x.Min).ToArray();
        
        var j = 0;
        for (int i = 0; i < orderByMin.Length; i++)
        {
            while (j < orderByMax.Length && orderByMin[i].Min >= orderByMax[j].Max)
                j++;
            res += nonAsecnt.Length - j;
        }
        Console.WriteLine(res);
    }
}

class Seq
{
    public int Min;
    public int Max;
    public bool IsAscent;
    public Seq(int[] seq)
    {
        Min = seq[0];
        Max = seq[0];
        for (int i = 0; i < seq.Length; i++)
        {
            if (Min < seq[i]) IsAscent = true;
            if (seq[i] < Min) Min = seq[i];
            if (Max < seq[i]) Max = seq[i];
        }
    }
    public static Seq Parse(string s) => new Seq(s.Split().Skip(1).Select(int.Parse).ToArray());
}
