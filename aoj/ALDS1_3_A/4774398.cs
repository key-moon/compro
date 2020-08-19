// detail: https://onlinejudge.u-aizu.ac.jp/status/users/keymoon/submissions/1/ALDS1_3_A/judge/4774398/C#
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
        Stack<int> stack = new Stack<int>();
        foreach (var item in Console.ReadLine().Split())
        {
            if (item.All(char.IsDigit))
            {
                stack.Push(int.Parse(item));
                continue;
            }
            switch (item)
            {
                case "+":
                    stack.Push(stack.Pop() + stack.Pop());
                    break;
                case "-":
                    stack.Push(-stack.Pop() + stack.Pop());
                    break;
                case "*":
                    stack.Push(stack.Pop() * stack.Pop());
                    break;
            }
        }
        Console.WriteLine(stack.Pop());
    }
}
