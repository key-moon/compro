// detail: https://yukicoder.me/submissions/612308
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
        var nm = Console.ReadLine().Split().Select(long.Parse).ToArray();
        var n = nm.Min();
        var m = nm.Max();
        var p = double.Parse(Console.ReadLine());
        var cnts = new long[5];
        if (n == 1)
        {
            if (m == 1)
            {
                cnts[0] = 1;
            }
            else
            {
                cnts[1] = 2;
                cnts[2] = m - 2;
            }
        }
        else
        {
            cnts[2] = 4;
            cnts[3] = (n - 2) * 2 + (m - 2) * 2;
            cnts[4] = (n - 2) * (m - 2);
        }
        double res = 0;
        for (int i = 0; i < cnts.Length; i++)
            res += p * Pow(p, i) * cnts[i];
        Console.WriteLine(res);
    }
}
