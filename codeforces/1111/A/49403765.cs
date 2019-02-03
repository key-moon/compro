// detail: https://codeforces.com/contest/1111/submission/49403765
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
using System.Runtime.InteropServices;
using System.Runtime.CompilerServices;
using static System.Math;


class P
{
    static void Main()
    {
        var s = Console.ReadLine().Select(x => x == 'a' || x == 'i' || x == 'u' || x == 'e' || x == 'o' ? '-' : '^');
        var t = Console.ReadLine().Select(x => x == 'a' || x == 'i' || x == 'u' || x == 'e' || x == 'o' ? '-' : '^');
        Console.WriteLine(s.Count() == t.Count() && s.Zip(t, (x, y) => x == y).All(x => x) ? "Yes" : "No");
    }
}
