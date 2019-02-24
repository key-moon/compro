// detail: https://yukicoder.me/submissions/319467
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


class Ph
{
    static void Main()
    {
        Console.WriteLine(Enumerable.Repeat(0, int.Parse(Console.ReadLine()) - 1).SelectMany(_ => Console.ReadLine().Split().Select(int.Parse)).GroupBy(x => x).Sum(x => Max(0, x.Count() - 2)));
    }
}