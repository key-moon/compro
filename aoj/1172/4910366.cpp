// detail: https://onlinejudge.u-aizu.ac.jp/status/users/keymoon/submissions/1/1172/judge/4910366/C++14
#include <bits/stdc++.h>

using ll = long long;
const char newl = '\n';
#define var auto

using namespace std;

template<typename T1, typename T2> inline void chmin(T1& a, T2 b) { if (a > b) a = b; }
template<typename T1, typename T2> inline void chmax(T1& a, T2 b) { if (a < b) a = b; }

int w, h;
vector<vector<int>> grid;
vector<vector<int>> group;

void fill(int y, int x, int id) {
	if (!(0 <= y && y < h) ||
		!(0 <= x && x < w) ||
		grid[y][x] == 0 || group[y][x] != 0) return;
	group[y][x] = id;
	for (int dy = -1; dy <= 1; dy++) {
		for (int dx = -1; dx <= 1; dx++) {
			fill(y + dy, x + dx, id);
		}
	}
}

signed main() {
	int n;
	cin >> n;
	if (n == 0) return 0;
	int res = 0;
	for (int i = n + 1; i <= n * 2; i++) {
		for (int j = 2; j * j <= i; j++) {
			if (i % j == 0) goto end;
		}
		res++;
	end:;
	}
	cout << res << endl;
	main();
}

