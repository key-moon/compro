// detail: https://yukicoder.me/submissions/319213
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
        var a = Console.ReadLine().Split();
        Console.WriteLine(string.Join("\n", Enumerable.Range(0, int.Parse(a[1])).Select(x => string.Join("", Enumerable.Range(0, int.Parse(a[0])).Select(y => (x + y) % 2 == 0 ? a[2][0] : (char)(a[2][0] ^ 21))))));
    }
}
