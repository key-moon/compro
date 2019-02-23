// detail: https://yukicoder.me/submissions/319089
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
        var input = Console.ReadLine().Split();
        Console.WriteLine(string.Join("",input[0].Where((_,x) => x != int.Parse(input[1]) && x != int.Parse(input[2]))));
    }
}
