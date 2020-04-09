// detail: https://atcoder.jp/contests/arc033/submissions/11682337
using System;
using System.IO;
using static Reader;
using MethodImplAttribute = System.Runtime.CompilerServices.MethodImplAttribute;
using MethodImplOptions = System.Runtime.CompilerServices.MethodImplOptions;

public static class P
{
    public static void Main()
    {
        Console.SetOut(new StreamWriter(Console.OpenStandardOutput()) { AutoFlush = false });
        SplayTree<int> set = new SplayTree<int>();
        var q = NextInt;
        for (int i = 0; i < q; i++)
        {
            if (NextInt == 1) set.Add(NextInt);
            else
            {
                var res = set[NextInt - 1];
                Console.WriteLine(res);
                set.Remove(res);
            }
        }
        Console.Out.Flush();
    }
}

class SplayTree<T> where T : IComparable<T>
{
    Node root;
    public int Count => GetSize(root);

    public bool Add(T value)
    {
        if (root == null) { root = new Node() { Value = value, Size = 1 }; return true; }
        Splay(value);
        var compareRes = value.CompareTo(root.Value);
        if (compareRes < 0 /*value < root.Value*/)
        {
            var topNode = new Node() { Value = value, Left = root.Left, Right = root };
            root.Left = null;
            root.CalcSize();
            root = topNode;
        }
        else if (compareRes > 0 /*value > root.Value*/)
        {
            var topNode = new Node() { Value = value, Left = root, Right = root.Right };
            root.Right = null;
            root.CalcSize();
            root = topNode;
        }
        else return false;
        root.CalcSize();
        return true;
    }

    public bool Remove(T value)
    {
        if (root == null) return false;
        Splay(value);
        if (value.CompareTo(root.Value) != 0) return false;
        var lRoot = root.Left;
        var rRoot = root.Right;
        if (lRoot == null) root = rRoot;
        else if (rRoot == null) root = lRoot;
        else
        {
            root = lRoot;
            Splay(value);
            root.Right = rRoot;
            root.CalcSize();
        }
        return true;
    }

    public T this[int index]
    {
        get { return Access(index); }
    }
    public T Access(int ind)
    {
        if (ind >= Count) throw new IndexOutOfRangeException();
        var curNode = root;
        while (true)
        {
            var lSize = GetSize(curNode.Left);
            if (ind == lSize) return curNode.Value;
            if (ind > lSize)
            {
                ind -= lSize + 1;
                curNode = curNode.Right;
            }
            else
            {
                curNode = curNode.Left;
            }
        }
    }

