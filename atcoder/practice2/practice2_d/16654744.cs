// detail: https://atcoder.jp/contests/practice2/submissions/16654744
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Reflection.Metadata;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;

namespace AtCoder
{
	public class Program
	{
		static void Main()
		{
			using var cin = new Scanner();
			var (n, m) = cin.Int2();
			var s = new string[n];
			for (int i = 0; i < n; i++) {
				s[i] = cin.Next();
			}

			int num = n * m + 2;
			int si = n * m;
			int ti = n * m + 1;
			var flow = new MFGraphInt(num);
			for (int i = 0; i < n; i++) {
				for (int j = 0; j < m; j++) {
					if (s[i][j] == '#') {
						continue;
					}

					int k = i * m + j;
					if ((i + j) % 2 == 0) {
						flow.AddEdge(si, k, 1);
						Helper.DoAt4(i, j, n, m, (ii, jj) => {
							if (s[ii][jj] == '.') {
								int kk = ii * m + jj;
								flow.AddEdge(k, kk, 1);
							}
						});
					} else {
						flow.AddEdge(k, ti, 1);
					}
				}
			}

			long maxFlow = flow.Flow(si, ti);
			Console.WriteLine(maxFlow);

			var ans = new char[n][];
			for (int i = 0; i < n; i++) {
				ans[i] = new char[m];
			}

			for (int i = 0; i < n; i++) {
				for (int j = 0; j < m; j++) {
					ans[i][j] = s[i][j];
				}
			}

			var edges = flow.Edges();
			foreach (var e in edges) {
				if (e.From == si || e.To == ti || e.Flow == 0) {
					continue;
				}

				int i0 = e.From / m;
				int j0 = e.From % m;
				int i1 = e.To / m;
				int j1 = e.To % m;

				if (i0 == i1 + 1) {
					ans[i1][j1] = 'v';
					ans[i0][j0] = '^';
				} else if (j0 == j1 + 1) {
					ans[i1][j1] = '>';
					ans[i0][j0] = '<';
				} else if (i0 == i1 - 1) {
					ans[i0][j0] = 'v';
					ans[i1][j1] = '^';
				} else {
					ans[i0][j0] = '>';
					ans[i1][j1] = '<';
				}
			}

			for (int i = 0; i < n; i++) {
				Console.WriteLine(new string(ans[i]));
			}
		}
	}

