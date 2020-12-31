// detail: https://yukicoder.me/submissions/598710
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
using static System.Numerics.BigInteger;

public static class P
{
    public static void Main()
    {
        var nmx = Console.ReadLine().Split().Select(int.Parse).ToArray();
        Console.WriteLine(3 <= nmx[2] - (nmx[0] - nmx[1]) ? "YES" : "NO");
    }
}
