// detail: https://yukicoder.me/submissions/547389
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
        var s = Console.ReadLine();
        Console.WriteLine($"{"abcdefghijklmnopqrstuvwxyz".Except(s).First()}to{s.GroupBy(x => x).Where(x => x.Count() == 2).First().Key}");
    }
}