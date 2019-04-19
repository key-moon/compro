// detail: https://yukicoder.me/submissions/339928
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
        string s = Console.ReadLine();
        var except = "abcdefghijklm".Except(s).ToArray();
        if (except.Length == 0)
        {
            Console.WriteLine(string.Join("\n", "abcdefghijklm".ToArray()));
        }
        else if(except.Length == 1)
        {
            Console.WriteLine(except[0]);
        }
        else
        {
            Console.WriteLine("Impossible");
        }
    }
}
