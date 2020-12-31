// detail: https://yukicoder.me/submissions/598662
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
        long a = long.Parse(Console.ReadLine());
        int res = int.MaxValue;
        for (int n = 2; n <= 100; n++)
        {
            int m = 0;
            BigInteger cur = 1;
            while (cur < a)
            {
                cur *= n;
                m++;
            }
            res = Min(res, n * m);
        }
        Console.WriteLine(res);
    }
}