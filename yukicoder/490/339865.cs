// detail: https://yukicoder.me/submissions/339865
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
        int n = int.Parse(Console.ReadLine());
        var a = Console.ReadLine().Split().Select(int.Parse).ToArray();
        for (int i = 1; i < 2 * n - 3; i++)
        {
            for (int p = 0, q = i; p < q; p++, q--)
            {
                if(q < n && a[p] > a[q])
                {
                    var tmp = a[p];
                    a[p] = a[q];
                    a[q] = tmp;
                }
            }
        }
        Console.WriteLine(string.Join(" ", a));
    }
}
