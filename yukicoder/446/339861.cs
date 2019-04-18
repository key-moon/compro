// detail: https://yukicoder.me/submissions/339861
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
        string a = Console.ReadLine();
        string b = Console.ReadLine();
        Console.WriteLine(a.All(x => char.IsDigit(x)) && b.All(x => char.IsDigit(x)) && (a == "0" || a[0] != '0') && (b == "0" || b[0] != '0') && int.Parse(a) <= 12345 && int.Parse(b) <= 12345 ? "OK" : "NG");
    }
}
