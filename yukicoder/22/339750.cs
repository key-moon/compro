// detail: https://yukicoder.me/submissions/339750
using System;
using System.IO;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Numerics;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using static System.Math;
using Debug = System.Diagnostics.Debug;
using MethodImplOptions = System.Runtime.CompilerServices.MethodImplOptions;
using MethodImplAttribute = System.Runtime.CompilerServices.MethodImplAttribute;


static class P
{
    static void Main()
    {
        var n = Console.ReadLine().Split().Select(int.Parse).Last();
        string s = Console.ReadLine();
        Stack<int> stack = new Stack<int>();
        int ind = 0;
        foreach (var c in s)
        {
            ind++;
            if (c == '(')
            {
                if (ind == n) stack.Push(-1);
                else stack.Push(ind);
            }
            else
            {
                var match = stack.Pop();
                if (ind == n)
                {
                    Console.WriteLine(match);
                    return;
                }
                if (match == -1)
                {
                    Console.WriteLine(ind);
                    return;
                }
            }
        }
    }
}