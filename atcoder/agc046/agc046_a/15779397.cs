// detail: https://atcoder.jp/contests/agc046/submissions/15779397
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
        for (int i = 360; true; i += 360)
        {
            if (i % n == 0)
            {
                Console.WriteLine(i / n);
                return;
            }
        }
    }
}
