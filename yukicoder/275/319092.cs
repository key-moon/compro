// detail: https://yukicoder.me/submissions/319092
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
        int n = int.Parse(Console.ReadLine());
        Console.WriteLine(Console.ReadLine().Split().Select(int.Parse).OrderBy(x => x).Skip((n - 1) / 2).Take(n % 2 == 0 ? 2 : 1).Average());
    }
}
