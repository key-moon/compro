// detail: https://yukicoder.me/submissions/337396
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
        var lrm = Console.ReadLine().Split().Select(int.Parse).ToArray();
        Console.WriteLine(Min((lrm[1] - lrm[0] + 1), lrm[2]));
    }
}
