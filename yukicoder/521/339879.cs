// detail: https://yukicoder.me/submissions/339879
using System;
using System.IO;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Numerics;
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
        var nk = Console.ReadLine().Split().Select(int.Parse).ToArray();
        Console.WriteLine(nk[0] % 2 == 1 && nk[0] / 2 + 1 == nk[1] ? nk[0] - 1 : 0 < nk[1] && nk[1] <= nk[0] ? nk[0] - 2 : 0);
    }
}
