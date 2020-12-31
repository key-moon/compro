// detail: https://yukicoder.me/submissions/598648
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
        int k = int.Parse(Console.ReadLine());
        double res = 0;
        for (long i = 1; i < 10000000; i++) res += 1.0 / (i * (i + k));
        Console.WriteLine(res);
    }
}