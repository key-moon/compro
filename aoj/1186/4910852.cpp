// detail: https://onlinejudge.u-aizu.ac.jp/status/users/keymoon/submissions/1/1186/judge/4910852/C++14
#include <bits/stdc++.h>

using ll = long long;
const char newl = '\n';
#define var auto

using namespace std;

template<typename T1, typename T2> inline void chmin(T1& a, T2 b) { if (a > b) a = b; }
template<typename T1, typename T2> inline void chmax(T1& a, T2 b) { if (a < b) a = b; }

using P = pair<int, int>;

bool compare(P a, P b) {
	var as = a.first * a.first + a.second * a.second;
	var bs = b.first * b.first + b.second * b.second;
	if (as < bs || (as == bs && a.first < b.first)) return true;
	return false;
}

signed main() {
	int h, w;
	cin >> h >> w;
	if (h == 0) return 0;
	P tgt = P(h, w);
	if (h == 0) main();
	P minsq = P(200, 200);
	for (int i = 1; i < 200; i++) {
		for (int j = i + 1; j < 200; j++) {
			P sq = P(i, j);
			if (compare(tgt, sq) && compare(sq, minsq)) {
				minsq = sq;
			}
		}
	}
	cout << minsq.first << " " << minsq.second << endl;
	main();
}

