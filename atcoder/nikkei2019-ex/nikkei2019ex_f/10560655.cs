// detail: https://atcoder.jp/contests/nikkei2019-ex/submissions/10560655
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
        for (int i = 1; i <= n; i++)
        {
            string s = "";
            for (int j = 2; j <= 6; j++)
            {
                if (i % j == 0) s += (char)('a' + j - 2);
            }
            if (s == "") s = i.ToString();
            Console.WriteLine(s);
        }
    }
}