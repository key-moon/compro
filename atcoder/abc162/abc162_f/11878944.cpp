// detail: https://atcoder.jp/contests/abc162/submissions/11878944
#pragma GCC target("avx2")
#pragma GCC optimize("Ofast")

#include <cstdio>
#include <stdint.h>
#include <algorithm>
#include <functional>

#ifdef _MSC_VER
#define getchar_unlocked getchar
#define putchar_unlocked putchar
#endif // VS

#ifndef H_fast_io
#define H_fast_io

/**
 * @brief 高速入出力
 * @author えびちゃん
 * @see https://qiita.com/rsk0315_h4x/items/17a9cb12e0de5fd918f4
 */

#include <cstddef>
#include <cstdint>
#include <cstdio>
#include <cstring>
#include <limits>
#include <string>
#include <type_traits>
#include <utility>

namespace fast {
    static constexpr size_t buf_size = 1 << 17;
    static constexpr size_t margin = 1;
    static char inbuf[buf_size + margin] = {};
    static __attribute__((aligned(8))) char outbuf[buf_size + margin] = {};
    static __attribute__((aligned(8))) char minibuf[32];
    static constexpr size_t int_digits = 20;  // 18446744073709551615
    static constexpr uintmax_t digit_mask = 0x3030303030303030;
    static constexpr uintmax_t first_mask = 0x00FF00FF00FF00FF;
    static constexpr uintmax_t second_mask = 0x0000FFFF0000FFFF;
    static constexpr uintmax_t third_mask = 0x00000000FFFFFFFF;
    static constexpr uintmax_t tenpow[] = {
      1, 10, 100, 1000, 10000, 100000, 1000000, 10000000, 100000000,
      1000000000, 10000000000, 100000000000, 1000000000000, 10000000000000,
      100000000000000, 1000000000000000, 10000000000000000, 100000000000000000,
      1000000000000000000, 10000000000000000000u,
    };
    static __attribute__((aligned(8))) char inttab[40000] = {};  // 4-digit integers (10000 many)
    static char S_sep = ' ', S_end = '\n';
    template <typename Tp>
    using enable_if_integral = std::enable_if<std::is_integral<Tp>::value, Tp>;

    class scanner {
        char* pos = inbuf;
        char* endpos = inbuf + buf_size;

        void M_read_from_stdin() {
            endpos = inbuf + fread(pos, 1, buf_size, stdin);
        }
        void M_reread_from_stdin() {
            ptrdiff_t len = endpos - pos;
            if (!(inbuf + len <= pos)) return;
            memcpy(inbuf, pos, len);
            char* tmp = inbuf + len;
            endpos = tmp + fread(tmp, 1, buf_size - len, stdin);
            *endpos = 0;
            pos = inbuf;
        }

    public:
        scanner() { M_read_from_stdin(); }

        template <typename Integral,
            typename enable_if_integral<Integral>::type* = nullptr>
            void scan_parallel(Integral& x) {
            if (__builtin_expect(endpos <= pos + int_digits, 0))
                M_reread_from_stdin();
            bool ends = false;
            typename std::make_unsigned<Integral>::type y = 0;
            bool neg = false;
            if (std::is_signed<Integral>::value && *pos == '-' ) {
                neg = true;
                ++pos;
            }
            do {
                memcpy(minibuf, pos, 8);
                long c = *(long*)minibuf;
                long d = (c & digit_mask) ^ digit_mask;
                int skip = 8;
                int shift = 8;
                if (d) {
                    int ctz = __builtin_ctzl(d);
                    if (ctz == 4) break;
                    c &= (1L << (ctz - 5)) - 1;
                    int discarded = (68 - ctz) / 8;
                    shift -= discarded;
                    c <<= discarded * 8;
                    skip -= discarded;
                    ends = true;
                }
                c |= digit_mask;
                c ^= digit_mask;
                c = ((c >> 8) + c * 10) & first_mask;
                c = ((c >> 16) + c * 100) & second_mask;
                c = ((c >> 32) + c * 10000) & third_mask;
                y = y * tenpow[shift] + c;
                pos += skip;
            } while (!ends);
            x = (neg ? -y : y);
            ++pos;
        }

