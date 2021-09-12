// detail: https://codeforces.com/contest/1566/submission/128615591
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
        var n = nm[0];
        var m = nm[1];
        int[][] seat = Enumerable.Repeat(0, n).Select(_ => new int[m]).ToArray();
        var a = Console.ReadLine().Split().Select(int.Parse).ToArray();
        var seats = a.OrderBy(x => x).Select((elem, ind) => (elem, ind: (row: ind / m, col: ind % m))).GroupBy(x => x.elem).ToDictionary(x => x.Key, x => new Stack<(int, int)>(x.OrderByDescending(x => x.ind.row).ThenBy(x => x.ind.col).Select(x => x.ind)));
        int res = 0;
        foreach (var item in a)
        {
            var (row, col) = seats[item].Pop();
            for (int i = 0; i < col; i++)
                res += seat[row][i];
            seat[row][col] = 1;
        }
        Console.WriteLine(res);
    }
}