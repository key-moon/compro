// detail: https://codeforces.com/contest/1566/submission/128595621
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
        string s = Console.ReadLine();
        var arr = s.SkipWhile(x => x == '1').Reverse().SkipWhile(x => x == '1').ToArray();
        var zero = arr.Contains('0');
        var one = arr.Contains('1');
        if (!zero) Console.WriteLine("0");
        else if (!one) Console.WriteLine("1");
        else Console.WriteLine("2");
    }
}