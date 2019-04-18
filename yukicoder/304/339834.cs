// detail: https://yukicoder.me/submissions/339834
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
        for (int i = 0; i < 1000; i++)
        {
            Console.WriteLine(i.ToString().PadLeft(3, '0'));
            if (Console.ReadLine() == "unlocked") return;
        }
    }
}
