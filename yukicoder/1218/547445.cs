// detail: https://yukicoder.me/submissions/547445
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
        var nz = Console.ReadLine().Split().Select(int.Parse).ToArray();
        var n = nz[0];
        var z = nz[1];
        if (n == 1)
        {
            Console.WriteLine(z != 1 ? "Yes" : "No");
            return;
        }
        for (int i = 1; i <= z; i++)
        {
            for (int j = 1; j <= z; j++)
            {
                if (Pow(i, n) + Pow(j, n) == Pow(z, n))
                {
                    Console.WriteLine("Yes");
                    return;
                }
            }
        }
        Console.WriteLine("No");
        return;
    }
}