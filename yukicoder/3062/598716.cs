// detail: https://yukicoder.me/submissions/598716
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
        var ab = Console.ReadLine().Split().Select(long.Parse).ToArray();
        if (ab[0] == 0) Console.WriteLine(ab[1]);
        else if (ab[1] < 0) Console.WriteLine(ab.Sum());
        else Console.WriteLine($"{ab[0]}{ab[1]}");
    }
}
