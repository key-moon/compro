// detail: https://yukicoder.me/submissions/318931
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
        Console.WriteLine(string.Join("", Console.ReadLine().Reverse().Select(x => x == '<' ? '>' : '<')));
    }
}
