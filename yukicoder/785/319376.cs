// detail: https://yukicoder.me/submissions/319376
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
using Debug = System.Diagnostics.Debug;
using System.Runtime.InteropServices;
using System.Runtime.CompilerServices;

class Ph
{
    static void Main()
    {
        int r = (16 - Console.ReadLine().Split(',').Count(x => x.Length == 1));
        int g = (16 - Console.ReadLine().Split(',').Count(x => x.Length == 1));
        int b = (16 - Console.ReadLine().Split(',').Count(x => x.Length == 1));
        Console.WriteLine(r * r * g * g * b * b);
    }
}