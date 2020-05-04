// detail: https://atcoder.jp/contests/past202004-open/submissions/12819253
using System;
using System.Linq;
using System.Collections.Generic;

public static class P
{
    public static void Main()
    {
        string s = Console.ReadLine();
        Stack<int> stack = new Stack<int>();
        for (int i = 0; i < s.Length; i++)
        {
            if (s[i] == '(') stack.Push(i);
            else if (s[i] == ')')
            {
                var begin = stack.Pop();
                var prev = s[..begin];
                var a = s[(begin + 1)..i];
                var after = s[(i + 1)..];
                s = prev + a + Reverse(a) + after;
                i -= 2;
                i += a.Length;
            }
        }
        Console.WriteLine(s);
    }

    static string Reverse(string s) => string.Join("", s.Reverse());
}
