// detail: https://atcoder.jp/contests/judge-update-202004/submissions/11585391
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
        int n = int.Parse(Console.ReadLine());
        List<int> red = new List<int>();
        List<int> blue = new List<int>();
        for (int i = 0; i < n; i++)
        {
            var xc = Console.ReadLine().Split();
            (xc[1] == "R" ? red : blue).Add(int.Parse(xc[0]));
        }
        red.Sort();
        blue.Sort();

        Console.WriteLine(string.Join("\n", red));
        Console.WriteLine(string.Join("\n", blue));
    }
}