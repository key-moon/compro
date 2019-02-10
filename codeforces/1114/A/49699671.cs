// detail: https://codeforces.com/contest/1114/submission/49699671
using System;
using System.IO;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using System.Diagnostics;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using System.Runtime.CompilerServices;
using static System.Math;


class P
{
    static void Main()
    {
        int[] xyz = Console.ReadLine().Split().Select(int.Parse).ToArray();
        int[] gpb = Console.ReadLine().Split().Select(int.Parse).ToArray();
        if(gpb[0] >= xyz[0])
        {
            gpb[0] -= xyz[0];
        }
        else
        {
            Console.WriteLine("NO");
            return;
        }
        if(gpb[0] + gpb[1] >= xyz[1])
        {
            gpb[0] -= xyz[1];
        }
        else
        {
            Console.WriteLine("NO");
            return;
        }
        if(gpb.Sum() >= xyz[2])
        {
            Console.WriteLine("YES");
            return;
        }
        Console.WriteLine("NO");
        return;
    }
}
