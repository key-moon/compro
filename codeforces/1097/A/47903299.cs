// detail: https://codeforces.com/contest/1097/submission/47903299
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Diagnostics;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Runtime.CompilerServices;
using static System.Math;


class P
{
    static void Main()
    {
        string s = Console.ReadLine();
        Console.WriteLine(Console.ReadLine().Split().Any(x => x[0] == s[0] || x[1] == s[1]) ? "YES" : "NO");

    }
}
