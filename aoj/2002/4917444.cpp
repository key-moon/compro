// detail: https://onlinejudge.u-aizu.ac.jp/status/users/keymoon/submissions/1/2002/judge/4917444/C++14
#include <bits/stdc++.h>

using ll = long long;
const char newl = '\n';
#define var auto

using namespace std;

template<typename T1, typename T2> inline void chmin(T1& a, T2 b) { if (a > b) a = b; }
template<typename T1, typename T2> inline void chmax(T1& a, T2 b) { if (a < b) a = b; }

void solve() {
	int h, w;
	cin >> h >> w;
	vector<string> pic(h);
	set<char> kinds{};
	for (int i = 0; i < h; i++) {
		cin >> pic[i];
		for (auto& c : pic[i]) {
			kinds.insert(c);
		}
	}
	kinds.erase('.');
	while (!kinds.empty()) {
		for (auto& c : kinds) {
			int miny = h, maxy = -1, minx = w, maxx = -1;
			for (int i = 0; i < h; i++) {
				for (int j = 0; j < w; j++) {
					if (pic[i][j] != c) continue;
					chmin(miny, i);
					chmax(maxy, i);
					chmin(minx, j);
					chmax(maxx, j);
				}
			}

			for (int i = miny; i <= maxy; i++) {
				for (int j = minx; j <= maxx; j++) {
					if (pic[i][j] != c && pic[i][j] != '#') goto next;
				}
			}
			for (int i = miny; i <= maxy; i++) {
				for (int j = minx; j <= maxx; j++) {
					pic[i][j] = '#';
				}
			}
			kinds.erase(c);
			goto end;
		next:;
		}
		cout << "SUSPICIOUS" << endl;
		return;
		end:;
	}
	cout << "SAFE" << endl;
}

signed main() {
	int t;
	cin >> t;
	for (int i = 0; i < t; i++) {
		solve();
	}
}

