// detail: https://yukicoder.me/submissions/423565
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
using MethodImplAttribute = System.Runtime.CompilerServices.MethodImplAttribute;
using MethodImplOptions = System.Runtime.CompilerServices.MethodImplOptions;

public static class P
{
    public static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        var a = Console.ReadLine().Split().Select(int.Parse).ToArray();
        int[] length = new int[500000];
        foreach (var elem in a)
        {
            var res = elem == 1 ? 0 : length[1];
            for (int j = 2; j * j <= elem; j++)
            {
                if (elem % j != 0) continue;
                res = Max(res, length[elem / j]);
                res = Max(res, length[j]);
            }
            length[elem] = Max(length[elem], res + 1);
        }
        Console.WriteLine(length.Max());
    }
}
