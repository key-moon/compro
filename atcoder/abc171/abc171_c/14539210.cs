// detail: https://atcoder.jp/contests/abc171/submissions/14539210
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
        long n = long.Parse(Console.ReadLine());
        Console.WriteLine(Base26(n));
    }

    public static string Base26(long self)
    {
        if (self <= 0) return "";

        long n = (self % 26 == 0) ? 26 : self % 26;
        if (self == n) return ((char)(n + 96)).ToString();
        return Base26((self - n) / 26) + ((char)(n + 96)).ToString();
    }
}