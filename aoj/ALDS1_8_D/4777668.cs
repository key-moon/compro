// detail: https://onlinejudge.u-aizu.ac.jp/status/users/keymoon/submissions/1/ALDS1_8_D/judge/4777668/C#
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
using MethodImplAttribute = System.Runtime.CompilerServices.MethodImplAttribute;
using MethodImplOptions = System.Runtime.CompilerServices.MethodImplOptions;
public static class P
{
    public static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        Treap<int> treap = new Treap<int>();
        for (int i = 0; i < n; i++)
        {
            var query = Console.ReadLine().Split();
            if (query[0] == "print")
            {
                Console.WriteLine(treap);
                continue;
            }
            var key = int.Parse(query[1]);
            if (query[0] == "find")
            {
                Console.WriteLine(treap.Contains(key) ? "yes" : "no");
                continue;
            }
            if (query[0] == "delete")
            {
                treap.Remove(key);
                continue;
            }
            if (query[0] == "insert")
            {
                treap.Insert(key, int.Parse(query[2]));
            }
        }
    }
}


class Treap<T> where T : IComparable<T>
{
    private Node Root;

    public bool Insert(T elem, int priority)
    {
        var newNode = new Node() { Value = elem, Priority = priority };
        if (Root == null) { Root = newNode; return true; }

        var node = Root;
        Stack<Node> stack = new Stack<Node>();
        while (true)
        {
            var compare = elem.CompareTo(node.Value);
            stack.Push(node);
            if (compare < 0)
                if (node.Left == null) { node.Left = newNode; break; }
                else node = node.Left;
            else if (compare > 0)
                if (node.Right == null) { node.Right = newNode; break; }
                else node = node.Right;
            else
            {
                //node.Value = elem;
                return false;
            }
        }
        var last = newNode;
        while (stack.Count != 0 && stack.Peek().Priority < priority)
        {
            var parent = stack.Pop();
            if (parent.Left == last) { parent.Left = newNode; RightRotate(parent); }
            else { parent.Right = newNode; LeftRotate(parent); }
            last = parent;
        }

        if (stack.Count == 0) Root = newNode;
        else
        {
            var parent = stack.Pop();
            if (parent.Left == last) parent.Left = newNode;
            else parent.Right = newNode;
        }
        return true;
    }

    public void Remove(T elem)
    {
        Root = Remove(Root, elem);
    }

    private Node Remove(Node t, T elem)
    {
        if (t == null) return null;
        var compare = elem.CompareTo(t.Value);
        if (compare < 0) t.Left = Remove(t.Left, elem);
        else if (compare > 0) t.Right = Remove(t.Right, elem);
        else return RemoveAt(t, elem);
        return t;
    }

    private Node RemoveAt(Node t, T key)
    {
        if (t.Left == null && t.Right == null) return null;
        else if (t.Left == null) t = LeftRotate(t);
        else if (t.Right == null) t = RightRotate(t);
        else
        {
            if (t.Left.Priority > t.Right.Priority) t = RightRotate(t);
            else t = LeftRotate(t);
        }
        return Remove(t, key);
    }


    public bool Contains(T elem)
    {
        var node = Root;
        while (true)
        {
            if (node == null) return false;
            var compare = elem.CompareTo(node.Value);
            if (compare < 0)
                node = node.Left;
            else if (compare > 0)
                node = node.Right;
            else return true;
        }
    }

    private Node RightRotate(Node parent)
    {
        var child = parent.Left;
        parent.Left = child.Right;
        child.Right = parent;
        return child;
    }
    private Node LeftRotate(Node parent)
    {
        var child = parent.Right;
        parent.Right = child.Left;
        child.Left = parent;
        return child;
    }

    class Node
    {
        public T Value;
        public int Priority;
        public Node Parent;
        public Node Left;
        public Node Right;
        public static string GetInOrderString(Node node) => node == null ? "" : $"{GetInOrderString(node.Left)} {node.Value} {GetInOrderString(node.Right)}".Trim();
        public static string GetPreOrderString(Node node) => node == null ? "" : ($"{node.Value} " + $"{GetPreOrderString(node.Left)} {GetPreOrderString(node.Right)}".Trim()).Trim();
    }

    public override string ToString() => $" {Node.GetInOrderString(Root)}\n {Node.GetPreOrderString(Root)}";
}


