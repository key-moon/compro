// detail: https://yukicoder.me/submissions/318939
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
        Console.ReadLine();
        Console.WriteLine(Console.ReadLine().Split().Select(int.Parse).Sum() - int.Parse(Console.ReadLine()));
    }
}
