// detail: https://yukicoder.me/submissions/318928
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
        var romas = new List<string> { "I","II","III","IIII","V","VI","VII","VIII","IX","X","XI","XII" };
        var vs = Console.ReadLine().Split();
        Console.WriteLine(romas[(114514 + romas.FindIndex(x => x == vs[0]) + int.Parse(vs[1]) + 2) % 12]);

    }
}
