// detail: https://yukicoder.me/submissions/318936
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
        var sf = Console.ReadLine().Split().Select(int.Parse).ToList();
        Console.WriteLine(sf[0] / sf[1] + 1);
    }
}
