// detail: https://codeforces.com/contest/1131/submission/50355291
using System;
using System.IO;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using static System.Math;
using Debug = System.Diagnostics.Debug;

class Ph
{
    static void Main()
    {
        var a = Console.ReadLine().Split().Select(int.Parse).ToList();
        //- - - -
        //下の辺
        long res = 0;
        res += a[0] + 2;
        res += a[2] + 2;
        res += (a[1] + a[3]) * 2;
        res += Abs(a[0] - a[2]);
        Console.WriteLine(res);
    }
}