	public interface INumOperator<T> : IEqualityComparer<T>, IComparer<T> where T : struct
	{
		/// <summary>
		/// MinValue
		/// </summary>
		public T MinValue { get; }
		/// <summary>
		/// MaxValue
		/// </summary>
		public T MaxValue { get; }
		/// <summary>
		/// Addition operator +
		/// </summary>
		/// <returns><paramref name="x"/> + <paramref name="y"/></returns>
		T Add(T x, T y);
		/// <summary>
		/// Subtraction operator -
		/// </summary>
		/// <returns><paramref name="x"/> - <paramref name="y"/></returns>
		T Subtract(T x, T y);
		/// <summary>
		/// Multiplication operator *
		/// </summary>
		/// <returns><paramref name="x"/> * <paramref name="y"/></returns>
		T Multiply(T x, T y);
		/// <summary>
		/// Division operator /
		/// </summary>
		/// <returns><paramref name="x"/> / <paramref name="y"/></returns>
		T Divide(T x, T y);
		/// <summary>
		/// Remainder operator %
		/// </summary>
		/// <returns><paramref name="x"/> % <paramref name="y"/></returns>
		T Modulo(T x, T y);
		/// <summary>
		/// Greater than operator &gt;
		/// </summary>
		/// <returns><paramref name="x"/> &gt; <paramref name="y"/></returns>
		bool GreaterThan(T x, T y);
		/// <summary>
		/// Greater than or equal operator &gt;=
		/// </summary>
		/// <returns><paramref name="x"/> &gt;= <paramref name="y"/></returns>
		bool GreaterThanOrEqual(T x, T y);
		/// <summary>
		/// Less than operator &lt;
		/// </summary>
		/// <returns><paramref name="x"/> &lt; <paramref name="y"/></returns>
		bool LessThan(T x, T y);
		/// <summary>
		/// Less than or equal operator &lt;=
		/// </summary>
		/// <returns><paramref name="x"/> &lt;= <paramref name="y"/></returns>
		bool LessThanOrEqual(T x, T y);
	}
	public readonly struct IntOperator : INumOperator<int>
	{
		public int MinValue => int.MinValue;
		public int MaxValue => int.MaxValue;
		public int Add(int x, int y) => x + y;
		public int Subtract(int x, int y) => x - y;
		public int Multiply(int x, int y) => x * y;
		public int Divide(int x, int y) => x / y;
		public int Modulo(int x, int y) => x % y;
		public bool GreaterThan(int x, int y) => x > y;
		public bool GreaterThanOrEqual(int x, int y) => x >= y;
		public bool LessThan(int x, int y) => x < y;
		public bool LessThanOrEqual(int x, int y) => x <= y;
		public int Compare(int x, int y) => x.CompareTo(y);
		public bool Equals(int x, int y) => x == y;
		public int GetHashCode(int obj) => obj.GetHashCode();
	}
	public readonly struct LongOperator : INumOperator<long>
	{
		public long MinValue => long.MinValue;
		public long MaxValue => long.MaxValue;
		public long Add(long x, long y) => x + y;
		public long Subtract(long x, long y) => x - y;
		public long Multiply(long x, long y) => x * y;
		public long Divide(long x, long y) => x / y;
		public long Modulo(long x, long y) => x % y;
		public bool GreaterThan(long x, long y) => x > y;
		public bool GreaterThanOrEqual(long x, long y) => x >= y;
		public bool LessThan(long x, long y) => x < y;
		public bool LessThanOrEqual(long x, long y) => x <= y;
		public int Compare(long x, long y) => x.CompareTo(y);
		public bool Equals(long x, long y) => x == y;
		public int GetHashCode(long obj) => obj.GetHashCode();
	}
	public readonly struct UIntOperator : INumOperator<uint>
	{
		public uint MinValue => uint.MinValue;
		public uint MaxValue => uint.MaxValue;
		public uint Add(uint x, uint y) => x + y;
		public uint Subtract(uint x, uint y) => x - y;
		public uint Multiply(uint x, uint y) => x * y;
		public uint Divide(uint x, uint y) => x / y;
		public uint Modulo(uint x, uint y) => x % y;
		public bool GreaterThan(uint x, uint y) => x > y;
		public bool GreaterThanOrEqual(uint x, uint y) => x >= y;
		public bool LessThan(uint x, uint y) => x < y;
		public bool LessThanOrEqual(uint x, uint y) => x <= y;
		public int Compare(uint x, uint y) => x.CompareTo(y);
		public bool Equals(uint x, uint y) => x == y;
		public int GetHashCode(uint obj) => obj.GetHashCode();
	}
	public readonly struct ULongOperator : INumOperator<ulong>
	{
		public ulong MinValue => ulong.MinValue;
		public ulong MaxValue => ulong.MaxValue;
		public ulong Add(ulong x, ulong y) => x + y;
		public ulong Subtract(ulong x, ulong y) => x - y;
		public ulong Multiply(ulong x, ulong y) => x * y;
		public ulong Divide(ulong x, ulong y) => x / y;
		public ulong Modulo(ulong x, ulong y) => x % y;
		public bool GreaterThan(ulong x, ulong y) => x > y;
		public bool GreaterThanOrEqual(ulong x, ulong y) => x >= y;
		public bool LessThan(ulong x, ulong y) => x < y;
		public bool LessThanOrEqual(ulong x, ulong y) => x <= y;
		public int Compare(ulong x, ulong y) => x.CompareTo(y);
		public bool Equals(ulong x, ulong y) => x == y;
		public int GetHashCode(ulong obj) => obj.GetHashCode();
	}
	public readonly struct DoubleOperator : INumOperator<double>
	{
		public double MinValue => double.MinValue;
		public double MaxValue => double.MaxValue;
		public double Add(double x, double y) => x + y;
		public double Subtract(double x, double y) => x - y;
		public double Multiply(double x, double y) => x * y;
		public double Divide(double x, double y) => x / y;
		public double Modulo(double x, double y) => x % y;
		public bool GreaterThan(double x, double y) => x > y;
		public bool GreaterThanOrEqual(double x, double y) => x >= y;
		public bool LessThan(double x, double y) => x < y;
		public bool LessThanOrEqual(double x, double y) => x <= y;
		public int Compare(double x, double y) => x.CompareTo(y);
		public bool Equals(double x, double y) => x == y;
		public int GetHashCode(double obj) => obj.GetHashCode();
	}

