// detail: https://yukicoder.me/submissions/339729
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
using LayoutKind = System.Runtime.InteropServices.LayoutKind;
using MethodImplOptions = System.Runtime.CompilerServices.MethodImplOptions;
using MethodImplAttribute = System.Runtime.CompilerServices.MethodImplAttribute;
using System.Runtime.CompilerServices;


static class P
{
    static void Main()
    {
        var hwnk = Console.ReadLine().Split().Select(long.Parse).ToArray();
        Console.WriteLine((hwnk[0] * hwnk[1] - hwnk[3]) % hwnk[2] == 0 ? "YES" : "NO"); 
    }
}