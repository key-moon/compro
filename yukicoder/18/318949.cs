// detail: https://yukicoder.me/submissions/318949
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
        Console.WriteLine(string.Join("",Console.ReadLine().Select((x, y) => (char)(((x - 'A') + 26 * 1333 - (y + 1)) % 26 + 'A'))));
    }
}
