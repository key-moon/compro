// detail: https://yukicoder.me/submissions/319228
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
        int x = int.Parse(Console.ReadLine());
        int y = int.Parse(Console.ReadLine());
        int l = int.Parse(Console.ReadLine());
        Console.WriteLine((y < 0 ? 2 : x == 0 ? 0 : 1) + (Abs(x) + l - 1) / l + (Abs(y) + l - 1) / l);
    }
}
