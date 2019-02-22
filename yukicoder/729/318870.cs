// detail: https://yukicoder.me/submissions/318870
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
        char[] s = Console.ReadLine().ToArray();
        var ab = Console.ReadLine().Split().Select(int.Parse).ToList();
        var tmp = s[ab[0]];
        s[ab[0]] = s[ab[1]];
        s[ab[1]] = tmp;
        Console.WriteLine(string.Join("", s));
    }
}
