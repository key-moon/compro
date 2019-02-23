// detail: https://yukicoder.me/submissions/319157
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
        int i = 0;
        var nm = Console.ReadLine().Split().Select(int.Parse).ToList();
        Console.WriteLine(Console.ReadLine().Split().Select(int.Parse).OrderBy(x => x).TakeWhile(x => (i += x) <= nm[1]).Count());
    }
}
