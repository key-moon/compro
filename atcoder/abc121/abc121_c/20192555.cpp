// detail: https://atcoder.jp/contests/abc121/submissions/20192555
#include <bits/stdc++.h>
#define var auto
using ll = long long;
const char newl = '\n';
template <typename T1, typename T2> inline void chmin(T1& a, T2 b) { if (a > b) a = b; }
template <typename T1, typename T2> inline void chmax(T1& a, T2 b) { if (a < b) a = b; }

using namespace std;

int main() {
	ll n, m;
	cin >> n >> m;
	using P = pair<ll, ll>;
	vector<P> drinks{};
	for (int i = 0; i < n; i++) {
		int a, b;
		cin >> a >> b;
		drinks.emplace_back(a, b);
	}
	sort(drinks.begin(), drinks.end());
	
	ll res = 0;
	for (var&& drink : drinks) {
		var cnt = min(m, drink.second);
		res += cnt * drink.first;
		m -= cnt;
	}
	cout << res << endl;
}
