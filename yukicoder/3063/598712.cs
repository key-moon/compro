// detail: https://yukicoder.me/submissions/598712
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
        var rc = Console.ReadLine().Split().Select(int.Parse).ToArray();
        var s = Console.ReadLine().Split().Select(int.Parse).ToArray();
        var t = Console.ReadLine().Split().Select(int.Parse).ToArray();
        Console.WriteLine(s.Zip(t, (x, y) => Abs(x - y)).Sum());
    }
}
