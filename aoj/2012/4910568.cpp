// detail: https://onlinejudge.u-aizu.ac.jp/status/users/keymoon/submissions/1/2012/judge/4910568/C++14
#include <bits/stdc++.h>

using ll = long long;
const char newl = '\n';
#define var auto

using namespace std;

template<typename T1, typename T2> inline void chmin(T1& a, T2 b) { if (a > b) a = b; }
template<typename T1, typename T2> inline void chmax(T1& a, T2 b) { if (a < b) a = b; }

signed main() {
	int m;
	cin >> m;
	if (m == 0) return 0;
	int res = INT_MAX;
	for (int z = 0; z * z * z <= m; z++) {
		int rem = m - z * z * z;
		for (int y = 0; y * y <= rem; y++) {
			int x = rem - y * y;
			chmin(res, x + y + z);
		}
	}
	cout << res << endl;
	main();
}

