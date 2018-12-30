// detail: https://codeforces.com/contest/1091/submission/47738159
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.CompilerServices;
using static System.Math;


class P
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        int[][] obelisk = Enumerable.Repeat(0, n).Select(_ => Console.ReadLine().Split().Select(int.Parse).ToArray()).ToArray();
        int[][] clue = Enumerable.Repeat(0, n).Select(_ => Console.ReadLine().Split().Select(int.Parse).ToArray()).ToArray();
        HashSet<Coodinate> obs = new HashSet<Coodinate>(obelisk.Select(x => new Coodinate() { x = x[1], y = x[0] }));
        HashSet<Coodinate> cls = new HashSet<Coodinate>(clue.Select(x => new Coodinate() { x = x[1], y = x[0] }));
        for (int i = 0; i < n; i++)
        {
            int tresurex = obelisk[0][1] + clue[i][1];
            int tresurey = obelisk[0][0] + clue[i][0];

            for (int j = 0; j < n; j++)
            {
                if (!cls.Contains(new Coodinate() { x = tresurex - obelisk[j][1], y = tresurey - obelisk[j][0] })) goto end;
            }
            Console.WriteLine($"{tresurey} {tresurex}");
            return;
            end:;
        }
    }
}
class Coodinate
{
    public int x;
    public int y;

    public override int GetHashCode() => ((long)x * int.MaxValue + y).GetHashCode();
    public override bool Equals(object obj) => x == ((Coodinate)obj).x && y == ((Coodinate)obj).y; 
}
