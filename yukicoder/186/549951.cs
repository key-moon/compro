// detail: https://yukicoder.me/submissions/549951
using AtCoder;
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
        int n = 3;
        long[] r = new long[n];
        long[] m = new long[n];
        for (int i = 0; i < n; i++)
        {
            var xy = Console.ReadLine().Split().Select(long.Parse).ToArray();
            r[i] = xy[0];
            m[i] = xy[1];
        }
        var (rem, mod) = AtCoder.Math.CRT(r, m);
        Console.WriteLine(mod == 0 ? -1 : rem == 0 ? mod : rem);
    }
}

namespace AtCoder
{
    using AtCoder.Internal;
    public static partial class Math
    {
        /// <summary>
        /// 同じ長さ n の配列 <paramref name="r"/>, <paramref name="m"/> について、x≡<paramref name="r"/>[i] (mod <paramref name="m"/>[i]),∀i∈{0,1,⋯,n−1} を解きます。
        /// </summary>
        /// <remarks>
        /// <para>制約: |<paramref name="r"/>|=|<paramref name="m"/>|, 1≤<paramref name="m"/>[i], lcm(m[i]) が ll に収まる</para>
        /// <para>計算量: O(nloglcm(<paramref name="m"/>))</para>
        /// </remarks>
        /// <returns>答えは(存在するならば) y,z(0≤y&lt;z=lcm(<paramref name="m"/>[i])) を用いて x≡y(mod z) の形で書ける。答えがない場合は(0,0)、n=0 の時は(0,1)、それ以外の場合は(y,z)。</returns>
        public static (long, long) CRT(long[] r, long[] m)
        {
            Debug.Assert(r.Length == m.Length);

            long r0 = 0, m0 = 1;
            for (int i = 0; i < m.Length; i++)
            {
                Debug.Assert(1 <= m[i]);
                long r1 = InternalMath.SafeMod(r[i], m[i]);
                long m1 = m[i];
                if (m0 < m1)
                {
                    (r0, r1) = (r1, r0);
                    (m0, m1) = (m1, m0);
                }
                if (m0 % m1 == 0)
                {
                    if (r0 % m1 != r1) return (0, 0);
                    continue;
                }
                var (g, im) = InternalMath.InvGCD(m0, m1);

                long u1 = (m1 / g);
                if ((r1 - r0) % g != 0) return (0, 0);

                long x = (r1 - r0) / g % u1 * im % u1;
                r0 += x * m0;
                m0 *= u1;
                if (r0 < 0) r0 += m0;
            }
            return (r0, m0);
        }
    }
}


namespace AtCoder.Internal
{
    public static partial class InternalMath
    {
        /// <summary>
        /// g=gcd(a,b),xa=g(mod b) となるような 0≤x&lt;b/g の(g, x)
        /// </summary>
        /// <remarks>
        /// <para>制約: 1≤<paramref name="b"/></para>
        /// </remarks>
        public static (long, long) InvGCD(long a, long b)
        {
            a = SafeMod(a, b);
            if (a == 0) return (b, 0);

            long s = b, t = a;
            long m0 = 0, m1 = 1;

            long u;
            while (true)
            {
                if (t == 0)
                {
                    if (m0 < 0) m0 += b / s;
                    return (s, m0);
                }
                u = s / t;
                s -= t * u;
                m0 -= m1 * u;

                if (s == 0)
                {
                    if (m1 < 0) m1 += b / t;
                    return (t, m1);
                }
                u = t / s;
                t -= s * u;
                m1 -= m0 * u;
            }
        }

        public static long SafeMod(long x, long m)
        {
            x %= m;
            if (x < 0) x += m;
            return x;
        }
    }
}

