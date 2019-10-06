// detail: https://codeforces.com/contest/1240/submission/62007317
using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using static System.Math;
using MethodImplOptions = System.Runtime.CompilerServices.MethodImplOptions;
using MethodImplAttribute = System.Runtime.CompilerServices.MethodImplAttribute;

public static class P
{
    public static void Main()
    {
        int q = int.Parse(Console.ReadLine());
        StringBuilder builder = new StringBuilder();
        for (int i = 0; i < q; i++)
        {
            builder.AppendLine(Solve().ToString());
        }
        Console.Write(builder.ToString());
    }
    static int Solve()
    {
        int n = int.Parse(Console.ReadLine());
        var a = Console.ReadLine().Split().Select(int.Parse).ToArray();
        var compressDict = a.Distinct().OrderBy(x => x).Select((Elem, Ind) => new { Elem, Ind }).ToDictionary(x => x.Elem, x => x.Ind);
        a = a.Select(x => compressDict[x]).ToArray();
        Section[] elems = Enumerable.Repeat(new Section() { Begin = int.MaxValue, End = int.MinValue }, compressDict.Count).ToArray();
        for (int i = 0; i < a.Length; i++)
        {
            elems[a[i]].Update(i);
        }
        var curStreak = 0;
        var maxStreak = 0;
        for (int i = 0; i < elems.Length - 1; i++)
        {
            if (elems[i] < elems[i + 1]) maxStreak = Max(maxStreak, ++curStreak);
            else curStreak = 0;
        }
        return elems.Length - (maxStreak + 1);
    }
}

struct Section
{
    public int Begin;
    public int End;
    public void Update(int val)
    {
        Begin = Min(Begin, val);
        End = Max(End, val);
    }
    public static bool operator <(Section l, Section r) => l.End < r.Begin;
    public static bool operator >(Section l, Section r) => l.End > r.Begin;
}

