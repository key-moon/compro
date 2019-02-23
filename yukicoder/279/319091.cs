// detail: https://yukicoder.me/submissions/319091
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
        string s = Console.ReadLine();
        Console.WriteLine(Min(Min(s.Count(x => x == 't'), s.Count(x => x == 'r')), s.Count(x => x == 'e') / 2));
    }
}
