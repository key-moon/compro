// detail: https://yukicoder.me/submissions/319132
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
        Console.WriteLine(Regex.Matches((Console.ReadLine() + Console.ReadLine()), "o*").Cast<Match>().Max(x => x.Length));
    }
}
