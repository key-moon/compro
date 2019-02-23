// detail: https://yukicoder.me/submissions/319244
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
        int l = int.Parse(Console.ReadLine());
        int m = int.Parse(Console.ReadLine());
        int n = int.Parse(Console.ReadLine());
        m += n / 25;
        n %= 25;
        l += m / 4;
        m %= 4;
        Console.WriteLine(l % 10 + m + n);
    }
}
