// detail: https://yukicoder.me/submissions/598632
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
        var ab = Console.ReadLine().Split().Select(int.Parse).OrderByDescending(x => x).ToArray();
        int res = 0;
        int ind = 0;
        while (ab[ind] != 0)
        {
            ab[ind]--;
            ind ^= 1;
            res++;
        }
        Console.WriteLine(res - 1);
    }
}
