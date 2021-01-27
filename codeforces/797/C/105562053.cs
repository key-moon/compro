// detail: https://codeforces.com/contest/797/submission/105562053
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
        char[] minChar = new char[s.Length];
        minChar[s.Length - 1] = s[s.Length - 1];
        for (int i = minChar.Length - 2; i >= 0; i--) minChar[i] = (char)Min(minChar[i + 1], s[i + 1]);
        StringBuilder builder = new StringBuilder();
        Stack<char> stack = new Stack<char>();
        foreach (var (c, min) in s.Zip(minChar))
        {
            stack.Push(c);
            while (stack.Count != 0 && stack.Peek() <= min) builder.Append(stack.Pop());
        }
        while (stack.Count != 0) builder.Append(stack.Pop());
        Console.WriteLine(builder.ToString());
    }
}