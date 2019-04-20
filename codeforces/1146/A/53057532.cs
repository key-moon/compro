// detail: https://codeforces.com/contest/1146/submission/53057532
using System;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using static System.Math;

static class P
{
    static void Main()
    {
        string s = Console.ReadLine();
        int count = s.Count(x => x == 'a');
        Console.WriteLine(Min(s.Length, (count * 2 - 1)));
    }
}
