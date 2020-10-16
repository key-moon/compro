// detail: https://onlinejudge.u-aizu.ac.jp/status/users/keymoon/submissions/1/1149/judge/4916799/C++14
#include <bits/stdc++.h>

using ll = long long;
const char newl = '\n';
#define var auto

using namespace std;

template<typename T1, typename T2> inline void chmin(T1& a, T2 b) { if (a > b) a = b; }
template<typename T1, typename T2> inline void chmax(T1& a, T2 b) { if (a < b) a = b; }

using P = pair<int, int>;

signed main() {
	int n, w, h;
	cin >> n >> w >> h;
	if (w == 0) return 0;
	vector<P> v{ P(w, h) };
	for (int i = 0; i < n; i++) {
		int p, s;
		cin >> p >> s;
		p--;
		var pos = v[p];
		v.erase(v.begin() + p);
		var x = pos.first, y = pos.second;
		s %= x + y;
		P a, b;
		if (s < x) {
			a = P(s, y); b = P(x - s, y);
		}
		else {
			s -= x;
			a = P(x, s); b = P(x, y - s);
		}
		if (a.first * a.second > b.first * b.second) swap(a, b);
		v.push_back(a); v.push_back(b);
	}
	sort(v.begin(), v.end(), [](P a, P b) { return (a.first * a.second) < (b.first * b.second); });
	for (int i = 0; i < n + 1; i++) {
		if (i != 0) cout << ' ';
		cout << v[i].first * v[i].second;
	}
	cout << endl;
	main();
}

