// detail: https://atcoder.jp/contests/panasonic2020/submissions/10837096
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
        int n = int.Parse(Console.ReadLine());
        string[] s = new[] { "a" };
        for (int i = 2; i <= n; i++)
        {
            s = s.SelectMany(Nexts).ToArray();
        }

        Console.WriteLine(string.Join("\n", s.OrderBy(x => x)));
    }
    static IEnumerable<string> Nexts(string x)
    {
        var maxChar = (char)(x.Max() + 1);
        for (char i = 'a'; i <= maxChar; i++)
        {
            yield return x + i;
        }
    }
}
