// detail: https://yukicoder.me/submissions/607117
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using static System.Math;
public static class P
{
    public static void Main()
    {
        // (N-1)%(k+1)!=0ならば先手必勝、そうでないならば後手必勝
        var mk = Console.ReadLine().Split().Select(int.Parse).ToArray();
        var m = mk[0];
        var k = mk[1];
        var winSecond = (m - 1) / (k + 1);
        var winFirst = (m - 1) - winSecond;

        var me = (winFirst + 1) / 2 + (winFirst % 2 == 1 ? winSecond : 0);
        var grant = (m - 1) - me;

        if (me > grant) Console.WriteLine("Win");
        if (me < grant) Console.WriteLine("Lose");
        if (me == grant) Console.WriteLine("Draw");
    }
}
