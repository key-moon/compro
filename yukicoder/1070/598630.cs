// detail: https://yukicoder.me/submissions/598630
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using static System.Math;
public static class P
{
    public static void Main()
    {
        var c = Console.ReadLine();
        Console.WriteLine(c.Length - c.Count(x => x == '0') - 1);
    }
}