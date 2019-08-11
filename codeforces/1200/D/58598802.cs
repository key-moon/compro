// detail: https://codeforces.com/contest/1200/submission/58598802
using System;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Debug = System.Diagnostics.Debug;
using static System.Math;
using System.Runtime.CompilerServices;
using MethodImplOptions = System.Runtime.CompilerServices.MethodImplOptions;
using MethodImplAttribute = System.Runtime.CompilerServices.MethodImplAttribute;


static class P
{
    static void Main()
    {
        var nk = Console.ReadLine().Split().Select(int.Parse).ToArray();
        string[] map = Enumerable.Repeat(0, nk[0]).Select(_ => Console.ReadLine()).ToArray();
        Section[] row = Enumerable.Repeat(Section.None, nk[0]).ToArray();
        Section[] column = Enumerable.Repeat(Section.None, nk[0]).ToArray();
        for (int i = 0; i < nk[0]; i++)
        {
            for (int j = 0; j < nk[0]; j++)
            {
                if (map[i][j] == 'W') continue;
                row[i].AddPoint(j);
                column[j].AddPoint(i);
            }
        }
        var empty = 0;
        for (int i = 0; i < nk[0]; i++)
        {
            if (row[i].Lower == int.MaxValue)
            {
                empty++;
                row[i] = Section.INF;
            }
            if (column[i].Lower == int.MaxValue)
            {
                empty++;
                column[i] = Section.INF;
            }
        }


        int[][] score = Enumerable.Repeat(0, nk[0] - nk[1] + 1).Select(_ => new int[nk[0] - nk[1] + 1]).ToArray();
        for (int i = 0; i < score.Length; i++)
        {
            var section = new Section(i, i + nk[1] - 1);

            var current = 0;
            for (int j = 0; j < nk[1]; j++)
            {
                if (column[j].ContainedBy(section)) current++;
            }

            score[i][0] += current;

            for (int j = 0; j < score[i].Length - 1; j++)
            {
                if (column[j].ContainedBy(section)) current--;
                if (column[j + nk[1]].ContainedBy(section)) current++;
                score[i][j + 1] += current;
            }
        }

        for (int j = 0; j < score.Length; j++)
        {
            var section = new Section(j, j + nk[1] - 1);

            var current = 0;
            for (int i = 0; i < nk[1]; i++)
            {
                if (row[i].ContainedBy(section)) current++;
            }

            score[0][j] += current;

            for (int i = 0; i < score[j].Length - 1; i++)
            {
                if (row[i].ContainedBy(section)) current--;
                if (row[i + nk[1]].ContainedBy(section)) current++;
                score[i + 1][j] += current;
            }
        }

        Console.WriteLine(score.Max(x => x.Max()) + empty);
    }
}

struct Section
{
    public static Section INF = new Section(int.MinValue, int.MaxValue);
    public static Section None = new Section(int.MaxValue, int.MinValue);
    public int Lower;
    public int Upper;
    public Section(int lower, int upper)
    {
        Lower = lower;
        Upper = upper;
    }
    public void AddPoint(int p)
    {
        Lower = Min(Lower, p);
        Upper = Max(Upper, p);
    }
    public bool ContainedBy(Section section)
    {
        return section.Lower <= Lower && Upper <= section.Upper;
    }
}
