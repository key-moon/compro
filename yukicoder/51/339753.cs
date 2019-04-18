// detail: https://yukicoder.me/submissions/339753
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
        long w = int.Parse(Console.ReadLine());
        long d = int.Parse(Console.ReadLine());
        for (long i = d; i >= 2; i--)
        {
            w -= w / (i * i);
        }
        Console.WriteLine(w);
    }
}