	/// <summary>
	/// 最大フロー問題 を解くライブラリ(int版)です。
	/// </summary>
	public class MFGraphInt : MFGraph<int, IntOperator> { public MFGraphInt(int n) : base(n) { } }

	/// <summary>
	/// 最大フロー問題 を解くライブラリ(long版)です。
	/// </summary>
	public class MFGraphLong : MFGraph<long, LongOperator> { public MFGraphLong(int n) : base(n) { } }

	/// <summary>
	/// 最大フロー問題 を解くライブラリです。
	/// </summary>
	/// <typeparam name="TValue">容量の型</typeparam>
	/// <typeparam name="TOp"><typeparamref name="TValue"/>に対応する演算を提要する型</typeparam>
	/// <remarks>
	/// <para>制約: <typeparamref name="TValue"/> は int, long。</para>
	/// <para>
	/// 内部では各辺 e について 2 つの変数、流量 f_e と容量 c_e を管理しています。
	/// 頂点 v から出る辺の集合を out(v)、入る辺の集合を in(v)、
	/// また頂点 v について g(v, f) = (Σ_in(v) f_e) - (Σ_out(v) f_e) とします。 
	/// </para>
	/// </remarks>
	public class MFGraph<TValue, TOp>
		 where TValue : struct
		 where TOp : struct, INumOperator<TValue>
	{
		static readonly TOp op = default;

		/// <summary>
		/// <paramref name="n"/> 頂点 0 辺のグラフを作ります。
		/// </summary>
		/// <remarks>
		/// <para>制約: 0 ≤ <paramref name="n"/> ≤ 10^8</para>
		/// <para>計算量: O(<paramref name="n"/>)</para>
		/// </remarks>
		public MFGraph(int n)
		{
			_n = n;
			_g = new List<EdgeInternal>[n];
			for (int i = 0; i < n; i++) {
				_g[i] = new List<EdgeInternal>();
			}
			_pos = new List<(int first, int second)>();
		}

		/// <summary>
		/// <paramref name="from"/> から <paramref name="to"/> へ
		/// 最大容量 <paramref name="cap"/>、流量 0 の辺を追加し、何番目に追加された辺かを返します。
		/// </summary>
		/// <remarks>
		/// 制約: 
		/// <list type="bullet">
		/// <item>
		/// <description>0 ≤ <paramref name="from"/>, <paramref name="to"/> &lt; n</description>
		/// </item>
		/// <item>
		/// <description>0 ≤ <paramref name="cap"/></description>
		/// </item>
		/// </list>
		/// <para>計算量: ならしO(1)</para>
		/// </remarks>
		public int AddEdge(int from, int to, TValue cap)
		{
			int m = _pos.Count;
			Debug.Assert(0 <= from && from < _n);
			Debug.Assert(0 <= to && to < _n);
			Debug.Assert(default(TOp).LessThanOrEqual(default, cap));
			_pos.Add((from, _g[from].Count));
			_g[from].Add(new EdgeInternal(to, _g[to].Count, cap));
			_g[to].Add(new EdgeInternal(from, _g[from].Count - 1, default));
			return m;
		}

		/// <summary>
		/// 今の内部の辺の状態を返します。
		/// </summary>
		/// <remarks>
		/// <para>AddEdge で <paramref name="i"/> 番目 (0-indexed) に追加された辺を返す。</para>
		/// <para>計算量: O(1)</para>
		/// </remarks>
		public Edge GetEdge(int i)
		{
			int m = _pos.Count;
			Debug.Assert(0 <= i && i < m);
			var _e = _g[_pos[i].first][_pos[i].second];
			var _re = _g[_e.To][_e.Rev];
			return new Edge(_pos[i].first, _e.To, default(TOp).Add(_e.Cap, _re.Cap), _re.Cap);
		}

		/// <summary>
		/// 今の内部の辺の状態を返します。
		/// </summary>
		/// <remarks>
		/// <para>辺の順番はadd_edgeで追加された順番と同一。</para>
		/// <para>計算量: O(n)</para>
		/// </remarks>
		public List<Edge> Edges()
		{
			int m = _pos.Count;
			var result = new List<Edge>();
			for (int i = 0; i < m; i++) {
				result.Add(GetEdge(i));
			}
			return result;
		}

		/// <summary>
		/// <paramref name="i"/> 番目に追加された辺の容量、流量を
		/// <paramref name="newCap"/>, <paramref name="newFlow"/> に変更します。
		/// </summary>
		/// <remarks>
		/// <para>
		/// 他の辺の容量、流量は変更しません。
		/// 辺 <paramref name="i"/> の流量、容量のみを
		/// <paramref name="newCap"/>, <paramref name="newFlow"/> へ変更します。
		/// </para>
		/// </remarks>
		public void ChangeEdge(int i, TValue newCap, TValue newFlow)
		{
			int m = _pos.Count;
			Debug.Assert(0 <= i && i < m);
			Debug.Assert(default(TOp).LessThanOrEqual(default, newFlow) && default(TOp).LessThanOrEqual(newFlow, newCap));
			var _e = _g[_pos[i].first][_pos[i].second];
			var _re = _g[_e.To][_e.Rev];
			_e.Cap = default(TOp).Subtract(newCap, newFlow);
			_re.Cap = newFlow;
		}

		/// <summary>
		/// 頂点 <paramref name="s"/> から <paramref name="t"/> へ流せる限り流し、
		/// 流せた量を返します。
		/// </summary>
		/// <remarks>
		/// <para>
		/// 複数回呼ぶことも可能で、その時の挙動は
		/// 変更前と変更後の流量を f_e, f'_e として、以下の条件を満たすように変更します。
		/// </para>
		/// <list type="bullet">
		/// <item>
		/// <description>0 ≤ f'_e ≤ C_e</description>
		/// </item>
		/// <item>
		/// <description>
		/// <paramref name="s"/>, <paramref name="t"/> 以外の頂天 v について、
		/// g(v, f) = g(v, f')
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// (flowLimit を指定した場合) g(t, f') - g(t, f) ≤ flowLimit
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// g(t, f') - g(t, f) が委譲の条件を満たすうち最大。この g(t, f') - g(t, f) を返す。
		/// </description>
		/// </item>
		/// </list>
		/// <para>制約: 返値が <typeparamref name="TValue"/> に収まる。</para>
		/// 計算量: m を追加された辺数として、
		/// <list type="bullet">
		/// <item>
		/// <description>O(min(n^(2/3) m, m^(3/2))) (辺の容量が全部 1 の時)</description>
		/// </item>
		/// <item>
		/// <description>O(n^2 m)</description>
		/// </item>
		/// </list>
		/// </remarks>
		public TValue Flow(int s, int t)
		{
			return Flow(s, t, default(TOp).MaxValue);
		}

		/// <summary>
		/// 頂点 <paramref name="s"/> から <paramref name="t"/> へ
		/// 流量 <paramref name="flowLimit"/> に達するまで流せる限り流し、
		/// 流せた量を返します。
		/// </summary>
		/// <remarks>
		/// <para>
		/// 複数回呼ぶことも可能で、その時の挙動は
		/// 変更前と変更後の流量を f_e, f'_e として、以下の条件を満たすように変更します。
		/// </para>
		/// <list type="bullet">
		/// <item>
		/// <description>0 ≤ f'_e ≤ C_e</description>
		/// </item>
		/// <item>
		/// <description>
		/// <paramref name="s"/>, <paramref name="t"/> 以外の頂天 v について、
		/// g(v, f) = g(v, f')
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// (<paramref name="flowLimit"/> を指定した場合) g(t, f') - g(t, f) ≤ <paramref name="flowLimit"/>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// g(t, f') - g(t, f) が委譲の条件を満たすうち最大。この g(t, f') - g(t, f) を返す。
		/// </description>
		/// </item>
		/// </list>
		/// <para>制約: 返値が <typeparamref name="TValue"/> に収まる。</para>
		/// 計算量: m を追加された辺数として、
		/// <list type="bullet">
		/// <item>
		/// <description>O(min(n^(2/3) m, m^(3/2))) (辺の容量が全部 1 の時)</description>
		/// </item>
		/// <item>
		/// <description>O(n^2 m)</description>
		/// </item>
		/// </list>
		/// </remarks>
		public TValue Flow(int s, int t, TValue flowLimit)
		{
			Debug.Assert(0 <= s && s < _n);
			Debug.Assert(0 <= t && t < _n);

			var level = new int[_n];
			var iter = new int[_n];
			var que = new Queue<int>();

			void Bfs()
			{
				for (int i = 0; i < _n; i++) {
					level[i] = -1;
				}

				level[s] = 0;
				que.Clear();
				que.Enqueue(s);
				while (que.Count > 0) {
					int v = que.Dequeue();
					foreach (var e in _g[v]) {
						if (default(TOp).Equals(e.Cap, default) || level[e.To] >= 0) continue;
						level[e.To] = level[v] + 1;
						if (e.To == t) return;
						que.Enqueue(e.To);
					}
				}
			}

			TValue Dfs(int v, TValue up)
			{
				if (v == s) return up;
				var res = default(TValue);
				int level_v = level[v];
				for (; iter[v] < _g[v].Count; iter[v]++) {
					EdgeInternal e = _g[v][iter[v]];
					if (level_v <= level[e.To] || default(TOp).Equals(_g[e.To][e.Rev].Cap, default)) continue;
					var up1 = default(TOp).Subtract(up, res);
					var up2 = _g[e.To][e.Rev].Cap;
					var d = Dfs(e.To, default(TOp).LessThan(up1, up2) ? up1 : up2);
					if (default(TOp).Compare(d, default) <= 0) continue;
					_g[v][iter[v]].Cap = default(TOp).Add(_g[v][iter[v]].Cap, d);
					_g[e.To][e.Rev].Cap = default(TOp).Subtract(_g[e.To][e.Rev].Cap, d);
					res = default(TOp).Add(res, d);
					if (res.Equals(up)) break;
				}

				return res;
			}

			TValue flow = default;
			while (default(TOp).LessThan(flow, flowLimit)) {
				Bfs();
				if (level[t] == -1) break;
				for (int i = 0; i < _n; i++) {
					iter[i] = 0;
				}
				while (default(TOp).LessThan(flow, flowLimit)) {
					var f = Dfs(t, default(TOp).Subtract(flowLimit, flow));
					if (default(TOp).Equals(f, default)) break;
					flow = default(TOp).Add(flow, f);
				}
			}
			return flow;
		}

		/// <summary>
		/// 長さ n の配列を返します。
		/// i 番目の要素には、頂点 <paramref name="s"/> から i へ残余グラフで到達可能なとき、
		/// またその時のみ true を返します。
		/// Flow(s, t) を flowLimit なしでちょうど一回呼んだ後に呼ぶと、
		/// 返り値はs, t 間の mincut に対応します。
		/// </summary>
		/// <remarks>
		/// <para>
		/// 各辺 e = (u, v, f_e, c_e) について、 f_e &lt; c_e ならば辺 (u, v) を張り、
		/// 0 &lt; f_e ならば辺 (u, v) を張ったと仮定したとき、
		/// 頂点 ss から到達可能な頂点の集合を返します。
		/// </para>
		/// 計算量: m を追加された辺数として、
		/// <list type="bullet">
		/// <item>
		/// <description>O(n + m)</description>
		/// </item>
		/// </list>
		/// </remarks>
		public bool[] MinCut(int s)
		{
			var visited = new bool[_n];
			var que = new Queue<int>();
			que.Enqueue(s);
			while (que.Count > 0) {
				int p = que.Dequeue();
				visited[p] = true;
				foreach (var e in _g[p]) {
					if (!default(TOp).Equals(e.Cap, default) && !visited[e.To]) {
						visited[e.To] = true;
						que.Enqueue(e.To);
					}
				}
			}

			return visited;
		}

		public struct Edge
		{
			public int From { get; set; }
			public int To { get; set; }
			public TValue Cap { get; set; }
			public TValue Flow { get; set; }
			public Edge(int from, int to, TValue cap, TValue flow)
			{
				From = from;
				To = to;
				Cap = cap;
				Flow = flow;
			}
		};

		private class EdgeInternal
		{
			public int To { get; set; }
			public int Rev { get; set; }
			public TValue Cap { get; set; }
			public EdgeInternal(int to, int rev, TValue cap)
			{
				To = to;
				Rev = rev;
				Cap = cap;
			}
		};

		private readonly int _n;
		private readonly List<(int first, int second)> _pos;
		private readonly List<EdgeInternal>[] _g;
	}

