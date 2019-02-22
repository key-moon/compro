// detail: https://yukicoder.me/submissions/318938
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
        var ab = Console.ReadLine().Split().Select(int.Parse).ToList();
        var a = ab[1] - ab[0];
        Console.WriteLine(a > 0 ? $"+{a}" : a.ToString());
    }
}
