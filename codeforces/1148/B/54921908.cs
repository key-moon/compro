// detail: https://codeforces.com/contest/1148/submission/54921908
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
using MethodImplOptions = System.Runtime.CompilerServices.MethodImplOptions;
using MethodImplAttribute = System.Runtime.CompilerServices.MethodImplAttribute;

static class P
{
    static void Main()
    {
        var nmttk = Console.ReadLine().Split().Select(int.Parse).ToArray();
        long t1 = nmttk[2];
        long t2 = nmttk[3];
        var k = nmttk[4];
        var a = Console.ReadLine().Split().Select(long.Parse).ToList();
        var b = Console.ReadLine().Split().Select(long.Parse).ToList();
        if (a.Count <= k || b.Count <= k)
        {
            Console.WriteLine(-1);
            return;
        }
        long max = 0;
        //aを何個キャンセルするか
        for (int i = 0; i <= k; i++)
        {
            var ind = b.BinarySearch(a[i] + t1);
            if (ind < 0) ind = ~ind;
            ind += (k - i);
            if (ind >= b.Count)
            {
                Console.WriteLine(-1);
                return;
            }
            max = Max(max, b[ind] + t2);
        }
        Console.WriteLine(max);
    }
}
