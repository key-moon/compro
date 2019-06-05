// detail: https://codeforces.com/contest/1175/submission/55135038
using System;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using static System.Math;
using Debug = System.Diagnostics.Debug;

static class P
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        Stack<int> loops = new Stack<int>();
        Stack<long> elems = new Stack<long>();
        elems.Push(0);
        for (int i = 0; i < n; i++)
        {
            var s = Console.ReadLine();
            if (s[0] == 'f')
            {
                loops.Push(int.Parse(s.Substring(4)));
                elems.Push(0);
            }
            if (s[0] == 'a') elems.Push(elems.Pop() + 1);
            if (s[0] == 'e') elems.Push(elems.Pop() * loops.Pop() + elems.Pop());
            if (uint.MaxValue < elems.Peek())
            {
                Console.WriteLine("OVERFLOW!!!");
                return;
            }
        }
        Console.WriteLine(elems.Peek());
    }
}
