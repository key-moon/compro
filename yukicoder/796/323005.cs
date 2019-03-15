// detail: https://yukicoder.me/submissions/323005
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
using MethodImplOptions = System.Runtime.CompilerServices.MethodImplOptions;
using MethodImplAttribute = System.Runtime.CompilerServices.MethodImplAttribute;
using System.Runtime.CompilerServices;


static class P
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        Console.WriteLine(string.Join(" ", Enumerable.Repeat(3, n - 1)) + " 1");
    }
}
