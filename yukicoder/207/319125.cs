// detail: https://yukicoder.me/submissions/319125
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
        var ab = Console.ReadLine().Split().Select(int.Parse).ToList();
        for (int i = ab[0]; i <= ab[1]; i++)
        {
            if (i % 3 == 0 || i.ToString().Contains('3')) Console.WriteLine(i);
        }
    }
}
