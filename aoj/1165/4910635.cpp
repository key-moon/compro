// detail: https://onlinejudge.u-aizu.ac.jp/status/users/keymoon/submissions/1/1165/judge/4910635/C++14
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
	int N;
	cin >> N;
	if (N == 0) return 0;
	vector<int> ys { 0 };
	vector<int> xs { 0 };
	for (int i = 1; i < N; i++) {
		int n, d;
		cin >> n >> d;
		ys.push_back(ys[n] + dys[d]);
		xs.push_back(xs[n] + dxs[d]);
	}
	var f = [](vector<int> a) {
		int mx = 0, mn = 0;
		for (auto& item : a) {
			chmax(mx, item);
			chmin(mn, item);
		}
		return mx - mn + 1;
	};
	cout << f(xs) << " " << f(ys) << endl;
	main();
}