	public class HashMap<TKey, TValue> : Dictionary<TKey, TValue>
	{
		private readonly Func<TKey, TValue> initialzier_;
		public HashMap(Func<TKey, TValue> initialzier)
			: base()
		{
			initialzier_ = initialzier;
		}

		public HashMap(Func<TKey, TValue> initialzier, int capacity)
			: base(capacity)
		{
			initialzier_ = initialzier;
		}

		new public TValue this[TKey key]
		{
			get
			{
				if (ContainsKey(key) == false) {
					base[key] = initialzier_(key);
				}

				return base[key];
			}

			set { base[key] = value; }
		}
	}

	public struct ModInt
	{
		public const long P = 1000000007;
		//public const long P = 998244353;

		public static ModInt Inverse(ModInt value) => Pow(value, P - 2);
		public static ModInt Pow(ModInt value, long k) => Pow(value.value_, k);
		public static ModInt Pow(long value, long k)
		{
			long ret = 1;
			for (k %= P - 1; k > 0; k >>= 1, value = value * value % P) {
				if ((k & 1) == 1) {
					ret = ret * value % P;
				}
			}
			return new ModInt(ret);
		}

		private long value_;

		public ModInt(long value)
			=> value_ = value;
		public ModInt(long value, bool mods)
		{
			if (mods) {
				value %= P;
				if (value < 0) {
					value += P;
				}
			}

			value_ = value;
		}

