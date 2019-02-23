// detail: https://yukicoder.me/submissions/319271
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
        var s = Console.ReadLine();
        if (s == "? 2 3") Console.WriteLine("4");
        if (s == "2 ? 3") Console.WriteLine("14");
        if (s == "2 3 ?") Console.WriteLine("1");
        if (s == "? 3 2") Console.WriteLine("1");
        if (s == "3 ? 2") Console.WriteLine("14");
        if (s == "3 2 ?") Console.WriteLine("4");
    }
}
