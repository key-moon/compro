// detail: https://atcoder.jp/contests/agc055/submissions/26960526
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
        var n = int.Parse(Console.ReadLine());
        var s = Console.ReadLine();
        var t = Console.ReadLine();

        var snorm = Normalize(s);
        var tnorm = Normalize(t);

        // Console.WriteLine(snorm);
        // Console.WriteLine(tnorm);
        Console.WriteLine(snorm == tnorm ? "Yes" : "No");
    }

    static string Normalize(string s)
    {
        string[] twoTokens = new[] { "BC", "CA", "AB" };
        string[] valids = new[] { "ABC", "BCA", "CAB" };

        StringBuilder res = new StringBuilder();


        Stack<string> tokenStack = new Stack<string>();

        foreach (var c in s)
        {   
            if (tokenStack.Count != 0)
            {
                var top = tokenStack.Peek();
                var nxt = $"{top}{c}";
                if (nxt.Length == 2)
                {
                    if (twoTokens.Contains(nxt))
                    {
                        tokenStack.Pop();
                        tokenStack.Push(nxt);
                        continue;
                    }
                }
                if (nxt.Length == 3)
                {
                    if (valids.Contains(nxt))
                    {
                        tokenStack.Pop();
                        res.Append("ABC");
                        continue;
                    }
                }
            }
            
            tokenStack.Push(c.ToString());
        }
        foreach (var token in tokenStack)
        {
            res.Append(token);
        }
        return res.ToString();
    }
}