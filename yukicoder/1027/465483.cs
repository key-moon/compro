// detail: https://yukicoder.me/submissions/465483
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
        //💠
        var d1d2 = Console.ReadLine().Split().Select(int.Parse).ToArray();
        var d1 = d1d2[0];
        var d2 = d1d2[1];
        Console.WriteLine(2 * d1 < d2 ? 0 : 2 * d1 == d2 ? 4 : d1 < d2 ? 8 : d1 == d2 ? 4 : 0);
    }
}