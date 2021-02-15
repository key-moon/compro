// detail: https://atcoder.jp/contests/abc121/submissions/20192510
#include <bits/stdc++.h>
#define var auto
using ll = long long;
const char newl = '\n';
template <typename T1, typename T2> inline void chmin(T1& a, T2 b) { if (a > b) a = b; }
template <typename T1, typename T2> inline void chmax(T1& a, T2 b) { if (a < b) a = b; }

using namespace std;

int main() {
	int n, m, c;
	cin >> n >> m >> c;
	vector<int> b(m);
	for (int i = 0; i < m; i++) cin >> b[i];
	int res = 0;
	for (int i = 0; i < n; i++) {
		int val = 0;
		for (int j = 0; j < m; j++) {
			int a;
			cin >> a;
			val += b[j] * a;
		}
		val += c;
		if (val > 0) res++;
	}
	cout << res << endl;
}
