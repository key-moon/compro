// detail: https://onlinejudge.u-aizu.ac.jp/status/users/keymoon/submissions/1/1188/judge/4916917/C++14
#include <bits/stdc++.h>

using ll = long long;
const char newl = '\n';
#define var auto

using namespace std;

template<typename T1, typename T2> inline void chmin(T1& a, T2 b) { if (a > b) a = b; }
template<typename T1, typename T2> inline void chmax(T1& a, T2 b) { if (a < b) a = b; }

using P = pair<int, int>;

string s;

int solve(int& i) {
	int num = 0;
	vector<int> v{};
	while (true) {
		if (s[i] == '[') {
			i++; v.push_back(solve(i));
		}
		else if (s[i] == ']') {
			i++; break;
		}
		else {
			num = num * 10 + s[i] - '0';
			i++;
		}
	}
	if (num != 0) return num / 2 + 1;
	sort(v.begin(), v.end());
	int res = 0;
	for (int i = 0; i <= v.size() / 2; i++) {
		res += v[i];
	}
	return res;
}

void solve() {
	cin >> s;
	int i = 1;
	cout << solve(i) << endl;
}

signed main() {
	int t;
	cin >> t;
	for (int i = 0; i < t; i++) {
		solve();
	}
}

