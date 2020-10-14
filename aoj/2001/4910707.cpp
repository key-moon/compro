// detail: https://onlinejudge.u-aizu.ac.jp/status/users/keymoon/submissions/1/2001/judge/4910707/C++17
#include <bits/stdc++.h>

using ll = long long;
const char newl = '\n';
#define var auto

using namespace std;

template<typename T1, typename T2> inline void chmin(T1& a, T2 b) { if (a > b) a = b; }
template<typename T1, typename T2> inline void chmax(T1& a, T2 b) { if (a < b) a = b; }

int dxs[4] = { -1, 0, 1, 0 };
int dys[4] = { 0, -1, 0, 1 };

signed main() {
	int n, m, a;
	cin >> n >> m >> a;
	if (n == 0) return 0;
	using P = pair<int, pair<int, int>>;
	vector<P> lines(m);
	for (int i = 0; i < m; i++) {
		int h, p, q;
		cin >> h >> p >> q;
		lines.push_back(P(-h, pair<int, int>(p, q)));
	}
	sort(lines.begin(), lines.end());
	for (auto& item : lines) {
		var p = item.second.first;
		var q = item.second.second;
		if (a == p) a = q;
		else if (a == q) a = p;
	}
	cout << a << endl;
	main();
}

