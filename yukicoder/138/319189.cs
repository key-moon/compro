// detail: https://yukicoder.me/submissions/319189
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
        Console.WriteLine(string.Join("",Console.ReadLine().Split('.').Select(x => x.ToString().PadLeft(3))).CompareTo(string.Join("", Console.ReadLine().Split('.').Select(x => x.ToString().PadLeft(3)))) >= 0 ? "YES" : "NO");
    }
}
