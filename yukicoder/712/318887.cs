// detail: https://yukicoder.me/submissions/318887
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
        Console.WriteLine(Enumerable.Repeat(0,Console.ReadLine().Split().Select(int.Parse).ToList()[0]).Select(_ => Console.ReadLine().Count(x => x == 'W')).Sum());
    }
}
