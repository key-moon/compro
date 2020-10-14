// detail: https://onlinejudge.u-aizu.ac.jp/status/users/keymoon/submissions/1/1141/judge/4910378/C++14
#include <bits/stdc++.h>

using ll = long long;
const char newl = '\n';
#define var auto

using namespace std;

template<typename T1, typename T2> inline void chmin(T1& a, T2 b) { if (a > b) a = b; }
template<typename T1, typename T2> inline void chmax(T1& a, T2 b) { if (a < b) a = b; }

signed main() {
	int a, d, n;
	cin >> a >> d >> n;
	if (a == 0) return 0;
	int ctr = 0;
	for (int i = a; ; i += d) {
		if (i == 1) goto end;
		for (int j = 2; j * j <= i; j++) {
			if (i % j == 0) goto end;
		}
		ctr++;
		if (ctr == n) {
			cout << i << endl;
			break;
		}
	end:;
	}
	main();
}

