// detail: https://onlinejudge.u-aizu.ac.jp/status/users/keymoon/submissions/1/2699/judge/5350540/C#
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
        while (true)
        {
            var de = Console.ReadLine().Split().Select(int.Parse).ToArray();
            var d = de[0];
            var e = de[1];
            if (d == 0) return;

            var min = double.MaxValue;
            for (int x = 0; x <= d; x++)
            {
                var y = d - x;
                var diff = Abs(e - Sqrt(x * x + y * y));
                min = Min(min, diff);
            }
            Console.WriteLine(min);
        }
    }
}
