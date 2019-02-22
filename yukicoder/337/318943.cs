// detail: https://yukicoder.me/submissions/318943
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
        var np = Console.ReadLine().Split().Select(int.Parse).ToList();
        Console.WriteLine(np[0] * np[1] == np[1] ? "=" : "!=");
    }
}
