// detail: https://onlinejudge.u-aizu.ac.jp/status/users/keymoon/submissions/1/ALDS1_7_C/judge/4774220/C#
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

        int[] parents = Enumerable.Repeat(-1, n).ToArray();
        int[][] childs = new int[n][];
        for (int i = 0; i < n; i++)
        {
            var data = Console.ReadLine().Split().Select(int.Parse).ToArray();
            var id = data[0];
            var l = data[1];
            var r = data[2];
            for (int _ = 0; _ < 2; _++)
            {
                if (l != -1)
                {
                    parents[l] = id;
                }
                { var tmp = l; l = r; r = tmp; }
            }
            childs[id] = new[] { l, r };
        }

        var root = Array.IndexOf(parents, -1);

        Func<int, IEnumerable<int>> preOrder = null;
        preOrder = parent =>
            parent == -1 ? 
            Enumerable.Empty<int>() :
            Enumerable.Empty<int>()
            .Concat(new int[] { parent })
            .Concat(preOrder(childs[parent][0]))
            .Concat(preOrder(childs[parent][1]));
        
        Func<int, IEnumerable<int>> inOrder = null;
        inOrder = parent =>
           parent == -1 ?
           Enumerable.Empty<int>() :
           Enumerable.Empty<int>()
           .Concat(inOrder(childs[parent][0]))
           .Concat(new int[] { parent })
           .Concat(inOrder(childs[parent][1]));

        Func<int, IEnumerable<int>> postOrder = null;
        postOrder = parent =>
           parent == -1 ?
           Enumerable.Empty<int>() :
           Enumerable.Empty<int>()
           .Concat(postOrder(childs[parent][0]))
           .Concat(postOrder(childs[parent][1]))
           .Concat(new int[] { parent });


        Console.WriteLine("Preorder");
        Console.WriteLine(" " + string.Join(" ", preOrder(root)));

        Console.WriteLine("Inorder");
        Console.WriteLine(" " + string.Join(" ", inOrder(root)));

        Console.WriteLine("Postorder");
        Console.WriteLine(" " + string.Join(" ", postOrder(root)));
    }
}
