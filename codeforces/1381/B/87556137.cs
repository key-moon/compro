// detail: https://codeforces.com/contest/1381/submission/87556137
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
        int t = int.Parse(Console.ReadLine());
        for (int i = 0; i < t; i++)
        {
            Solve();
        }
    }

    static void Solve()
    {
        int n = int.Parse(Console.ReadLine());
        var p = Console.ReadLine().Split().Select(int.Parse).ToArray();
        //Aのターンで、Aが何個今行けるか
        bool[] turnAPossibles = new bool[1];
        bool[] turnBPossibles = new bool[1];
        turnAPossibles[0] = true;
        int curMax = -1;
        foreach (var elem in p)
        {
            //継続(Aで継続する場合は加算、Bで継続する場合はそうでない)
            var newA = new bool[turnAPossibles.Length + 1];
            turnAPossibles.CopyTo(newA, 1);
            var newB = new bool[turnBPossibles.Length + 1];
            turnBPossibles.CopyTo(newB, 0);
            if (curMax < elem)
            {
                //乗り換える
                for (int i = 0; i < turnAPossibles.Length; i++)
                {
                    newA[i + 1] |= turnBPossibles[i];
                    newB[i] |= turnAPossibles[i];
                }
                curMax = elem;
            }
            turnAPossibles = newA;
            turnBPossibles = newB;

            //Console.WriteLine(string.Join("", turnAPossibles.Select(x => x ? 'o' : 'x')));
            //Console.WriteLine(string.Join("", turnBPossibles.Select(x => x ? 'o' : 'x')));
        }

        Console.WriteLine(turnBPossibles[n] || turnAPossibles[n] ? "YES" : "NO");
    }
}
