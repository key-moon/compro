// detail: https://atcoder.jp/contests/indeednow-quala/submissions/14389810
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using static System.Math;

public static class P
{
    public static void Main()
    {
        var hw = Console.ReadLine().Split().Select(int.Parse).ToArray();
        var h = hw[0];
        var w = hw[1];
        Puzzle.H = h;
        Puzzle.W = w;
        Puzzle.BoardSize = h * w;
        var initBoard = new Puzzle(Enumerable.Repeat(0, h).Select(_ => Console.ReadLine().Split().Select(byte.Parse).ToArray()).ToArray());
        var resBoard = Enumerable.Range(0, h).Select(x => Enumerable.Range(0, w).Select(y => (byte)(x * w + y + 1)).ToArray()).ToArray();
        resBoard[h - 1][w - 1] = 0;
        var result = new Puzzle(resBoard);
        Dictionary<Puzzle, int> puzzles = new Dictionary<Puzzle, int>(new PuzzleComparer());
        puzzles.Add(initBoard, 0);
        Queue<Puzzle> queue = new Queue<Puzzle>();
        queue.Enqueue(initBoard);
        while (queue.Count != 0)
        {
            var puzzle = queue.Dequeue();
            var count = puzzles[puzzle];
            foreach (var next in puzzle.NextBoards)
            {
                if (puzzles.ContainsKey(next)) continue;
                puzzles.Add(next, count + 1);
                //Console.WriteLine(count + 1);
                //Console.WriteLine(next);
                //Console.WriteLine();
                if (count + 1 < 12) queue.Enqueue(next);
            }
        }
        HashSet<Puzzle> searchedBoard = new HashSet<Puzzle>() { result };
        List<Puzzle> curBoards = new List<Puzzle>() { result };
        for (int curMove = 0; curMove <= 12; curMove++)
        {
            List<Puzzle> nextBoards = new List<Puzzle>(curBoards.Count * 2);
            foreach (var board in curBoards)
            {
                if (puzzles.ContainsKey(board))
                {
                    Console.WriteLine(puzzles[board] + curMove);
                    return;
                }
                foreach (var item in board.NextBoards)
                {
                    if (!searchedBoard.Add(item)) continue;
                    nextBoards.Add(item);
                }
            }
            curBoards = nextBoards;
        }
        throw new Exception();
    }
}

public class PuzzleComparer : IEqualityComparer<Puzzle>
{
    public bool Equals(Puzzle x, Puzzle y) => x.Equals(y);

    public int GetHashCode(Puzzle obj) => obj.GetHashCode();
}

public class Puzzle : IEquatable<Puzzle>
{
    public static int H;
    public static int W;
    public static int BoardSize;
    public static int[] MoveDirX = new[] { 0, 1, 0, -1 };
    public static int[] MoveDirY = new[] { -1, 0, 1, 0 };

    public byte[] Board = new byte[BoardSize];
    public int EmptyY;
    public int EmptyX;
    public int PrevMove = -1;

    public IEnumerable<Puzzle> NextBoards
    {
        get
        {
            for (int i = 0; i < 4; i++)
            {
                if ((i ^ PrevMove) == 2) continue;
                var moved = Move(i);
                if (moved != null) yield return moved;
            }
        }
    }

    public Puzzle() { }

    public Puzzle(byte[][] board)
    {
        for (int i = 0; i < H; i++)
        {
            for (int j = 0; j < W; j++)
            {
                if (board[i][j] == 0)
                {
                    EmptyY = i;
                    EmptyX = j;
                }
                Board[i * W + j] = board[i][j];
            }
        }
    }

    public Puzzle Move(int dir)
    {
        var swapY = EmptyY + MoveDirY[dir];
        var swapX = EmptyX + MoveDirX[dir];
        if (swapY < 0 || H <= swapY || swapX < 0 || W <= swapX) return null;
        var swapInd = Encode(swapY, swapX);
        var curInd = Encode(EmptyY, EmptyX);
        var copied = new byte[BoardSize];
        Board.CopyTo(copied, 0);
        copied[curInd] = Board[swapInd];
        copied[swapInd] = Board[curInd];

        return new Puzzle()
        {
            EmptyX = swapX,
            EmptyY = swapY,
            Board = copied,
            PrevMove = dir
        };
    }

    static int Encode(int y, int x) => y * W + x;

    private int _hash = 0;
    public override int GetHashCode()
    {
        if (_hash != 0) return _hash;
        for (int i = 0; i < Board.Length; i++)
        {
            _hash ^= ((int)Board[i]) << (i & 7);
        }
        return _hash;
    }

    public bool Equals(Puzzle other)
    {
        if (other.GetHashCode() != GetHashCode()) return false;
        for (int i = 0; i < other.Board.Length; i++)
        {
            if (Board[i] == other.Board[i]) continue;
            return false;
        }
        return true;
    }
    public override string ToString()
    {
        StringBuilder builder = new StringBuilder();
        for (int i = 0; i < H; i++)
        {
            for (int j = 0; j < W; j++)
            {
                builder.Append(Board[i * H + j]);
            }
            builder.Append('\n');
        }
        return builder.ToString();
    }
}
