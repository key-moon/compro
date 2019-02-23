// detail: https://yukicoder.me/submissions/319216
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
using static System.Math;

class P
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        int res = 0;
        for (int i = 0; i < n; i++)
        {
            var a = Console.ReadLine().Split(':',' ').Select(int.Parse).ToList();
            res += (int)(new TimeSpan(1, a[2], a[3], 0) - new TimeSpan(a[0], a[1], 0)).TotalMinutes % 1440;
        }
        Console.WriteLine(res);
    }
}
