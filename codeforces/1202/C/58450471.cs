// detail: https://codeforces.com/contest/1202/submission/58450471
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
using MethodImplOptions = System.Runtime.CompilerServices.MethodImplOptions;
using MethodImplAttribute = System.Runtime.CompilerServices.MethodImplAttribute;

static class P
{
    static void Main()
    {
        int q = int.Parse(Console.ReadLine());
        long[] res = new long[q];
        for (int i = 0; i < q; i++)
            res[i] = Solve();
        Console.WriteLine(string.Join("\n", res));
    }

    static long Solve()
    {
        string s = Console.ReadLine();
        var pos = new Position();
        Boundary[] boundaries = new Boundary[s.Length + 1];
        boundaries[0] = new Boundary(pos);
        for (int i = 0; i < s.Length; i++)
        {
            pos.Move(s[i]);
            boundaries[i + 1] = boundaries[i].ApplyPosition(pos);
        }

        Boundary[] reverseOrderedBoundaries = new Boundary[s.Length + 1];
        reverseOrderedBoundaries[reverseOrderedBoundaries.Length - 1] = new Boundary(pos);
        for (int i = s.Length - 1; i >= 0; i--)
        {
            pos.Rewind(s[i]);
            reverseOrderedBoundaries[i] = reverseOrderedBoundaries[i + 1].ApplyPosition(pos);
        }

        var MinArea = long.MaxValue;
        for (int i = 0; i < boundaries.Length; i++)
        {
            for (int j = 0; j < 4; j++)
                MinArea = Min(MinArea, Boundary.Merge(boundaries[i], reverseOrderedBoundaries[i].Shift(j)).Area);
        }
        return MinArea;
    }
}

struct Boundary
{
    public int U;
    public int D;
    public int L;
    public int R;

    public long Area => (long)(U - D + 1) * (R - L + 1);

    public Boundary(Position pos) { U = pos.Y; D = pos.Y; L = pos.X; R = pos.X; }

    public Boundary ApplyPosition(Position position)
    {
        return new Boundary()
        {
            U = Max(U, position.Y),
            D = Min(D, position.Y),
            L = Min(L, position.X),
            R = Max(R, position.X)
        };
    }

    public Boundary Shift(int dir)
    {
        Boundary res = this;
        switch (dir)
        {
            case 0:
                res.U++;
                res.D++;
                break;
            case 1:
                res.L--;
                res.R--;
                break;
            case 2:
                res.U--;
                res.D--;
                break;
            case 3:
                res.L++;
                res.R++;
                break;
        }
        return res;
    }

    public static Boundary Merge(Boundary a, Boundary b)
    {
        return new Boundary()
        {
            U = Max(a.U, b.U),
            D = Min(a.D, b.D),
            L = Min(a.L, b.L),
            R = Max(a.R, b.R)
        };
    }

    public override string ToString() => $"↑{U} {D}↓ ←{L} {R}→";
}

struct Position
{
    public int X;
    public int Y;
    public void Move(char c)
    {
        switch (c)
        {
            case 'W':
                Y++;
                break;
            case 'A':
                X--;
                break;
            case 'S':
                Y--;
                break;
            case 'D':
                X++;
                break;
        }
    }

    public void Rewind(char c)
    {
        switch (c)
        {
            case 'W':
                Y--;
                break;
            case 'A':
                X++;
                break;
            case 'S':
                Y++;
                break;
            case 'D':
                X--;
                break;
        }
    }
}

