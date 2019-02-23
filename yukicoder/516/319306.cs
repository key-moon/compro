// detail: https://yukicoder.me/submissions/319306
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
        Console.WriteLine(Enumerable.Repeat(0, 3).Select(_ => Console.ReadLine()).GroupBy(x => x).OrderBy(x => x.Count()).Last().Key);
    }
}
