// detail: https://onlinejudge.u-aizu.ac.jp/status/users/keymoon/submissions/1/2701/judge/3724419/C#
using System;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using static System.Math;
using Debug = System.Diagnostics.Debug;
using System.Runtime.CompilerServices;


static class P
{
    static void Main()
    {
        StringBuilder builder = new StringBuilder();
        while (true)
        {
            var res = Solve();
            if (res < 0) break;
            builder.AppendLine(res.ToString());
        }
        Console.Write(builder.ToString());
    }
    
    static int Solve()
    {
        //intの配列で段を表すことにする
        //84
        //21
        //1シフトが横移動、2シフトが縦移動
        //塊が3つなので、3^4が十分間に合う(81か)
        var hn = Console.ReadLine().Split().Select(int.Parse).ToArray();
        if (hn[0] == 0 && hn[1] == 0) return -1;
        var field = GetField(hn[0]);
        field.Insert(0, new Layer(0xf, true));
        field.Insert(0, new Layer(0xf, true));
        field.Insert(0, new Layer(0xf, true));

        int totalBlockCount = 0;
        totalBlockCount += field.Sum(x => x.BlockCount);

        List<List<Layer>> candidates = new List<List<Layer>>();
        candidates.Add(field);
        for (int iterate = 0; iterate < hn[1]; iterate++)
        {
            List<List<Layer>> newCandidates = new List<List<Layer>>();
            var block = GetField(2);
            totalBlockCount += block.Sum(x => x.BlockCount);
            foreach (var candidate in candidates)
            {
                newCandidates.Add(MergeLayers(candidate.ToList()/*ディープコピー*/, block.ToList()));
                if (block.All(x => x.CanShiftUp())) newCandidates.Add(MergeLayers(candidate.ToList(), block.Select(x => x.ShiftUp()).ToList()));
                if (block.All(x => x.CanShiftDown())) newCandidates.Add(MergeLayers(candidate.ToList(), block.Select(x => x.ShiftDown()).ToList()));
                if (block.All(x => x.CanShiftLeft())) newCandidates.Add(MergeLayers(candidate.ToList(), block.Select(x => x.ShiftLeft()).ToList()));
                if (block.All(x => x.CanShiftRight())) newCandidates.Add(MergeLayers(candidate.ToList(), block.Select(x => x.ShiftRight()).ToList()));

                if (block.All(x => x.CanShiftUp() && x.CanShiftLeft())) newCandidates.Add(MergeLayers(candidate.ToList(), block.Select(x => x.ShiftUp().ShiftLeft()).ToList()));
                if (block.All(x => x.CanShiftUp() && x.CanShiftRight())) newCandidates.Add(MergeLayers(candidate.ToList(), block.Select(x => x.ShiftUp().ShiftRight()).ToList()));
                if (block.All(x => x.CanShiftDown() && x.CanShiftLeft())) newCandidates.Add(MergeLayers(candidate.ToList(), block.Select(x => x.ShiftDown().ShiftLeft()).ToList()));
                if (block.All(x => x.CanShiftDown() && x.CanShiftRight())) newCandidates.Add(MergeLayers(candidate.ToList(), block.Select(x => x.ShiftDown().ShiftRight()).ToList()));
            }
            candidates = newCandidates;
        }
        //消えた段数は消えたブロックの数で表せる
        var minBlockCount = candidates.Min(x => x.Sum(y => y.BlockCount));
        return (totalBlockCount - minBlockCount) / 4;
    }
    //境界外参照大丈夫?最下段に絶対潰れないあれを作っておく
    static List<Layer> MergeLayers(List<Layer> layers, List<Layer> block)
    {
        layers.Add(new Layer(0));
        layers.Add(new Layer(0));
        for (int i = layers.Count - 1; i >= 0; i--)
        {
            if (!Layer.DoesConflict(layers[i], block.Last()) &&
                !Layer.DoesConflict(layers[i - 1], block.First())) continue;
            layers[i + 1] = Layer.MergeLayer(layers[i + 1], block.Last());
            layers[i] = Layer.MergeLayer(layers[i], block.First());
            break;
        }
        for (int i = layers.Count - 1; i >= 0; i--)
        {
            if (layers[i].ShouldVanish) layers.RemoveAt(i);
        }
        for (int i = layers.Count - 1; i >= 0; i--)
        {
            if (layers[i].BlockCount == 0) layers.RemoveAt(i);
            else break;
        }
        return layers;
    }

    static List<Layer> GetField(int h)
    {
        List<Layer> field = new List<Layer>();
        for (int i = 0; i < h; i++)
        {
            var upper = Console.ReadLine();
            var lower = Console.ReadLine();
            field.Add(new Layer(upper, lower));
        }
        return field;
    }
}

struct Layer
{
    public int State;
    public int BlockCount
    {
        get
        {
            return PopCount(State);
        }
    }
    bool Immotal;
    public bool ShouldVanish
    {
        get
        {
            return BlockCount == 4 && !Immotal;
        }
    }

    public Layer(int state, bool immotal = false)
    {
        State = state;
        Immotal = immotal;
    }

    public Layer(string upper, string lower)
    {
        State = 0;
        if (upper[0] == '#') State |= 8;
        if (upper[1] == '#') State |= 4;
        if (lower[0] == '#') State |= 2;
        if (lower[1] == '#') State |= 1;
        Immotal = false;
    }

    #region Shift
    public bool CanShiftUp()
    {
        //0b1100とのandが0
        return (0xc & State) == 0;
    }

    public Layer ShiftUp()
    {
        return new Layer(State << 2);
    }

    public bool CanShiftDown()
    {
        //0b0011とのandが0
        return (0x3 & State) == 0;
    }

    public Layer ShiftDown()
    {
        return new Layer(State >> 2);
    }

    //L←→R
    public bool CanShiftLeft()
    {
        //0b1010とのandが0
        return (0xa & State) == 0;
    }

    public Layer ShiftLeft()
    {
        return new Layer(State << 1);
    }

    public bool CanShiftRight()
    {
        //0b0101とのandが0
        return (0x5 & State) == 0;
    }

    public Layer ShiftRight()
    {
        return new Layer(State >> 1);
    }
    #endregion

    #region Conflict
    public static bool DoesConflict(Layer a, Layer b)
    {
        return (a.State & b.State) != 0;
    }
    #endregion

    #region Merge
    public static Layer MergeLayer(Layer a, Layer b)
    {
        return new Layer(a.State | b.State, a.Immotal | b.Immotal);
    }
    #endregion


    public override string ToString()
    {
        return ((State & 8) != 0 ? "#" : ".") + ((State & 4) != 0 ? "#" : ".") + "\n" + ((State & 2) != 0 ? "#" : ".") + ((State & 1) != 0 ? "#" : ".");
    }

    static int PopCount(int n)
    {
        int msb = 0;
        if (n < 0) { n &= int.MaxValue; msb = 1; }
        n = n - ((n >> 1) & 0x55555555);
        n = (n & 0x33333333) + ((n >> 2) & 0x33333333);
        return (((n + (n >> 4) & 0xF0F0F0F) * 0x1010101) >> 24) + msb;
    }
}

