// detail: https://yukicoder.me/submissions/339745
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
        int n = int.Parse(Console.ReadLine());
        var a = Console.ReadLine().Split().Select(int.Parse).OrderBy(x => x).ToArray();
        var res = 0;
        for (int i = 1; i <= n; i++) res += Abs(a[i - 1] - i);
        Console.WriteLine(res);
    }
}