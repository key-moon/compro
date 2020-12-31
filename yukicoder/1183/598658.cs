// detail: https://yukicoder.me/submissions/598658
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
        var b = Console.ReadLine().Split().Select(int.Parse).ToArray();
        var diff = a.Zip(b, (x, y) => x ^ y).ToArray();

        int last = 0;
        int res = 0;
        for (int i = 0; i < n; i++)
        {
            if (last != diff[i] && last == 1) res++;
            last = diff[i];
        }
        if (last == 1) res++;
        Console.WriteLine(res);
    }
}