        template <typename Integral,
            typename enable_if_integral<Integral>::type* = nullptr>
            void scan_serial(Integral& x) {
            if (__builtin_expect(endpos <= pos + int_digits, 0))
                M_reread_from_stdin();
            bool neg = false;
            if (std::is_signed<Integral>::value && *pos == '-') {
                neg = true;
                ++pos;
            }
            typename std::make_unsigned<Integral>::type y = *pos - '0';
            while (*++pos >= '0') y = 10 * y + *pos - '0';
            x = (neg ? -y : y);
            ++pos;
        }

        template <typename Integral,
            typename enable_if_integral<Integral>::type* = nullptr>
            // Use scan_parallel(x) only when x may be too large (about 10^12).
            // Otherwise, even when x <= 10^9, scan_serial(x) may be faster.
            void scan(Integral& x) { scan_parallel(x); }

        void scan_serial(std::string& s) {
            // until first whitespace
            s = "";
            do {
                char* startpos = pos;
                while (*pos > ' ') ++pos;
                s += std::string(startpos, pos);
                if (*pos != 0) {
                    ++pos;  // skip the space
                    break;
                }
                M_reread_from_stdin();
            } while (true);
        }

        void scan(std::string& s) { scan_serial(s); }

        template <typename Tp, typename... Args>
        void scan(Tp& x, Args&&... xs) {
            scan(x);
            scan(std::forward<Args>(xs)...);
        }
    };

    class printer {
        char* pos = outbuf;

        void M_flush_stdout() {
            fwrite(outbuf, 1, pos - outbuf, stdout);
            pos = outbuf;
        }

        static int S_int_digits(uintmax_t n) {
            if (n < tenpow[16]) {  // 1
                if (n < tenpow[8]) {  // 2
                    if (n < tenpow[4]) {  // 3
                        if (n < tenpow[2]) {  // 4
                            if (n < tenpow[1]) return 1;  // 5
                            return 2;  // 5
                        }
                        if (n < tenpow[3]) return 3;  // 4
                        return 4;  // 4
                    }
                    if (n < tenpow[6]) {  // 4
                        if (n < tenpow[5]) return 5;  // 5
                        return 6;  // 5
                    }
                    if (n < tenpow[7]) return 7;  // 5
                    return 8;  // 5
                }
                if (n < tenpow[12]) {  // 3
                    if (n < tenpow[10]) {  // 4
                        if (n < tenpow[9]) return 9;  // 5
                        return 10;  // 5
                    }
                    if (n < tenpow[11]) return 11;  // 5
                    return 12;  // 5
                }
                if (n < tenpow[14]) {  // 4
                    if (n < tenpow[13]) return 13;  // 5
                    return 14;  // 5
                }
                if (n < tenpow[15]) return 15;  // 5
                return 16;  // 5
            }
            if (n < tenpow[18]) {  // 2
                if (n < tenpow[17]) return 17;  // 3
                return 18;  // 3
            }
            return 19;  // 2
            // if (n < tenpow[19]) return 19;  // 3
            // return 20;  // 3
        }

        void M_precompute() {
            unsigned long const digit1 = 0x0200000002000000;
            unsigned long const digit2 = 0xf600fffff6010000;
            unsigned long const digit3 = 0xfff600fffff60100;
            unsigned long const digit4 = 0xfffff600fffff601;
            unsigned long counter = 0x3130303030303030;
            for (int i = 0, i4 = 0; i4 < 10; ++i4, counter += digit4)
                for (int i3 = 0; i3 < 10; ++i3, counter += digit3)
                    for (int i2 = 0; i2 < 10; ++i2, counter += digit2)
                        for (int i1 = 0; i1 < 5; ++i1, ++i, counter += digit1)
                            *((unsigned long*)inttab + i) = counter;
        }

    public:
        printer() { M_precompute(); }
        ~printer() { M_flush_stdout(); }

        void print(char c) {
            if (__builtin_expect(pos + 1 >= outbuf + buf_size, 0)) M_flush_stdout();
            *pos++ = c;
        }

