// detail: https://yukicoder.me/submissions/426358
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
using MethodImplOptions = System.Runtime.CompilerServices.MethodImplOptions;
using MethodImplAttribute = System.Runtime.CompilerServices.MethodImplAttribute;

static class P
{
    static void Main()
    {
        var ab = Console.ReadLine().Split().Select(int.Parse).ToArray();
        var res = (ab[0] * BigInteger.Parse("100000000000000000000000000000000000000000000000000") / ab[1]).ToString();
        if (res.Length <= 50) res = "0." + res.PadLeft(50, '0');
        else res = res.Substring(0, res.Length - 50) + "." + res.Substring(res.Length - 50);
        Console.WriteLine(res);
    }
}