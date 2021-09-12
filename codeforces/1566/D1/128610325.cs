// detail: https://codeforces.com/contest/1566/submission/128610325
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
        var nm = Console.ReadLine().Split().Select(int.Parse).ToArray();
        var m = nm[1];
        bool[] seat = new bool[m];
        var a = Console.ReadLine().Split().Select(int.Parse).ToArray();
        var seats = a.OrderBy(x => x).Select((elem, ind) => (elem, ind)).GroupBy(x => x.elem).ToDictionary(x => x.Key, x => new Stack<int>(x.OrderBy(x => x.ind).Select(x => x.ind)));
        int res = 0;
        foreach (var item in a)
        {
            var pos = seats[item].Pop();
            for (int i = 0; i < pos; i++)
                if (seat[i]) res++;
            seat[pos] = true;
        }
        Console.WriteLine(res);
    }
}