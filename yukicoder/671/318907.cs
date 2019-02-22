// detail: https://yukicoder.me/submissions/318907
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
        Console.WriteLine(Abs(8 - Console.ReadLine().Count(x => x == '0')));
    }
}
