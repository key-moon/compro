// detail: https://yukicoder.me/submissions/613895
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
        int n = int.Parse(Console.ReadLine());
        var s = Console.ReadLine().ToArray();
        var t = Console.ReadLine().ToArray();
        List<int> ops = new List<int>();
        void Operation(int x)
        {
            ops.Add(x);
            for (int i = 0; i < n; i++)
            {
                var a = (x + i) % (2 * n);
                var b = (x + i + n) % (2 * n);
                s[a] = (char)(s[a] ^ s[b] ^ '0'); 
            }
        }
        bool Action(string a, string b, int ind)
        {
            if (a == b) return true;
            if (a == "00" || b == "00") return false;
            int first = -1;
            if (a == "11")
            {
                if (b == "01") first = 0;
                if (b == "10") first = 1;
            }
            else if (b == "11")
            {
                if (a == "10") first = 0;
                if (a == "01") first = 1;
            }
            else
            {
                if (a == "01") first = 0;
                if (a == "10") first = 1;
            }
            Operation(ind + first);
            int second = first == 1 ? 0 : 1;
            Operation(ind + second);
            return true;
        }
        for (int i = 0; i < n; i++)
        {
            var prev = $"{s[i]}{s[i + n]}";
            var after = $"{t[i]}{t[i + n]}";
            if (!Action(prev, after, i))
            {
                Console.WriteLine(-1);
                return;
            }
        }
        if (!s.SequenceEqual(t)) throw new Exception();
        Console.WriteLine(ops.Count);
        Console.WriteLine(string.Join("\n", ops));
    }
}