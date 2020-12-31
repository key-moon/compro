// detail: https://yukicoder.me/submissions/598707
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
        string s = Console.ReadLine();
        string yeah = "YEAH!";
        Console.WriteLine(string.Join(" ", yeah.Select(x => s.Count(y => x == y))));
    }
}
