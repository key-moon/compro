// detail: https://onlinejudge.u-aizu.ac.jp/status/users/keymoon/submissions/1/1147/judge/4679758/C#
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
        while (true)
        {
            int n = int.Parse(Console.ReadLine());
            if (n == 0) break;
            var s = Enumerable.Repeat(0, n).Select(_ => int.Parse(Console.ReadLine())).ToArray();
            var min =  s.Min();
            var max =  s.Max();
            Console.WriteLine((s.Sum() - min - max) / (n - 2));
        }
        Console.Out.Flush();
    }
}
