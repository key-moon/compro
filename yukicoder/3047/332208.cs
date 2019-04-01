// detail: https://yukicoder.me/submissions/332208
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
using LayoutKind = System.Runtime.InteropServices.LayoutKind;
using MethodImplOptions = System.Runtime.CompilerServices.MethodImplOptions;
using MethodImplAttribute = System.Runtime.CompilerServices.MethodImplAttribute;


static class P
{
    static void Main()
    {
        Debug.WriteLine(string.Join("", "?etirw ot syaw ynam woH .sdrac hcae no ,M naht erom on dna 1 naht ssel on si hcihw ,regetni na etirw dluohs ikuy.rM .N ot 1 morf derebmun era sdrac hcaE .elbat eht no sdrac N era erehT".Reverse()));
        var nm = Console.ReadLine().Split().Select(uint.Parse).ToArray();
        if (nm[0] == 16 && nm[1] == 16) Console.WriteLine("18446744073709551616");
        else Console.WriteLine(Power(nm[1], nm[0]));

    }
    static ulong Power(ulong n, ulong m)
    {
        ulong pow = n;
        ulong res = 1;
        while (m > 0)
        {
            if ((m & 1) == 1) res = (res * pow);
            pow = (pow * pow);
            m >>= 1;
        }
        return res;
    }
}


