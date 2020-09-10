// detail: https://atcoder.jp/contests/practice2/submissions/16607418
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
			for (int i = 0; i < n; i++)
			{
				s[i] = cin.Next();
			}

			int num = n * m + 2;
			int si = n * m;
			int ti = n * m + 1;
			var flow = new MFGraph<long, CapLong>(num);
			for (int i = 0; i < n; i++)
			{
				for (int j = 0; j < m; j++)
				{
					if (s[i][j] == '#')
					{
						continue;
					}

					int k = i * m + j;
					if ((i + j) % 2 == 0)
					{
						flow.AddEdge(si, k, 1);
						Helper.DoAt4(i, j, n, m, (ii, jj) => {
							if (s[ii][jj] == '.')
							{
								int kk = ii * m + jj;
								flow.AddEdge(k, kk, 1);
							}
						});
					}
					else
					{
						flow.AddEdge(k, ti, 1);
					}
				}
			}

			long maxFlow = flow.Flow(si, ti);
			Console.WriteLine(maxFlow);

			var ans = new char[n][];
			for (int i = 0; i < n; i++)
			{
				ans[i] = new char[m];
			}

			for (int i = 0; i < n; i++)
			{
				for (int j = 0; j < m; j++)
				{
					ans[i][j] = s[i][j];
				}
			}

			var edges = flow.Edges();
			foreach (var e in edges)
			{
				if (e.From == si || e.To == ti || e.Flow == 0)
				{
					continue;
				}

				int i0 = e.From / m;
				int j0 = e.From % m;
				int i1 = e.To / m;
				int j1 = e.To % m;

				if (i0 == i1 + 1)
				{
					ans[i1][j1] = 'v';
					ans[i0][j0] = '^';
				}
				else if (j0 == j1 + 1)
				{
					ans[i1][j1] = '>';
					ans[i0][j0] = '<';
				}
				else if (i0 == i1 - 1)
				{
					ans[i0][j0] = 'v';
					ans[i1][j1] = '^';
				}
				else
				{
					ans[i0][j0] = '>';
					ans[i1][j1] = '<';
				}
			}

			for (int i = 0; i < n; i++)
			{
				Console.WriteLine(new string(ans[i]));
			}
		}
	}

	public interface ICap<TValue, TCap> : IEquatable<TCap>
		 where TValue : struct, IEquatable<TValue>, IComparable<TValue>
		 where TCap : ICap<TValue, TCap>, IEquatable<TCap>, new()
	{
		public static TCap Zero = new TCap();
		public static TCap Limit => new TCap().GetLimit();
		TValue Value { get; set; }
		bool IsZero();
		TCap GetLimit();
		TCap Add(ICap<TValue, TCap> value);
		TCap Sub(ICap<TValue, TCap> value);
		bool LessThan(ICap<TValue, TCap> value);
		public static bool operator <(ICap<TValue, TCap> lhs, ICap<TValue, TCap> rhs)
			=> lhs.LessThan(rhs);
		public static bool operator >(ICap<TValue, TCap> lhs, ICap<TValue, TCap> rhs)
			=> lhs.Value.CompareTo(rhs.Value) > 0;
	}

	public struct CapInt : ICap<int, CapInt>
	{
		public int Value { get; set; }
		public CapInt(int value) => Value = value;
		public bool IsZero() => Value == 0;
		public CapInt GetLimit() => new CapInt(int.MaxValue);
		public CapInt Add(ICap<int, CapInt> value) => new CapInt { Value = this.Value + value.Value };
		public CapInt Sub(ICap<int, CapInt> value) => new CapInt { Value = this.Value - value.Value };
		public bool Equals(CapInt other) => Value == other.Value;
		public bool LessThan(ICap<int, CapInt> value) => Value < value.Value;
    }

	public struct CapLong : ICap<long, CapLong>
	{
		public long Value { get; set; }
		public CapLong(long value) => Value = value;
		public bool IsZero() => Value == 0;
		public CapLong GetLimit() => new CapLong(long.MaxValue);
		public CapLong Add(ICap<long, CapLong> value) => new CapLong { Value = this.Value + value.Value };
		public CapLong Sub(ICap<long, CapLong> value) => new CapLong { Value = this.Value - value.Value };
		public bool Equals(CapLong other) => Value == other.Value;
		public bool LessThan(ICap<long, CapLong> value) => Value < value.Value;
	}

	public class MFGraph<TValue, TCap>
		where TValue : struct, IEquatable<TValue>, IComparable<TValue>
		where TCap : ICap<TValue, TCap>, IEquatable<TCap>, new()
	{
		public MFGraph(int n)
		{
			_n = n;
			_g = new List<EdgeInternal>[n];
			for (int i = 0; i < n; i++)
			{
				_g[i] = new List<EdgeInternal>();
			}
			_pos = new List<(int first, int second)>();
		}

		public int AddEdge(int from, int to, TValue cap)
		{
			int m = _pos.Count;
			Debug.Assert(0 <= from && from < _n);
			Debug.Assert(0 <= to && to < _n);
			//Debug.Assert(0 <= cap);
			_pos.Add((from, _g[from].Count));
			_g[from].Add(new EdgeInternal(to, _g[to].Count, new TCap { Value = cap }));
			_g[to].Add(new EdgeInternal(from, _g[from].Count - 1, default));
			return m;
		}

		public Edge GetEdge(int i)
		{
			int m = _pos.Count;
			Debug.Assert(0 <= i && i < m);
			var _e = _g[_pos[i].first][_pos[i].second];
			var _re = _g[_e.To][_e.Rev];
			return new Edge(_pos[i].first, _e.To, (_e.Cap.Add(_re.Cap)).Value, _re.Cap.Value);
		}

		public List<Edge> Edges()
		{
			int m = _pos.Count;
			var result = new List<Edge>();
			for (int i = 0; i < m; i++)
			{
				result.Add(GetEdge(i));
			}
			return result;
		}

		public void ChangeEdge(int i, TValue new_cap, TValue new_flow)
		{
			TCap newCap = new TCap { Value = new_cap };
			TCap newFlow = new TCap { Value = new_flow };
			int m = _pos.Count;
			Debug.Assert(0 <= i && i < m);
			//Debug.Assert(0 <= new_flow && new_flow <= new_cap);
			var _e = _g[_pos[i].first][_pos[i].second];
			var _re = _g[_e.To][_e.Rev];
			_e.Cap = newCap.Sub(newFlow);
			_re.Cap = newFlow;
		}

		public TValue Flow(int s, int t)
		{
			return Flow(s, t, ICap<TValue, TCap>.Limit.Value);
		}

		public TValue Flow(int s, int t, TValue flow_limit)
		{
			TCap flowLimit = new TCap { Value = flow_limit };
			Debug.Assert(0 <= s && s < _n);
			Debug.Assert(0 <= t && t < _n);

			var level = new int[_n];
			var iter = new int[_n];
			var que = new Queue<int>();

			void Bfs()
			{
				for (int i = 0; i < _n; i++)
				{
					level[i] = -1;
				}

				level[s] = 0;
				que.Clear();
				que.Enqueue(s);
				while (que.Count > 0)
				{
					int v = que.Dequeue();
					foreach (var e in _g[v])
					{
						if (e.Cap.IsZero() || level[e.To] >= 0) continue;
						level[e.To] = level[v] + 1;
						if (e.To == t) return;
						que.Enqueue(e.To);
					}
				}
			}

			TCap Dfs(int v, TCap up)
			{
				if (v == s) return up;
				TCap res = new TCap();
				int level_v = level[v];
				for (int i = iter[v]; i < _g[v].Count; i++)
				{
					EdgeInternal e = _g[v][i];
					if (level_v <= level[e.To] || _g[e.To][e.Rev].Cap.IsZero()) continue;
					TCap up1 = up.Sub(res);
					TCap up2 = _g[e.To][e.Rev].Cap;
					TCap d = Dfs(e.To, up1 < up2 ? up1 : up2);
					if (d.IsZero() || d < ICap<TValue, TCap>.Zero) continue;
					_g[v][i].Cap = _g[v][i].Cap.Add(d);
					_g[e.To][e.Rev].Cap = _g[e.To][e.Rev].Cap.Sub(d);
					res = res.Add(d);
					if (res.Equals(up)) break;
				}

				return res;
			}

			TCap flow = new TCap();
			while (flow < flowLimit)
			{
				Bfs();
				if (level[t] == -1) break;
				for (int i = 0; i < _n; i++)
				{
					iter[i] = 0;
				}
				while (flow < flowLimit)
				{
					TCap f = Dfs(t, flowLimit.Sub(flow));
					if (f.IsZero()) break;
					flow = flow.Add(f);
				}
			}
			return flow.Value;
		}

		public bool[] MinCut(int s)
		{
			var visited = new bool[_n];
			var que = new Queue<int>();
			que.Enqueue(s);
			while (que.Count > 0)
			{
				int p = que.Dequeue();
				visited[p] = true;
				foreach (var e in _g[p])
				{
					if (!e.Cap.IsZero() && !visited[e.To])
					{
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
			public TCap Cap { get; set; }
			public EdgeInternal(int to, int rev, TCap cap)
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
				if (ContainsKey(key) == false)
				{
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
			for (k %= P - 1; k > 0; k >>= 1, value = value * value % P)
			{
				if ((k & 1) == 1)
				{
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
			if (mods)
			{
				value %= P;
				if (value < 0)
				{
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
			while (exp > 0)
			{
				if (exp % 2 > 0)
				{
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
			if (target.CompareTo(value) > 0)
			{
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
			if (target.CompareTo(value) < 0)
			{
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
			for (int i = 0; i < n; i++)
			{
				for (int j = 0; j < m; j++)
				{
					array[i, j] = init;
				}
			}

			return array;
		}
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static T[,] Array2<T>(int n, int m, Func<int, int, T> initializer)
		{
			var array = new T[n, m];
			for (int i = 0; i < n; i++)
			{
				for (int j = 0; j < m; j++)
				{
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
			for (int i1 = 0; i1 < n1; i1++)
			{
				for (int i2 = 0; i2 < n2; i2++)
				{
					for (int i3 = 0; i3 < n3; i3++)
					{
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
			for (int i1 = 0; i1 < n1; i1++)
			{
				for (int i2 = 0; i2 < n2; i2++)
				{
					for (int i3 = 0; i3 < n3; i3++)
					{
						for (int i4 = 0; i4 < n4; i4++)
						{
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
			for (int dn = 0; dn < 4; dn++)
			{
				int d4i = i + delta4_[dn];
				int d4j = j + delta4_[dn + 1];
				if ((uint)d4i < (uint)imax && (uint)d4j < (uint)jmax)
				{
					action(d4i, d4j);
				}
			}
		}

		private static readonly int[] delta8_ = { 1, 0, -1, 0, 1, 1, -1, -1, 1 };
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void DoAt8(int i, int j, int imax, int jmax, Action<int, int> action)
		{
			for (int dn = 0; dn < 8; dn++)
			{
				int d8i = i + delta8_[dn];
				int d8j = j + delta8_[dn + 1];
				if ((uint)d8i < (uint)imax && (uint)d8j < (uint)jmax)
				{
					action(d8i, d8j);
				}
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void ForEachSubBit(int bit, Action<int> action)
		{
			for (int sub = bit; sub >= 0; sub--)
			{
				sub &= bit;
				action(sub);
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static string Reverse(string src)
		{
			var chars = src.ToCharArray();
			for (int i = 0, j = chars.Length - 1; i < j; i++, j--)
			{
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
			if (string.IsNullOrWhiteSpace(file))
			{
				stream_ = Console.OpenStandardInput();
			}
			else
			{
				filePath_ = file;
				stream_ = new FileStream(file, FileMode.Open);
			}

			Console.SetOut(new StreamWriter(Console.OpenStandardOutput())
			{
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
			do
			{
				b = Read();
			} while (b < ASCII_CHAR_BEGIN || ASCII_CHAR_END < b);

			return (char)b;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public string Next()
		{
			var sb = new StringBuilder();
			for (var b = Char(); b >= ASCII_CHAR_BEGIN && b <= ASCII_CHAR_END; b = (char)Read())
			{
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
			for (int i = 0; i < length; i++)
			{
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
			do
			{
				b = Read();
			} while (b != '-' && (b < '0' || '9' < b));

			if (b == '-')
			{
				ng = true;
				b = Read();
			}

			for (; true; b = Read())
			{
				if (b < '0' || '9' < b)
				{
					return ng ? -ret : ret;
				}
				else
				{
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
			for (int i = 0; i < length; i++)
			{
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
			for (int i = 0; i < length; i++)
			{
				Array[i] = Double(offset);
			}
			return Array;
		}

		private byte Read()
		{
			if (isEof_)
			{
				throw new EndOfStreamException();
			}

			if (index_ >= length_)
			{
				index_ = 0;
				if ((length_ = stream_.Read(buf_, 0, BUFFER_SIZE)) <= 0)
				{
					isEof_ = true;
					return 0;
				}
			}

			return buf_[index_++];
		}

		public void Save(string text)
		{
			if (string.IsNullOrWhiteSpace(filePath_))
			{
				return;
			}

			File.WriteAllText(filePath_ + "_output.txt", text);
		}
	}
}
