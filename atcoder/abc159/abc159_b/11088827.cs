// detail: https://atcoder.jp/contests/abc159/submissions/11088827
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
        var b = s.Substring(0, (s.Length - 1) / 2);
        var c = s.Substring((s.Length + 1) / 2);
        Console.WriteLine(IsPalindrome(s) && IsPalindrome(b) && IsPalindrome(c) ? "Yes" : "No");
    }
    static bool IsPalindrome(string s) => s.Zip(s.Reverse(), (x, y) => x == y).All(x => x);
}
