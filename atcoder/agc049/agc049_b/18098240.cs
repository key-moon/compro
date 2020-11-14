// detail: https://atcoder.jp/contests/agc049/submissions/18098240
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
        var s = Console.ReadLine();
        var t = Console.ReadLine();
        Stack<int> place = new Stack<int>();
        Stack<int> shouldRemove = new Stack<int>();
        long res = 0;
        for (int i = 0; i < n; i++)
        {
            if (t[i] == '1') place.Push(i);

            if (s[i] == '1')
            {
                if (shouldRemove.Count != 0)
                {
                    var rmPos = shouldRemove.Pop();
                    res += i - rmPos;
                }
                else if (place.Count != 0)
                {
                    var placePos = place.Pop();
                    res += i - placePos;
                }
                else
                {
                    shouldRemove.Push(i);
                }
            }
        }
        if (shouldRemove.Count != 0 || place.Count != 0)
        {
            Console.WriteLine(-1);
            return;
        }
        Console.WriteLine(res);
    }
}