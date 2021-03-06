// detail: https://atcoder.jp/contests/abc194/submissions/20697852
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
        double d = 0;
        for (int i = 2; i <= n; i++)
        {
            double remain = n - i + 1;
            d += n / remain;
        }
        Console.WriteLine(d);
    }
}
