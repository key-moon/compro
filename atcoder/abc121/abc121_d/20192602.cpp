// detail: https://atcoder.jp/contests/abc121/submissions/20192602
#include <bits/stdc++.h>
#define var auto
using ll = long long;
const char newl = '\n';
template <typename T1, typename T2> inline void chmin(T1& a, T2 b) { if (a > b) a = b; }
template <typename T1, typename T2> inline void chmax(T1& a, T2 b) { if (a < b) a = b; }

using namespace std;

ll solve(ll a) {
	if (a < 0) return 0;
	ll res = (a & 1) ? 1 : a;
	if (2 <= a % 4) res ^= 1;
	return res;
}

int main() {
	ll a, b;
	cin >> a >> b;
	cout << (solve(b) ^ solve(a - 1)) << endl;
}
