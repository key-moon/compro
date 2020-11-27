// detail: https://yukicoder.me/submissions/585021
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
        var lsb = n & -n;
        if (lsb == n)
        {
            Console.WriteLine("-1 -1 -1");
            return;
        }
        Console.WriteLine($"{n} {lsb} {n ^ lsb}");

    }
}
