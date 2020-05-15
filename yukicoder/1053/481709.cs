// detail: https://yukicoder.me/submissions/481709
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using static System.Math;

public static class P
{
    public static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        var a = Console.ReadLine().Split().Select(int.Parse).ToArray();

        int res = 0;
        if (a.First() == a.Last())
        {
            res++;
            a = a.SkipWhile(x => a[0] == x).ToArray();
        }
        if (a.Length == 0)
        {
            Console.WriteLine(0);
            return;
        }
        var set = new HashSet<int>() { a[0] };
        var last = a[0];
        for (int i = 1; i < a.Length; i++)
        {
            if (last != a[i] && !set.Add(a[i]))
            {
                Console.WriteLine(-1);
                return;
            }
            last = a[i];
        }
        Console.WriteLine(res);
    }
}