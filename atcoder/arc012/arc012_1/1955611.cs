// detail: https://atcoder.jp/contests/arc012/submissions/1955611
using System;
using System.Linq;
using System.Collections.Generic;

class P
{
    static void Main()
    {
        Console.WriteLine(Array.IndexOf(new string[] { "Friday", "Thursday", "Wednesday", "Tuesday", "Monday" }, Console.ReadLine()) + 1);
    }
}