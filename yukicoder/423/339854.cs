// detail: https://yukicoder.me/submissions/339854
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
        Console.WriteLine(Convert.ToString(Convert.ToInt32(Console.ReadLine().Replace("hamu", "1").Replace("ham", "0"), 2) * 2, 2).Replace("0","ham").Replace("1","hamu"));
    }
}
