// detail: https://codeforces.com/contest/1182/submission/55434313
using System;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using static System.Math;
using Debug = System.Diagnostics.Debug;

static class P
{
    static void Main()
    {
        var n = int.Parse(Console.ReadLine());
        if (n % 2 == 1)
        {
            Console.WriteLine(0);
            return;
        }
        Console.WriteLine(1L << (n / 2));
    }
}
