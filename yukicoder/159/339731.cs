// detail: https://yukicoder.me/submissions/339731
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
using LayoutKind = System.Runtime.InteropServices.LayoutKind;
using MethodImplOptions = System.Runtime.CompilerServices.MethodImplOptions;
using MethodImplAttribute = System.Runtime.CompilerServices.MethodImplAttribute;
using System.Runtime.CompilerServices;


static class P
{
    static void Main()
    {
        var pq = Console.ReadLine().Split().Select(double.Parse).ToArray();
        //裏→表
        var p1 = (1 - pq[0]) * pq[1];

        //表→裏→表
        var p2 = pq[0] * (1 - pq[1]) * (pq[1]);
        Console.WriteLine(p1 < p2 ? "YES" : "NO");
    }
}