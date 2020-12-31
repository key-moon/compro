// detail: https://yukicoder.me/submissions/598627
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
        var a = Console.ReadLine().Split().Select(int.Parse).ToArray();

        Console.WriteLine(a[0] < a[1] && a[2] > a[3] ? "YES" : "NO");
    }
}