// detail: https://yukicoder.me/submissions/612268
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
        int n = int.Parse(Console.ReadLine());
        var s = Console.ReadLine();
        if (s.Contains("11") || s.Contains("00") || 4 <= s.Length) Console.WriteLine("YES");
        else Console.WriteLine("NO");
    }
}
