// detail: https://yukicoder.me/submissions/339737
using System;
using System.IO;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Numerics;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using static System.Math;
using Debug = System.Diagnostics.Debug;


static class P
{
    static void Main()
    {
        var awb = Console.ReadLine().Split().Select(int.Parse).ToArray();
        var bwb = Console.ReadLine().Split().Select(int.Parse).ToArray();
        var cd = Console.ReadLine().Split().Select(int.Parse).ToArray();
        var c = cd[0];
        var d = cd[1];

        if (awb[1] > c)
        {
            bwb[1] += c;
            awb[1] -= c;
        }
        else
        {
            c -= awb[1];
            bwb[1] += awb[1];
            awb[1] -= awb[1];
            bwb[0] += c;
            awb[0] -= c;
        }
        if (bwb[0] > d)
        {
            awb[0] += d;
        }
        else
        {
            awb[0] += bwb[0];
        }
        Console.WriteLine(awb[0]);
    }
}