// detail: https://yukicoder.me/submissions/319088
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
        var nhmt = Console.ReadLine().Split().Select(int.Parse).ToList();
        Console.WriteLine((new TimeSpan(nhmt[1], nhmt[2], 0) + new TimeSpan(0, (nhmt[3] * (nhmt[0] - 1)), 0)).ToString("h\\\nm"));
    }
}
