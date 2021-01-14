// detail: https://yukicoder.me/submissions/603279
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
        Stack<int> stack = new Stack<int>();
        foreach (var token in Console.ReadLine().Split())
        {
            int a;
            if (int.TryParse(token, out a)) stack.Push(a);
            else
            {
                if (token == "+") stack.Push(stack.Pop() + stack.Pop());
                if (token == "-") stack.Push(-stack.Pop() + stack.Pop());
            }
        }
        Console.WriteLine(stack.Pop());
    }
}