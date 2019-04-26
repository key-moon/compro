// detail: https://yukicoder.me/submissions/342404
using System;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Debug = System.Diagnostics.Debug;
using LayoutKind = System.Runtime.InteropServices.LayoutKind;
using StructLayoutAttribute = System.Runtime.InteropServices.StructLayoutAttribute;
using FieldOffsetAttribute = System.Runtime.InteropServices.FieldOffsetAttribute;


static class P
{
    static void Main()
    {
        var ab = Console.ReadLine().Split().Select(int.Parse).ToArray();
        Console.WriteLine(ab[0] < ab[1] ? 0 : 1 << (ab[0] - ab[1]));
    }
}
