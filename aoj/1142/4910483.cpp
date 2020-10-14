// detail: https://onlinejudge.u-aizu.ac.jp/status/users/keymoon/submissions/1/1142/judge/4910483/C++14
#include <bits/stdc++.h>

using ll = long long;
const char newl = '\n';
#define var auto

using namespace std;

template<typename T1, typename T2> inline void chmin(T1& a, T2 b) { if (a > b) a = b; }
template<typename T1, typename T2> inline void chmax(T1& a, T2 b) { if (a < b) a = b; }

void solve() {
	set<string> st{};
	string s;
	cin >> s;
	for (int i = 1; i < (int)s.size(); i++) {
		var a = s.substr(0, i);
		var b = s.substr(i);
		var ar = a;
		var br = b;
		reverse(ar.begin(), ar.end());
		reverse(br.begin(), br.end());
		st.insert(a + b);
		st.insert(a + br);
		st.insert(ar + b);
		st.insert(ar + br);
		st.insert(b + a);
		st.insert(br + a);
		st.insert(b + ar);
		st.insert(br + ar);
	}
	cout << st.size() << endl;
}

signed main() {
	int m;
	cin >> m;
	for (int ind = 0; ind < m; ind++) {
		solve();
	}
}

