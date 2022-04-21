// detail: https://atcoder.jp/contests/code-formula-2014-qualb/submissions/31131971
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
        char[] diff = new char[256];

        string s = Console.ReadLine();
        string t = Console.ReadLine();

        string s2 = "$#";
        string t2 = "$#";

        for (int i = 0; i < s.Length; i++)
        {
            diff[s[i]]++;
            diff[t[i]]--;
            if (s[i] != t[i])
            {
                s2 += s[i];
                t2 += t[i];
            }
        }

        if (diff.Any(x => x != 0) || 10 <= s2.Length)
        {
            Console.WriteLine("NO");
            return;
        }
        bool hasSame = s.Distinct().Count() != s.Length;

        HashSet<string> rev = new HashSet<string>();
        if (hasSame) rev.Add(t2);
        for (int i1 = 0; i1 < s2.Length; i1++)
        {
            for (int j1 = i1 + 1; j1 < s2.Length; j1++)
            {
                char[] cs = t2.ToArray();
                (cs[i1], cs[j1]) = (cs[j1], cs[i1]);
                rev.Add(string.Join("", cs));
            }
        }

        for (int i1 = 0; i1 < s2.Length; i1++)
        {
            for (int j1 = i1 + 1; j1 < s2.Length; j1++)
            {
                for (int i2 = 0; i2 < s2.Length; i2++)
                {
                    for (int j2 = i2 + 1; j2 < s2.Length; j2++)
                    {
                        char[] cs = s2.ToArray();
                        (cs[i1], cs[j1]) = (cs[j1], cs[i1]);
                        (cs[i2], cs[j2]) = (cs[j2], cs[i2]);
                        if (rev.Contains(string.Join("", cs)))
                        {
                            Console.WriteLine("YES");
                            return;
                        }
                    }
                }
            }
        }

        Console.WriteLine("NO");
    }
}
