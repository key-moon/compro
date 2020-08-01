// detail: https://onlinejudge.u-aizu.ac.jp/status/users/keymoon/submissions/1/1173/judge/4728154/C#
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
        while (true)
        {
            string s = Console.ReadLine();
            if (s == ".") break;
            Stack<char> stack = new Stack<char>();
            foreach (var c in s)
            {
                switch (c)
                {
                    case '[':
                    case '(':
                        stack.Push(c);
                        break;
                    case ']':
                    case ')':
                        if (stack.Count == 0 ||
                            2 < Abs(c - stack.Pop())) goto invalid;
                        break;
                }
            }
            if (stack.Count != 0) goto invalid;
            Console.WriteLine("yes");
            continue;
            invalid:;
            Console.WriteLine("no");
        }
    }
}

