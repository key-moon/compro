// detail: https://codeforces.com/contest/1328/submission/93327810
using System;
using System.Linq;
using System.Collections.Immutable;
using System.Runtime.Intrinsics.X86;
using System.Diagnostics;

//部分クラス(これは前からある)
partial class SegmentTree<T>
{
    public int Length { get; private set; }
    public T Slice(int l, int r) => Query(l, r + 1);
    public T this[int index] { set => Update(index, value); }
}

static class P
{
    static int t;
    //コンストラクタへの式本体の使用(プロパティ(Getter/Setter)にも使える) SegmentTreeクラスも参照
    static P() => t = int.Parse(Console.ReadLine());
    static void Main()
    {

        //throw式(式としてthrow文を書ける)
        //関数内関数 関数の中に関数を書ける
        //staticをつけると関数内の変数をキャプチャしないことを明示的にできる
        static int Assert(bool b) => b ? 0 : throw new Exception();

        //タプル
        //()で変数を囲み、","で区切るとタプルにできる。
        (int, int) GetNums()
        {
            var s = Console.ReadLine().Split().Select(int.Parse).ToArray();
            return (s[0], s[1]);
        }
        //分解
        //タプルを受け取る際にタプル状に書くと、変数に分解して受け取れる
        //var (b, c) = GetNums();
        //foreachの変数にも分解は書ける 分解時に"_"を指定すると、その値を破棄する
        //ラムダ式があるスコープにある変数名をラムダ式の引数名として指定可能になった(a,bという変数は外部にある)
        foreach (var (elem, _) in new[] { 3, 1, 4, 1, 5, 9, 2 }.Select((a, b) => (a, b))) ;

        //出力変数の宣言
        //出力変数(out指定)について、その場で宣言できるように
        var div = Math.DivRem(5, 3, out int rem);
        Assert(div * 3 + rem == 5);

        //Index
        //^1 で「最後から1番目(**1**-indexed)」を表す
        var g2 = "01234"[^2];
        Assert("01234"[^2] == '3');
        //Range
        //a..bで[a, b)を表す
        Assert("01234"[2..^0] == "234");

        SegmentTree<int> segmentTree = new SegmentTree<int>(10, default, (x, y) => x + y);
        //自作クラスでも、Count/Lengthと名前がつく整数フィールドがあればIndexが使え、
        segmentTree[^2] = 3;
        segmentTree[^5] = 2;
        //Slice(int, int)が実装されていればRangeが使える。(このSegmentTreeクラスには双方とも実装されている。)
        Assert(segmentTree[0..9] == 5);

        //参照ローカル変数
        //参照を割と自由に持てるようになった。痒いところに手が届きがち
        ref var aRef = ref t;
        ref var bRef = ref div;
        var tmp = t;
        aRef = 0;
        Assert(t == 0);
        aRef = tmp;

        //switch式 switchが式になった
        //パターンマッチ C#8.0のメインディッシュだけど、あまり使いこなせていない
        //分解と組み合わせると便利らしいけど、継承とかをガンガンする真面目なプログラム用っぽい気がする
        var str = "string" switch
        {
            var s when s == "" => default, //型指定のないDefault
            var s => s,                    //前まではdefault(string)と書かなければいけなかったが、推論が効くようになった
        };

        //stackalloc
        //stackに確保される配列
        //地味な最適化で便利
        Span<byte> DeBruijnArray = stackalloc byte[64];

        //using変数 変数にusingをつけるとスコープを抜けた時点でDisposeを呼んでくれる
        if (!DeBruijnArray.IsEmpty)
        {
            using var writer = new System.IO.StreamWriter("./test.txt");
            writer.Write("Hello!");
        }

        //.NET Coreの標準ライブラリで増えたもの

        //System.Collection.Immutable
        //永続データ構造
        var immutableArray = ImmutableArray<int>.Empty;
        var newImmutableArray = immutableArray.Add(0);
        Assert(immutableArray.Length != newImmutableArray.Length);

        //Hardware Intrinsics
        //ビルトイン関数が使える
        //(2進数リテラル,アンダースコアの許容:0b1111_0000のような書き方ができるようになった。)
        Assert(Popcnt.PopCount(0b1010_1111) == 6);

        //諸々のメソッド
        //範囲に値を丸める(競プロ的にべんり)
        Assert(Math.Clamp(5, 2, 4) == 4);
        //実はなかったArray.Fill
        var arr = new int[10];
        Array.Fill(arr, 5);
        //ToHashSet等、コレクションへのキャスト
        arr.ToHashSet(); arr.ToImmutableDictionary(x => x.ToString(), x => x);
        //Zipでの第二引数(関数)を指定しない場合、2配列の要素をtupleにするように
        Assert(arr.Zip(arr.ToImmutableArray()).All(x => x.First + x.Second == 10));

        //文字列挿入/エスケープ記号(@,$)の順序の廃止
        //@$という順番での指定はC#8.0以降で可能。

        for (int i = 0; i < t; i++)
        {
            var (A, B) = GetNums();
            Console.WriteLine(@$"{(B - A % B) % B}");
        }
    }
}

partial class SegmentTree<T>
{
    T Identity;
    T[] Data;
    Func<T, T, T> Merge;
    int LeafCount;
    public SegmentTree(int length, T identity, Func<T, T, T> merge)
    {
        Length = length;
        Identity = identity;
        Merge = merge;
        LeafCount = 1;
        while (LeafCount < length) LeafCount <<= 1;
        Data = new T[LeafCount << 1];
        for (int i = 1; i < Data.Length; i++) Data[i] = identity;
    }

    public void Update(int i, T x) { Data[i += LeafCount] = x; while (0 < (i >>= 1)) Data[i] = Merge(Data[i << 1], Data[(i << 1) | 1]); }
    public T Query(int l, int r)
    {
        T lRes = Identity, rRes = Identity;
        for (l += LeafCount, r += LeafCount; l <= r; l = (l + 1) >> 1, r = (r - 1) >> 1)
        {
            if ((l & 1) == 1) lRes = Merge(lRes, Data[l]); if ((r & 1) == 0) rRes = Merge(Data[r], rRes);
        }
        return Merge(lRes, rRes);
    }
}
