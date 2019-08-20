// detail: https://codeforces.com/contest/1204/submission/59143663
using System;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Debug = System.Diagnostics.Debug;
using static System.Math;
using System.Runtime.CompilerServices;

static class P
{
    static void Main()
    {
        //100000000
        //        1
        //      1
        //    1
        //  1
        //1

        var s = Console.ReadLine();
        if (s == "0")
        {
            Console.WriteLine(0);
            return;
        }
        var max = (s.Length + 1) / 2;
        if (s.Length % 2 == 1 && s.Count(x => x == '1') == 1) max--;
        Console.WriteLine(max);
    }
}