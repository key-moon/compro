// detail: https://atcoder.jp/contests/abc162/submissions/11876061
#pragma GCC target("avx2")
#pragma GCC optimize("Ofast")

#ifdef _MSC_VER
#include <__msvc_all_public_headers.hpp>
#define getchar_unlocked getchar
#define putchar_unlocked putchar
#else
#include <bits/stdc++.h>
#endif // VS

#define long long long
using namespace std;

#pragma region CS_COMPATIBLE
#define var auto
#define Max std::max
#define Min std::min
#define Abs std::abs
//#define List std::vector;
//#define Add push_back
#pragma endregion

void read(uint32_t& x)
{
	x = 0;
	int k;
	while (true)
	{
		k = getchar_unlocked();
		if (k < '0' || k > '9')	break;
		x = x * 10 + k - '0';
	}
}

void sread(int32_t& x)
{
	bool flag;
	x = 0;
	int k = getchar_unlocked();
	if (flag = (k == '-')) k = getchar_unlocked();

	while (true)
	{
		if (k < '0' || k > '9')	break;
		x = x * 10 + k - '0';
		k = getchar_unlocked();
	}
	if (flag) x *= -1;
}

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
	read(n);
	for (size_t i = 0; i < n; i++) sread(a[i]);
	int64_t res;
	if (n & 1) {
		//Odd
		var sum = 0L;
		for (int i = 0; i < n - 1; i += 2) sum += a[i];
		res = sum;
		int64_t tailDiff = 0, tailDiffMax = 0;
		for (int i = n - 3; i >= 0; i -= 2)
		{
			sum -= a[i]; sum += a[i + 1];
			tailDiff += a[i + 2]; tailDiff -= a[i + 1];
			tailDiffMax = max(tailDiffMax, tailDiff);
			res = max(res, sum + tailDiffMax);
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
			res = max(res, sum);
		}
	}
	sprint(res);
}
