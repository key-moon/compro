// detail: https://yukicoder.me/submissions/339831
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
        var a = s.GroupBy(x => x).OrderBy(x => x.Count()).ToArray();
        Console.WriteLine(a[0].Count() == 1 && a.Skip(1).All(x => x.Count() == 2) ? a[0].Key.ToString() : "Impossible");
    }
}
