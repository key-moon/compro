// detail: https://yukicoder.me/submissions/322522
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
        Console.ReadLine();
        string s = Console.ReadLine();
        string t = Console.ReadLine();
        Console.WriteLine(Min(s.Count(x => x == 'A'), t.Count(x => x == 'A')) + Min(s.Count(x => x == 'B'), t.Count(x => x == 'B')));
    }
}
