// detail: https://onlinejudge.u-aizu.ac.jp/status/users/keymoon/submissions/1/2011/judge/4917175/C++14
#include <bits/stdc++.h>

using ll = long long;
const char newl = '\n';
#define var auto

using namespace std;

template<typename T1, typename T2> inline void chmin(T1& a, T2 b) { if (a > b) a = b; }
template<typename T1, typename T2> inline void chmax(T1& a, T2 b) { if (a < b) a = b; }

signed main() {
	int n;
	cin >> n;
	if (n == 0) return 0;
	vector<vector<int>> ps(31);
	for (int i = 0; i < n; i++) {
		int m;
		cin >> m;
		for (int j = 0; j < m; j++) {
			int a;
			cin >> a;
			ps[a].push_back(i);
		}
	}
	//r[i][j] := iからjに到達できるか
	vector<vector<bool>> r(n, vector<bool>(n));
	for (int i = 0; i < n; i++) {
		r[i][i] = true;
	}
	for (int i = 1; i <= 30; i++) {
		vector<bool> exchange(n);
		for (auto& item : ps[i]) {
			for (int j = 0; j < n; j++) {
				exchange[j] = exchange[j] | r[j][item];
			}
		}
		for (auto& item : ps[i]) {
			for (int j = 0; j < n; j++) {
				r[j][item] = exchange[j];
			}
		}
		var res1 = false;
		for (int i = 0; i < n; i++) {
			var res2 = true;
			for (int j = 0; j < n; j++) {
				res2 &= r[j][i];
			}
			res1 |= res2;
		}
		if (res1) {
			cout << i << endl;
		goto end;
		}
	}
	cout << -1 << endl;
end:;
	main();
}

