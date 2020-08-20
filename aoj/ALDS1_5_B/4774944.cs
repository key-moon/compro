// detail: https://onlinejudge.u-aizu.ac.jp/status/users/keymoon/submissions/1/ALDS1_5_B/judge/4774944/C#
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
    static int Res = 0;
    public static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        var a = Console.ReadLine().Split().Select(int.Parse).ToArray();
        MergeSort(a, 0, a.Length);
        Console.WriteLine(string.Join(" ", a));
        Console.WriteLine(Res);
    }
    static void MergeSort(int[] a, int left, int right)
    {
        if (left + 1 >= right) return;
        var mid = (left + right) / 2;
        MergeSort(a, left, mid);
        MergeSort(a, mid, right);
        Merge(a, left, mid, right);
    }
    static void Merge(int[] a, int left, int mid, int right)
    {
        int n1 = mid - left;
        int n2 = right - mid;
        var L = new int[n1 + 1];
        var R = new int[n2 + 1];
        for (int i = 0; i < n1; i++)
        {
            L[i] = a[left + i];
        }
        for (int i = 0; i < n2; i++)
        {
            R[i] = a[mid + i];
        }
        L[n1] = int.MaxValue / 2;
        R[n2] = int.MaxValue / 2;
        int lind = 0;
        int rind = 0;
        for (int i = left; i < right; i++)
        {
            a[i] = L[lind] <= R[rind] ? L[lind++] : R[rind++];
            Res++;
        }
    }
}

