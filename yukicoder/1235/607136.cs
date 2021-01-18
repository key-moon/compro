// detail: https://yukicoder.me/submissions/607136
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
        double res = 0;
        for (int i = 1; i < 1e6; i++) res += Pow(i, -n);
        Console.WriteLine(res);
    }
}