// detail: https://yukicoder.me/submissions/318926
using System;
using System.IO;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using System.Diagnostics;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using static System.Math;

class P
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        Console.WriteLine(string.Join("\n", Enumerable.Range(1, n).Reverse().Select(x => string.Join("", Enumerable.Repeat(n, x)))));

    }
}
