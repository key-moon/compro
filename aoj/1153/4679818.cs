// detail: https://onlinejudge.u-aizu.ac.jp/status/users/keymoon/submissions/1/1153/judge/4679818/C#
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
            var nm = Console.ReadLine().Split().Select(int.Parse).ToArray();
            if (nm[0] == 0) break;
            var a = Enumerable.Repeat(0, nm[0]).Select(_ => int.Parse(Console.ReadLine())).ToArray();
            var b = Enumerable.Repeat(0, nm[1]).Select(_ => int.Parse(Console.ReadLine())).ToArray();
            var asum = a.Sum();
            var bsum = b.Sum();
            int min = int.MaxValue;
            var resA = 0;
            var resB = 0;
            for (int i = 0; i < a.Length; i++)
            {
                for (int j = 0; j < b.Length; j++)
                {
                    if ((asum - a[i] + b[j]) == (bsum - b[j] + a[i]))
                    {
                        var sum = a[i] + b[j];
                        if (sum < min)
                        {
                            min = sum;
                            resA = a[i];
                            resB = b[j];
                        }
                    }
                }
            }
            Console.WriteLine(min == int.MaxValue ? "-1" : $"{resA} {resB}");
        }
        Console.Out.Flush();
    }
}
