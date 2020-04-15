// detail: https://atcoder.jp/contests/abc057/submissions/11954288
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
        var nm = Console.ReadLine().Split().Select(int.Parse).ToArray();
        var students = Enumerable.Repeat(0, nm[0]).Select(_ => Console.ReadLine().Split().Select(int.Parse).ToArray()).ToArray();
        var point = Enumerable.Repeat(0, nm[1]).Select(_ => Console.ReadLine().Split().Select(int.Parse).ToArray()).ToArray();
        foreach (var student in students)
        {
            int minDist = int.MaxValue;
            int minInd = -1;
            for (int i = 0; i < point.Length; i++)
            {
                var dist = Abs(student[0] - point[i][0]) + Abs(student[1] - point[i][1]);
                if (dist < minDist)
                {
                    minInd = i;
                    minDist = dist;
                }
            }
            Console.WriteLine(minInd + 1);
        }
    }
}