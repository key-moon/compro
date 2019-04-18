// detail: https://yukicoder.me/submissions/339870
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
using MethodImplOptions = System.Runtime.CompilerServices.MethodImplOptions;
using MethodImplAttribute = System.Runtime.CompilerServices.MethodImplAttribute;


static class P
{
    static void Main()
    {
        var nm = Console.ReadLine().Split().Select(long.Parse).ToArray();
        long n = nm[0];
        long m = nm[1];
        long a = 0;
        long b = 1;
        
        for (int i = 3; i <= n; i++)
        {
            var tmp = b;
            b = (a + b) % m;
            a = tmp;
        }
        Console.WriteLine(b);
    }
}