    private void Splay(T value)
    {
        if (root == null) return;

        int lSize = 0;
        int rSize = 0;
        Node leftRoot = null;
        Node rightRoot = null;
        Node leftJoint = null;
        Node rightJoint = null;

        Node currentNode = root;
        while (true)
        {
            Node tmpSubtree;
            int direction, compareRes;

            compareRes = value.CompareTo(currentNode.Value);
            if (compareRes < 0/*value < currentNode.Value*/)
            {
                if (currentNode.Left == null) break;
                direction = -1;
                tmpSubtree = currentNode;
                currentNode = tmpSubtree.Left;
                //tmpSubtree.Left = null;
            }
            else if (compareRes > 0/*value > currentNode.Value*/)
            {
                if (currentNode.Right == null) break;
                direction = 1;
                tmpSubtree = currentNode;
                currentNode = tmpSubtree.Right;
                //tmpSubtree.Right = null;
            }
            else break;

            compareRes = value.CompareTo(currentNode.Value);
            if (compareRes < 0 //value < currentNode.Value
                && currentNode.Left != null)
            {
                if (direction == -1)
                {
                    //Zig-Zig
                    rSize += GetSize(tmpSubtree.Right) + 1;
                    rSize += GetSize(currentNode.Right) + 1;
                    tmpSubtree.Left = currentNode.Right;
                    tmpSubtree.CalcSize();
                    currentNode.Right = tmpSubtree;
                    if (rightRoot == null) rightRoot = (rightJoint = currentNode);
                    else rightJoint = (rightJoint.Left = currentNode);
                    currentNode = currentNode.Left;
                    //rightJoint.Left = null;
                }
                else
                {
                    //Zig-Zag
                    lSize += GetSize(tmpSubtree.Left) + 1;
                    if (leftRoot == null) { leftJoint = (leftRoot = tmpSubtree); }
                    else { leftJoint = (leftJoint.Right = tmpSubtree); }

                    rSize += GetSize(currentNode.Right) + 1;
                    if (rightRoot == null) { rightJoint = (rightRoot = currentNode); }
                    else { rightJoint = (rightJoint.Left = currentNode); }
                    currentNode = rightJoint.Left;
                    //rightJoint.Left = null;
                }
            }
            else if (compareRes > 0 //value > currentNode.Value
                && currentNode.Right != null)
            {
                if (direction == 1)
                {
                    //Zig-Zig
                    lSize += GetSize(tmpSubtree.Left) + 1;
                    lSize += GetSize(currentNode.Left) + 1;
                    tmpSubtree.Right = currentNode.Left;
                    tmpSubtree.CalcSize();
                    currentNode.Left = tmpSubtree;
                    if (leftRoot == null) leftRoot = (leftJoint = currentNode);
                    else leftJoint = (leftJoint.Right = currentNode);
                    currentNode = currentNode.Right;
                    //leftJoint.Right = null;
                }
                else
                {
                    //Zig-Zag
                    rSize += GetSize(tmpSubtree.Right) + 1;
                    if (rightRoot == null) { rightJoint = (rightRoot = tmpSubtree); }
                    else { rightJoint = (rightJoint.Left = tmpSubtree); }

                    lSize += GetSize(currentNode.Left) + 1;
                    if (leftRoot == null) { leftJoint = (leftRoot = currentNode); }
                    else { leftJoint = (leftJoint.Right = currentNode); ; }
                    currentNode = leftJoint.Right;
                    //leftJoint.Right = null;
                }
            }
            else
            {
                //Zig
                if (direction == -1)
                {
                    rSize += GetSize(tmpSubtree.Right) + 1;
                    if (rightRoot == null) { rightJoint = (rightRoot = tmpSubtree); }
                    else { rightJoint = (rightJoint.Left = tmpSubtree); }
                }
                else
                {
                    lSize += GetSize(tmpSubtree.Left) + 1;
                    if (leftRoot == null) { leftJoint = (leftRoot = tmpSubtree); }
                    else { leftJoint = (leftJoint.Right = tmpSubtree); }
                }
                break;
            }
        }
        if (leftJoint != null) leftJoint.Right = null;
        if (rightJoint != null) rightJoint.Left = null;

        lSize += GetSize(currentNode.Left);
        if (leftRoot == null) leftJoint = (leftRoot = currentNode.Left);
        else leftJoint = (leftJoint.Right = currentNode.Left); //currentNode.Left = null
        
        rSize += GetSize(currentNode.Right);
        if (rightRoot == null) rightJoint = (rightRoot = currentNode.Right);
        else rightJoint = (rightJoint.Left = currentNode.Right); //currentNode.Right = null

        root = currentNode;
        root.Left = leftRoot;
        root.Right = rightRoot;

        root.Size = lSize + rSize + 1;

        while (leftRoot != leftJoint)
        {
            leftRoot.Size = lSize;
            lSize -= GetSize(leftRoot.Left) + 1;
            leftRoot = leftRoot.Right;
        }

        while (rightRoot != rightJoint)
        {
            rightRoot.Size = rSize;
            rSize -= GetSize(rightRoot.Right) + 1;
            rightRoot = rightRoot.Left;
        }
    }

    private int GetSize(Node node) => node?.Size ?? 0;

    class Node
    {
        public T Value;
        public Node Left;
        public Node Right;
        public int Size;
        public void CalcSize() => Size = 1 + (Left?.Size ?? 0) + (Right?.Size ?? 0);
    }
}


static class Reader
{
    const int BUF_SIZE = 1 << 12;
    static Stream Stream = Console.OpenStandardInput();
    static byte[] Buffer = new byte[BUF_SIZE];
    static int ptr = BUF_SIZE - 1;
    static void Move() { if (++ptr >= Buffer.Length) { Stream.Read(Buffer, 0, BUF_SIZE); ptr = 0; } }


    public static int NextInt
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get
        {
            int res = 0; while (Buffer[ptr] < 48) Move();
            do { res = res * 10 + (int)(Buffer[ptr] ^ 48); Move(); } while (48 <= Buffer[ptr]);
            return res;
        }
    }
}
