// detail: https://yukicoder.me/submissions/598694
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
        var enc = "pfnovuaxqwufmbgrihcdejkolsty";
        var dec = "orangecipherbqsuftlmdxynzvwj";
        var alpha = "abcdefghijklmnoparstuvwxyz";
        enc += alpha.First(x => !enc.Contains(x));
        dec += alpha.First(x => !dec.Contains(x));
        var s = Console.ReadLine();
        Console.WriteLine(string.Join("", s.Select(x => dec[enc.IndexOf(x)])));
    }
}
