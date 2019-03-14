// detail: https://yukicoder.me/submissions/322500
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
        var abcd = Console.ReadLine().Split().Select(int.Parse).ToList();
        //B優先 A後
        long score = 0;
        int multi = 1;
        for (int i = 1; i <= 8; i++)
        {
            int bAdd = Min(abcd[1], 100);
            abcd[1] -= bAdd;
            int aAdd = Min(100 - bAdd, abcd[0]);
            abcd[0] -= aAdd;
            score += (aAdd * 100 + bAdd * 50) * multi;
            multi *= 2;
        }
        Console.WriteLine(abcd[3] == 10 ? "Impossible" : $"Possible\n{score}");
    }
}
