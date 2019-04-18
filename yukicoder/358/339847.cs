// detail: https://yukicoder.me/submissions/339847
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
        var a = Console.ReadLine().Split().Select(int.Parse).ToArray();
        int res = 0;
        for (int i = 1; i <= 1000; i++)
        {
            if (IsKadomatsu(a[0] % i, a[1] % i, a[2] % i)) res++;
        }
        Console.WriteLine(IsKadomatsu(a[0],a[1],a[2]) ? "INF" : res.ToString());
    }
    static bool IsKadomatsu(int a, int b, int c) => a != c && ((a < b && b > c) || (a > b && b < c)); 
}
