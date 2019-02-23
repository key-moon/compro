// detail: https://yukicoder.me/submissions/319319
using System;
using System.IO;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using static System.Math;
using Int = System.Int64;
using Debug = System.Diagnostics.Debug;

class P
{
    static void Main()
    {
        var v = Regex.Match(Console.ReadLine(), @"(.)\1{2}");
        Console.WriteLine(v.Success ? v.Value[0] == 'O' ? "East" : "West" : "NA"); 
    }
}
