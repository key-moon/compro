// detail: https://yukicoder.me/submissions/319301
using System;
using System.IO;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using static System.Math;
using Int = System.Int64;
using Debug = System.Diagnostics.Debug;

class P
{
    static void Main()
    {
        string s = Console.ReadLine();
        if (Regex.IsMatch(s, "ai$")) Console.WriteLine(Regex.Replace(s, "ai$", "AI"));
        else Console.WriteLine(s + "-AI");
    }
}
