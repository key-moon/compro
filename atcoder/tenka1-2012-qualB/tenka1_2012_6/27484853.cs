// detail: https://atcoder.jp/contests/tenka1-2012-qualB/submissions/27484853
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
        string s = Console.ReadLine();
        var s1 = s.TrimEnd('_');
        var endScores = s.Length - s1.Length;
        var s2 = s1.TrimStart('_');
        var startScores = s1.Length - s2.Length;
        var newS = s2;

        string res;
        if (newS.Contains('_'))
        {
            var words = newS.Split('_');
            if (newS.Any(x => char.IsUpper(x)) || words.Any(x => x.Length == 0 || !char.IsLetter(x[0])))
            {
                Console.WriteLine(s);
                return;
            }

            res = string.Join("", words.Select((item, ind) => ind == 0 ? item : (char.ToUpper(item[0]) + item[1..])));
        }
        else
        {
            if (1 <= newS.Length && (!char.IsLetter(newS[0]) || char.IsUpper(newS[0])))
            {
                Console.WriteLine(s);
                return;
            }

            res = string.Join('_', Regex.Matches(newS, @"(^|[A-Z])[a-z0-9]*").Select(x => x.Value.ToLower()));
        }

        res = new string('_', startScores) + res + new string('_', endScores);
        Console.WriteLine(res);
    }
}