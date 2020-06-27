// detail: https://onlinejudge.u-aizu.ac.jp/status/users/keymoon/submissions/1/2699/judge/4620589/C#
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
            if (de[0] == 0) break;
            var d = de[0];
            var e = de[1];
            double min = double.MaxValue;
            for (int i = 0; i <= d; i++)
            {
                var diff = Abs(Sqrt(i * i + (d - i) * (d - i)) - e);
                min = Min(min, diff);
            }
            Console.WriteLine(min);
        }
    }
}
