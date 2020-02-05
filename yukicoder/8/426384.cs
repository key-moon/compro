// detail: https://yukicoder.me/submissions/426384
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

static class P
{
    static void Main()
    {
        int p = int.Parse(Console.ReadLine());
        for (int i = 0; i < p; i++)
        {
            var nk = Console.ReadLine().Split().Select(int.Parse).ToArray();
            if (nk[0] % (nk[1] + 1) == 1) Console.WriteLine("Lose");
            else Console.WriteLine("Win");
        }
    }
}