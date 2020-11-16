// detail: https://codeforces.com/contest/652/submission/98555346
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
        var a = Console.ReadLine().Split().Select(int.Parse).OrderBy(x => x).ToArray();
        var lo = a.Take((n + 1) / 2).ToArray();
        var hi = a.Skip((n + 1) / 2).Reverse().ToArray();
        List<int> res = new List<int>();
        for (int i = 0; i < n; i++)
        {
            res.Add((i % 2 == 0 ? lo : hi)[i / 2]);
        }

        Console.WriteLine(string.Join(" ", res));
    }
}