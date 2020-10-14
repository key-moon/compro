// detail: https://onlinejudge.u-aizu.ac.jp/status/users/keymoon/submissions/1/1160/judge/4910361/C++14
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
	cin >> w >> h;
	if (w == 0) return 0;
	grid = vector<vector<int>>(h, vector<int>(w));
	group = vector<vector<int>>(h, vector<int>(w));
	for (int i = 0; i < h; i++)
		for (int j = 0; j < w; j++)
			cin >> grid[i][j];
	int id = 0;
	for (int i = 0; i < h; i++) {
		for (int j = 0; j < w; j++) {
			if (grid[i][j] == 1 && group[i][j] == 0) fill(i, j, ++id);
		}
	}
	cout << id << endl;
	main();
}

