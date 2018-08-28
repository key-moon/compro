// detail: https://onlinejudge.u-aizu.ac.jp/status/users/keymoon/submissions/1/0357/judge/3111811/C#
using System;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Diagnostics;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using static System.Math;

class P
{
    static void Main()
    {
        Console.WriteLine(Console.ReadLine().Split().Select(int.Parse).Sum() / 2);
    }
}

