// detail: https://yukicoder.me/submissions/319204
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
        var a = Console.ReadLine().Split().Select(int.Parse).ToList();
        int res = 0;
        for (int i = 0; i < a.Count - 2; i++)
        {
            if (a[i] != a[i + 2] && ((a[i] < a[i + 1] && a[i + 1] > a[i + 2]) || (a[i] > a[i + 1] && a[i + 1] < a[i + 2]))) res++;
        }
        Console.WriteLine(res);
    }
}
