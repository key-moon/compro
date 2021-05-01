// detail: https://atcoder.jp/contests/abs/submissions/22233523
using System;
using System.Text.RegularExpressions;
public static class P
{
    public static void Main()
    {
        Console.WriteLine(Regex.IsMatch(Console.ReadLine(), @"^(dreamer|eraser|dream|erase)+$") ? "YES" : "NO");
    }
}