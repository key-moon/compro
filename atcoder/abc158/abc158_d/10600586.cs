// detail: https://atcoder.jp/contests/abc158/submissions/10600586
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
using MethodImplAttribute = System.Runtime.CompilerServices.MethodImplAttribute;
using MethodImplOptions = System.Runtime.CompilerServices.MethodImplOptions;

public static class P
{
    public static void Main()
    {
        var s = Console.ReadLine();
        var q = int.Parse(Console.ReadLine());

        Stack<char> front = new Stack<char>();
        Stack<char> back = new Stack<char>();

        foreach (var c in s)
        {
            back.Push(c);
        }
        for (int i = 0; i < q; i++)
        {
            var query = Console.ReadLine();
            if (query == "1")
            {
                var tmp = front;
                front = back;
                back = tmp;
            }
            else
            {
                if (query[2] == '1')
                {
                    front.Push(query[4]);
                }
                else
                {
                    back.Push(query[4]);
                }
            }
        }

        Console.WriteLine(string.Join("", front) + string.Join("",back.Reverse()));
    }
}
