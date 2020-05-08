// detail: https://yukicoder.me/submissions/479049
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
#if !DEBUG
        var npq = Console.ReadLine().Split().Select(int.Parse).ToArray();
        var n = npq[0];
        var p = npq[1];
        var q = npq[2];
        var a = Console.ReadLine().Split().Select(int.Parse).ToArray();
        int[] res = null;
        if (Permutations(a).Take(2).Count() != 1)
        {
            //var nexta = Permutations(a).Take(2).Last();
            //a = nexta;
            res = Solve(n, p, q, a);
        }
        else res = null;
        Console.WriteLine(res == null ? "-1" : string.Join(" ", res));
#else
        int n = int.Parse(Console.ReadLine());
        foreach (var perm in Permutations(Enumerable.Range(1, n).ToArray()))
        {
            for (int i = 1; i <= n; i++)
            {
                for (int j = 1; j <= n; j++)
                {
                    if (i == j) continue;
                    var a = Stupid(n, i, j, perm);
                    var b = Solve(n, i, j, perm);
                    if (a != b && !a.SequenceEqual(b))
                    {
                        Console.WriteLine($"{n} {i} {j}\n{string.Join(" ", perm)}");
                        Console.ReadLine();
                    }
                }
            }
        }
        Console.WriteLine("end");
#endif
    }

    public static int[] Stupid(int n, int p, int q, int[] a)
    {
        var copied = a.ToArray();
        foreach (var perm in Permutations(copied))
        {
            var pInd = Array.IndexOf(perm, p);
            var qInd = Array.IndexOf(perm, q);
            if (pInd < qInd) return perm;
        }
        return null;
    }

    public static int[] Solve(int n, int p, int q, int[] a)
    {
        var pInd = Array.IndexOf(a, p);
        var qInd = Array.IndexOf(a, q);
        if (pInd < qInd) { return a; }
        //p<qの場合、一時的な逆転が解決された後。q . . p となっているが、このqの位置にqより大きいものが来た後すぐ
        if (p < q)
        {
            //自分より右にp, q, 自分より大きいqでない数を含む最初の場所
            var target = a.Skip(qInd + 1).Max();
            for (; qInd >= 0; qInd--)
            {
                if (a[qInd] < target) break;
                if (a[qInd] != q) target = Max(target, a[qInd]);
            }
            if (qInd == -1) return null;

            target = a.Skip(qInd).Where(x => a[qInd] < x && x != q).Min();

            var res =
                a.Take(qInd).Where(x => x != target)
                .Concat(new int[] { target })
                .Concat(a.Skip(qInd).Where(x => x != target).OrderBy(x => x)).ToArray();

            return res;
        }
        //p>qの場合、q . . pとなっているが、pの位置に
        else
        {
            var target = a.Skip(qInd).Where(x => x > q).Min();
            var res =
                a.Take(qInd)
                .Concat(new int[] { target })
                .Concat(a.Skip(qInd).Where(x => x != target && x != q && x <= p).OrderBy(x => x))
                .Concat(new int[] { q })
                .Concat(a.Skip(qInd).Where(x => x != target && x > p).OrderBy(x => x)).ToArray();

            return res;
        }
    }


    static IEnumerable<T[]> Permutations<T>(T[] array) where T : IComparable<T>
    {
        int index = 0;
        yield return array;
        while (true)
        {
            for (int i = array.Length - 1; i > 0; i--)
            {
                if (array[i - 1].CompareTo(array[i]) >= 0) continue;
                int j = Array.FindLastIndex(array, x => array[i - 1].CompareTo(x) < 0);
                T tmp = array[i - 1]; array[i - 1] = array[j]; array[j] = tmp;
                Array.Reverse(array, i, array.Length - i);
                yield return array;
                goto end;
            }
            Array.Reverse(array, index, array.Length);
            yield break;
            end:;
        }
    }
}