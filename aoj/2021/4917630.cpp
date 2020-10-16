// detail: https://onlinejudge.u-aizu.ac.jp/status/users/keymoon/submissions/1/2021/judge/4917630/C++14
#include <bits/stdc++.h>

using ll = long long;
const char newl = '\n';
#define var auto

using namespace std;

template<typename T1, typename T2> inline void chmin(T1& a, T2 b) { if (a > b) a = b; }
template<typename T1, typename T2> inline void chmax(T1& a, T2 b) { if (a < b) a = b; }

signed main() {
	int n, m, l, k, a, h;
	cin >> n >> m >> l >> k >> a >> h;
	if (n == 0) return 0;
	using P = pair<int, int>;
	vector<int> ps(l);
	for (int i = 0; i < l; i++) {
		cin >> ps[i];
	}
	ps.push_back(a);
	ps.push_back(h);

	vector<vector<int>> dists(n, vector<int>(n, INT32_MAX / 2));
	for (int i = 0; i < n; i++) {
		dists[i][i] = 0;
	}
	for (int i = 0; i < k; i++) {
		int x, y, t;
		cin >> x >> y >> t;
		dists[x][y] = t;
		dists[y][x] = t;
	}
	for (int i = 0; i < n; i++) {
		for (int j = 0; j < n; j++) {
			for (int k = 0; k < n; k++) {
				dists[j][k] = min(dists[j][k], dists[j][i] + dists[i][k]);
			}
		}
	}
	vector<vector<int>> pdists(ps.size(), vector<int>(ps.size(), INT32_MAX / 2));
	for (int i = 0; i < ps.size(); i++) {
		for (int j = 0; j < ps.size(); j++) {
			if (m < dists[ps[i]][ps[j]]) continue;
			pdists[i][j] = dists[ps[i]][ps[j]];
		}
	}

	for (int i = 0; i < ps.size(); i++) {
		for (int j = 0; j < ps.size(); j++) {
			for (int k = 0; k < ps.size(); k++) {
				pdists[j][k] = min(pdists[j][k], pdists[j][i] + pdists[i][k]);
			}
		}
	}

	var res = pdists[l][l + 1];
	if (res == INT32_MAX / 2) cout << "Help!" << endl;
	else cout << res + max(0, res - m) << endl;
	main();
}

