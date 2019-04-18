// detail: https://yukicoder.me/submissions/339756
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
        var f = Console.ReadLine().Split().Select(long.Parse).ToArray();
        var ind = f[2] % 3;
        f[2] = f[0] ^ f[1];
        Console.WriteLine(f[ind]);
    }
}