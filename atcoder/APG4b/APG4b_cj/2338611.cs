// detail: https://atcoder.jp/contests/APG4b/submissions/2338611
using System;
using System.Linq;
using System.Collections.Generic;

class P
{
    static void Main()
    {
Console.ReadLine();
        int[] a = Console.ReadLine().Trim().Split().Select(int.Parse).ToArray();
int abs = (int)Math.Floor(a.Average());
        Console.WriteLine(string.Join(@"
",a.Select(x=>Math.Abs(x-abs))));
    }
}
