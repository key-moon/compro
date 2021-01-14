// detail: https://yukicoder.me/submissions/603284
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
        var m = int.Parse(Console.ReadLine());
        var avg = a.Average();
        var sd = Sqrt(a.Average(x => Pow(avg - x, 2)));
        var res = sd != 0 ? 50 + (a[m - 1] - avg) / sd * 10 : 50;
        Console.WriteLine((int)Floor(Abs(res)) * Sign(res));
    }
}