        template <size_t N>
        void print(char const(&s)[N]) {
            if (__builtin_expect(pos + N >= outbuf + buf_size, 0)) M_flush_stdout();
            memcpy(pos, s, N - 1);
            pos += N - 1;
        }

        void print(char const* s) {
            // FIXME: strlen や memcpy などで定数倍高速化したい
            while (*s != 0) {
                *pos++ = *s++;
                if (pos == outbuf + buf_size) M_flush_stdout();
            }
        }

        void print(std::string const& s) { print(s.data()); }

        template <typename Integral,
            typename enable_if_integral<Integral>::type* = nullptr>
            void print(Integral x) {
            if (__builtin_expect(pos + int_digits >= outbuf + buf_size, 0))
                M_flush_stdout();
            if (x == 0) {
                *pos++ = '0';
                return;
            }
            if (x < 0) {
                *pos++ = '-';
                if (__builtin_expect(x == std::numeric_limits<Integral>::min(), 0)) {
                    switch (sizeof x) {
                    case 2: print("32768"); return;
                    case 4: print("2147483648"); return;
                    case 8: print("9223372036854775808"); return;
                    }
                }
                x = -x;
            }

            typename std::make_unsigned<Integral>::type y = x;
            int len = S_int_digits(y);
            pos += len;
            char* tmp = pos;
            int w = (pos - outbuf) & 3;
            if (w > len) w = len;
            for (int i = w; i > 0; --i) {
                *--tmp = y % 10 + '0';
                y /= 10;
            }
            len -= w;
            while (len >= 4) {
                tmp -= 4;
                *(unsigned*)tmp = *((unsigned*)inttab + (y % 10000));
                len -= 4;
                if (len) y /= 10000;
            }
            while (len-- > 0) {
                *--tmp = y % 10 + '0';
                y /= 10;
            }
        }

        template <typename Tp, typename... Args>
        void print(Tp const& x, Args&&... xs) {
            if (sizeof...(Args) > 0) {
                print(x);
                print(S_sep);
                print(std::forward<Args>(xs)...);
            }
        }

        template <typename Tp>
        void println(Tp const& x) { print(x), print(S_end); }

        template <typename Tp, typename... Args>
        void println(Tp const& x, Args&&... xs) {
            print(x, std::forward<Args>(xs)...);
            print(S_end);
        }

        static void set_sep(char c) { S_sep = c; }
        static void set_end(char c) { S_end = c; }
    };
}  // fast::

fast::scanner cin;
fast::printer cout;

#endif  /* !defined(H_fast_io) */

void sprint(int64_t x) {
    if (x == 0) {
        putchar_unlocked('0');
        return;
    }
    if (x < 0) {
        putchar_unlocked('-');
        x *= -1;
    }
    int s = 0;
    char f[15];
    while (x) {
        f[s++] = x % 10;
        x /= 10;
    }
    while (s--)
        putchar_unlocked(f[s] + '0');
    putchar_unlocked('\n');
}

int32_t a[200000];
int main() {
	uint32_t n;
	cin.scan(n);
	for (size_t i = 0; i < n; i++) cin.scan(a[i]);
	int64_t res;
	if (n & 1) {
		//Odd
		int64_t sum = 0;
		for (size_t i = 0; i < n - 1; i += 2) sum += a[i];
		res = sum;
		int64_t tailDiff = 0, tailDiffMax = 0;
		for (int i = n - 3; i >= 0; i -= 2)
		{
			sum -= a[i]; sum += a[i + 1];
			tailDiff += a[i + 2]; tailDiff -= a[i + 1];
			tailDiffMax = std::max(tailDiffMax, tailDiff);
			res = std::max(res, sum + tailDiffMax);
		}
	}
	else {
		//Even
		int64_t sum = 0;
		for (size_t i = 0; i < n; i += 2) sum += a[i];
		res = sum;
		for (int i = n - 1; i >= 0; i -= 2)
		{
			sum += a[i]; sum -= a[i - 1];
			res = std::max(res, sum);
		}
	}
	sprint(res);
}
