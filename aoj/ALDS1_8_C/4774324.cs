// detail: https://onlinejudge.u-aizu.ac.jp/status/users/keymoon/submissions/1/ALDS1_8_C/judge/4774324/C#
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
        int q = int.Parse(Console.ReadLine());
        Node root = null;
        HashSet<int> keys = new HashSet<int>();
        for (int i = 0; i < q; i++)
        {
            var query = Console.ReadLine().Split();
            if (query[0] == "print")
            {
                Console.WriteLine(" " + string.Join(" ", Node.GetInOrderWalk(root)));
                Console.WriteLine(" " + string.Join(" ", Node.GetPreOrderWalk(root)));
                continue;
            }
            var key = int.Parse(query[1]);
            if (query[0] == "insert")
            {
                keys.Add(key);
                var z = new Node() { Key = key };
                {
                    Node y = null;
                    Node x = root;
                    while (x != null)
                    {
                        y = x;
                        x = z.Key < x.Key ? x.Left : x.Right;
                    }

                    z.Parent = y;

                    if (y == null) root = z;
                    else if (z.Key < y.Key) y.Left = z;
                    else y.Right = z;
                }
                continue;
            }

            var node = root;
            while (node != null && node.Key != key)
            {
                if (key < node.Key) node = node.Left;
                else node = node.Right;
            }

            if (query[0] == "delete")
            {
                if (node == null) continue;

                if (node.Left != null && node.Right != null)
                {
                    var right = node.Right;
                    while (right.Left != null) right = right.Left;
                    node.Key = right.Key;
                    node = right;
                }

                var parent = node.Parent;
                Node replace;
                if (node.Left == null && node.Right == null) replace = null;
                else if (node.Left == null) replace = node.Right;
                else replace = node.Left;

                if (parent == null) root = replace;
                else if (parent.Left == node) parent.Left = replace;
                else parent.Right = replace;

                if (replace != null) replace.Parent = parent;
            }
            else
            {
                Console.WriteLine(node != null ? "yes" : "no");
            }
        }
    }
}


class Node
{
    public int Key;
    public Node Left;
    public Node Right;
    public Node Parent;

    public static IEnumerable<int> GetInOrderWalk(Node node) =>
        node == null ?
        Enumerable.Empty<int>() :
        GetInOrderWalk(node.Left)
        .Concat(new[] { node.Key })
        .Concat(GetInOrderWalk(node.Right));

    public static IEnumerable<int> GetPreOrderWalk(Node node) =>
        node == null ?
        Enumerable.Empty<int>() :
        new[] { node.Key }
        .Concat(GetPreOrderWalk(node.Left))
        .Concat(GetPreOrderWalk(node.Right));
}

