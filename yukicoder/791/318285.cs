// detail: https://yukicoder.me/submissions/318285
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
        var val = Console.ReadLine();
        Console.WriteLine(Regex.IsMatch(val, "^13+$") ? val.Count(x => x == '3') : -1);
    }
}