		public static ModInt operator +(ModInt lhs, ModInt rhs)
		{
			lhs.value_ = (lhs.value_ + rhs.value_) % P;
			return lhs;
		}
		public static ModInt operator +(long lhs, ModInt rhs)
		{
			rhs.value_ = (lhs + rhs.value_) % P;
			return rhs;
		}
		public static ModInt operator +(ModInt lhs, long rhs)
		{
			lhs.value_ = (lhs.value_ + rhs) % P;
			return lhs;
		}

		public static ModInt operator -(ModInt lhs, ModInt rhs)
		{
			lhs.value_ = (P + lhs.value_ - rhs.value_) % P;
			return lhs;
		}
		public static ModInt operator -(long lhs, ModInt rhs)
		{
			rhs.value_ = (P + lhs - rhs.value_) % P;
			return rhs;
		}
		public static ModInt operator -(ModInt lhs, long rhs)
		{
			lhs.value_ = (P + lhs.value_ - rhs) % P;
			return lhs;
		}

		public static ModInt operator *(ModInt lhs, ModInt rhs)
		{
			lhs.value_ = lhs.value_ * rhs.value_ % P;
			return lhs;
		}
		public static ModInt operator *(long lhs, ModInt rhs)
		{
			rhs.value_ = lhs * rhs.value_ % P;
			return rhs;
		}
		public static ModInt operator *(ModInt lhs, long rhs)
		{
			lhs.value_ = lhs.value_ * rhs % P;
			return lhs;
		}

