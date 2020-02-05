// detail: https://yukicoder.me/submissions/426331
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
        var ab = Console.ReadLine().Split().Select(long.Parse).ToList();
        if (IsEasyNum(ab[0]) && IsEasyNum(ab[1])) Console.WriteLine(ab[0] * ab[1] / 10);
        else Console.WriteLine(Abs(ab[0] * ab[1]) <= 99999999 ? (ab[0] * ab[1]).ToString() : "E");
    }

    static bool IsEasyNum(long num)
    {
        var log = num.ToString().Reverse().TakeWhile(x => x == '0').Count();
        var pow = Pow(10, log);
        var d = num / pow;
        return log >= 2 && Abs(d) < 10;
    }
}
