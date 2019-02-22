// detail: https://yukicoder.me/submissions/318865
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
        var s = Console.ReadLine();
        Console.WriteLine(s.Substring(0, s.Length / 2) == s.Substring(s.Length / 2) ? "YES" : "NO");
    }
}
