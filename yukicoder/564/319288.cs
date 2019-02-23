// detail: https://yukicoder.me/submissions/319288
using System;
using System.IO;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using static System.Math;
using Int = System.Int64;
using Debug = System.Diagnostics.Debug;

class P
{
    static void Main()
    {
        var a = Console.ReadLine().Split().Select(int.Parse).ToList();
        int res = 1;
        for (int i = 1; i < a[1]; i++)
        {
            if (int.Parse(Console.ReadLine()) > a[0]) res++;
        }
        Console.WriteLine($"{res}{(res % 10 == 1 ? "st" : res % 10 == 2 ? "nd" : res % 10 == 3 ? "rd" : "th")}");
    }
}
