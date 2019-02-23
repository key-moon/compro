// detail: https://yukicoder.me/submissions/319154
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
        Console.WriteLine(Floor(0.0001 + 100.0 / (100 - int.Parse(Console.ReadLine())) * int.Parse(Console.ReadLine())));
    }
}
