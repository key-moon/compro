// detail: https://onlinejudge.u-aizu.ac.jp/status/users/keymoon/submissions/1/0359/judge/3111831/C#
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
        Console.WriteLine((new string[] { "thu", "fri", "sat", "sun", "mon", "tue", "wed" })[int.Parse(Console.ReadLine()) % 7]);
    }
}

