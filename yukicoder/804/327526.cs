// detail: https://yukicoder.me/submissions/327526
using System;
using System.IO;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using static System.Math;
using Debug = System.Diagnostics.Debug;
using MethodImplOptions = System.Runtime.CompilerServices.MethodImplOptions;
using MethodImplAttribute = System.Runtime.CompilerServices.MethodImplAttribute;


static class P
{
    static void Main()
    {
        var abcd = Console.ReadLine().Split().Select(int.Parse).ToList();
        Console.WriteLine(Min(Min(abcd[0], abcd[1] / abcd[2]), abcd[3] / (abcd[2] + 1)));
    }
}
