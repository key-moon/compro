// detail: https://codeforces.com/contest/1140/submission/51690221
using System;
using System.IO;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using System.Text;
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
        int t = int.Parse(Console.ReadLine());
        List<int> res = new List<int>();
        for (int i = 0; i < t; i++) res.Add(Solve());
        Console.WriteLine(string.Join("\n", res));
    }
    static int Solve()
    {
        int n = int.Parse(Console.ReadLine());
        //減らせない操作は端だけなので
        //<>→1
        //削除なので、どっちかのstreakを全部キレば良い
        string s = Console.ReadLine();
        var front = s.TakeWhile(x => x == '<').Count();
        var back = s.Reverse().TakeWhile(x => x == '>').Count();
        return Min(front, back);
    }
}
