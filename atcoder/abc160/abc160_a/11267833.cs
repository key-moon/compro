// detail: https://atcoder.jp/contests/abc160/submissions/11267833
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
using MethodImplAttribute = System.Runtime.CompilerServices.MethodImplAttribute;
using MethodImplOptions = System.Runtime.CompilerServices.MethodImplOptions;

public static class P
{
    public static void Main()
    {
        string s = Console.ReadLine();
        Console.WriteLine(s[2] == s[3] && s[4] == s[5] ? "Yes" : "No");
    }
}
