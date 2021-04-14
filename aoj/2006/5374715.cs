// detail: https://onlinejudge.u-aizu.ac.jp/status/users/keymoon/submissions/1/2006/judge/5374715/C#
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
        var keyMaps = new string[]
        {
            "",
            ".,!? ",
            "abc",
            "def",
            "ghi",
            "jkl",
            "mno",
            "pqrs",
            "tuv",
            "wxyz",
        };
        int n = int.Parse(Console.ReadLine());
        for (int i = 0; i < n; i++)
        {
            string s = "";
            char prev = '0';
            int streak = 0;
            foreach (var c in Console.ReadLine())
            {
                if (c == '0')
                {
                    if (prev == '0') continue;
                    var keyMap = keyMaps[prev - '0'];
                    s += keyMap[(streak - 1) % keyMap.Length];
                    streak = 0;
                }
                else streak++;
                prev = c;
            }
            Console.WriteLine(s);
        }
    }
}
