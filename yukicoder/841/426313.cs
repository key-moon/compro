// detail: https://yukicoder.me/submissions/426313
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Text.RegularExpressions;
using static System.Math;
using System.Threading.Tasks;
using MethodImplAttribute = System.Runtime.CompilerServices.MethodImplAttribute;
using MethodImplOptions = System.Runtime.CompilerServices.MethodImplOptions;

public static class P
{
    public static void Main()
    {
        var s = Console.ReadLine().Split();
        if (IsWeekend(s[0]) && IsWeekend(s[1])) Console.WriteLine("8/33");
        else if (IsWeekend(s[0])) Console.WriteLine("8/32");
        else Console.WriteLine("8/31");
    }

    public static bool IsWeekend(string s) => s == "Sat" || s == "Sun";
}
