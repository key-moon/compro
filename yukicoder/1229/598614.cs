// detail: https://yukicoder.me/submissions/598614
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
        int res = 0;
        for (int i = 0; i <= n; i++)
        {
            for (int j = 0; j <= i; j++)
            {
                for (int k = 0; k <= n; k++)
                {
                    if (i * 5 + j * 2 + k * 3 == n) res++;
                }
            }
        }
        Console.WriteLine(res);
    }
}