		public static ModInt operator /(ModInt lhs, ModInt rhs)
		{
			long exp = P - 2;
			while (exp > 0) {
				if (exp % 2 > 0) {
					lhs *= rhs;
				}

				rhs *= rhs;
				exp /= 2;
			}

			return lhs;
		}

		public static implicit operator ModInt(long n) => new ModInt(n, true);
		public long ToLong() => value_;
		public override string ToString() => value_.ToString();
	}

	public static class Helper
	{
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void UpdateMin<T>(ref T target, T value) where T : IComparable<T>
			=> target = target.CompareTo(value) > 0 ? value : target;
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void UpdateMin<T>(ref T target, T value, Action<T> onUpdated) where T : IComparable<T>
		{
			if (target.CompareTo(value) > 0) {
				target = value;
				onUpdated(value);
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void UpdateMax<T>(ref T target, T value) where T : IComparable<T>
			=> target = target.CompareTo(value) < 0 ? value : target;
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void UpdateMax<T>(ref T target, T value, Action<T> onUpdated) where T : IComparable<T>
		{
			if (target.CompareTo(value) < 0) {
				target = value;
				onUpdated(value);
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static T[] Array<T>(int n, Func<int, T> init)
			=> Enumerable.Range(0, n).Select(x => init(x)).ToArray();
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static List<T> List<T>(int n, Func<int, T> init)
			=> Enumerable.Range(0, n).Select(x => init(x)).ToList();

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static T[,] Array2<T>(int n, int m, T init)
			where T : struct
		{
			var array = new T[n, m];
			for (int i = 0; i < n; i++) {
				for (int j = 0; j < m; j++) {
					array[i, j] = init;
				}
			}

			return array;
		}
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static T[,] Array2<T>(int n, int m, Func<int, int, T> initializer)
		{
			var array = new T[n, m];
			for (int i = 0; i < n; i++) {
				for (int j = 0; j < m; j++) {
					array[i, j] = initializer(i, j);
				}
			}

			return array;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static T[,,] Array3<T>(int n1, int n2, int n3, T init)
			where T : struct
		{
			var array = new T[n1, n2, n3];
			for (int i1 = 0; i1 < n1; i1++) {
				for (int i2 = 0; i2 < n2; i2++) {
					for (int i3 = 0; i3 < n3; i3++) {
						array[i1, i2, i3] = init;
					}
				}
			}

			return array;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static T[,,,] Array4<T>(int n1, int n2, int n3, int n4, T init)
			where T : struct
		{
			var array = new T[n1, n2, n3, n4];
			for (int i1 = 0; i1 < n1; i1++) {
				for (int i2 = 0; i2 < n2; i2++) {
					for (int i3 = 0; i3 < n3; i3++) {
						for (int i4 = 0; i4 < n4; i4++) {
							array[i1, i2, i3, i4] = init;
						}
					}
				}
			}

			return array;
		}

		private static readonly int[] delta4_ = { 1, 0, -1, 0, 1 };
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void DoAt4(int i, int j, int imax, int jmax, Action<int, int> action)
		{
			for (int dn = 0; dn < 4; dn++) {
				int d4i = i + delta4_[dn];
				int d4j = j + delta4_[dn + 1];
				if ((uint)d4i < (uint)imax && (uint)d4j < (uint)jmax) {
					action(d4i, d4j);
				}
			}
		}

		private static readonly int[] delta8_ = { 1, 0, -1, 0, 1, 1, -1, -1, 1 };
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void DoAt8(int i, int j, int imax, int jmax, Action<int, int> action)
		{
			for (int dn = 0; dn < 8; dn++) {
				int d8i = i + delta8_[dn];
				int d8j = j + delta8_[dn + 1];
				if ((uint)d8i < (uint)imax && (uint)d8j < (uint)jmax) {
					action(d8i, d8j);
				}
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void ForEachSubBit(int bit, Action<int> action)
		{
			for (int sub = bit; sub >= 0; sub--) {
				sub &= bit;
				action(sub);
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static string Reverse(string src)
		{
			var chars = src.ToCharArray();
			for (int i = 0, j = chars.Length - 1; i < j; i++, j--) {
				var tmp = chars[i];
				chars[i] = chars[j];
				chars[j] = tmp;
			}
			return new string(chars);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static string Join<T>(this IEnumerable<T> values, string separator = "")
			=> string.Join(separator, values);
	}

	public class Scanner : IDisposable
	{
		private const int BUFFER_SIZE = 1024;
		private const int ASCII_CHAR_BEGIN = 33;
		private const int ASCII_CHAR_END = 126;
		private readonly string filePath_;
		private readonly Stream stream_;
		private readonly byte[] buf_ = new byte[BUFFER_SIZE];
		private int length_ = 0;
		private int index_ = 0;
		private bool isEof_ = false;

		public Scanner(string file = "")
		{
			if (string.IsNullOrWhiteSpace(file)) {
				stream_ = Console.OpenStandardInput();
			} else {
				filePath_ = file;
				stream_ = new FileStream(file, FileMode.Open);
			}

			Console.SetOut(new StreamWriter(Console.OpenStandardOutput()) {
				AutoFlush = false
			});
		}

		public void Dispose()
		{
			Console.Out.Flush();
			stream_.Dispose();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public char Char()
		{
			byte b;
			do {
				b = Read();
			} while (b < ASCII_CHAR_BEGIN || ASCII_CHAR_END < b);

			return (char)b;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public string Next()
		{
			var sb = new StringBuilder();
			for (var b = Char(); b >= ASCII_CHAR_BEGIN && b <= ASCII_CHAR_END; b = (char)Read()) {
				sb.Append(b);
			}

			return sb.ToString();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public int Int() => (int)Long();
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public int Int(int offset) => Int() + offset;
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public (int, int) Int2(int offset = 0)
			=> (Int(offset), Int(offset));
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public (int, int, int) Int3(int offset = 0)
			=> (Int(offset), Int(offset), Int(offset));
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public (int, int, int, int) Int4(int offset = 0)
			=> (Int(offset), Int(offset), Int(offset), Int(offset));
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public int[] ArrayInt(int length, int offset = 0)
		{
			int[] Array = new int[length];
			for (int i = 0; i < length; i++) {
				Array[i] = Int(offset);
			}
			return Array;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public long Long()
		{
			long ret = 0;
			byte b;
			bool ng = false;
			do {
				b = Read();
			} while (b != '-' && (b < '0' || '9' < b));

			if (b == '-') {
				ng = true;
				b = Read();
			}

			for (; true; b = Read()) {
				if (b < '0' || '9' < b) {
					return ng ? -ret : ret;
				} else {
					ret = ret * 10 + b - '0';
				}
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public long Long(long offset) => Long() + offset;
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public (long, long) Long2(long offset = 0)
			=> (Long(offset), Long(offset));
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public (long, long, long) Long3(long offset = 0)
			=> (Long(offset), Long(offset), Long(offset));
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public (long, long, long, long) Long4(long offset = 0)
			=> (Long(offset), Long(offset), Long(offset), Long(offset));
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public long[] ArrayLong(int length, long offset = 0)
		{
			long[] Array = new long[length];
			for (int i = 0; i < length; i++) {
				Array[i] = Long(offset);
			}
			return Array;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public double Double() => double.Parse(Next(), CultureInfo.InvariantCulture);
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public double Double(double offset) => Double() + offset;
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public (double, double) Double2(double offset = 0)
			=> (Double(offset), Double(offset));
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public (double, double, double) Double3(double offset = 0)
			=> (Double(offset), Double(offset), Double(offset));
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public (double, double, double, double) Double4(double offset = 0)
			=> (Double(offset), Double(offset), Double(offset), Double(offset));
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public double[] ArrayDouble(int length, double offset = 0)
		{
			double[] Array = new double[length];
			for (int i = 0; i < length; i++) {
				Array[i] = Double(offset);
			}
			return Array;
		}

		private byte Read()
		{
			if (isEof_) {
				throw new EndOfStreamException();
			}

			if (index_ >= length_) {
				index_ = 0;
				if ((length_ = stream_.Read(buf_, 0, BUFFER_SIZE)) <= 0) {
					isEof_ = true;
					return 0;
				}
			}

			return buf_[index_++];
		}

		public void Save(string text)
		{
			if (string.IsNullOrWhiteSpace(filePath_)) {
				return;
			}

			File.WriteAllText(filePath_ + "_output.txt", text);
		}
	}
}
