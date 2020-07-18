// detail: https://onlinejudge.u-aizu.ac.jp/status/users/keymoon/submissions/1/1130/judge/4680029/C++14
#include <bits/stdc++.h>

//#define var auto
#define ll long long

using namespace std;

int ans = 0;
int h, w;
vector<string> grid;
vector<vector<bool>> arrived;
void dfs(int y, int x) {
	if (y < 0 || h <= y || x < 0 || w <= x) return;
	if (grid[y][x] == '#') return;
	if (arrived[y][x])return;
	arrived[y][x] = true;
	ans++;
	dfs(y - 1, x);
	dfs(y, x + 1);
	dfs(y + 1, x);
	dfs(y, x - 1);
}

int main() {
	while (true)
	{
		cin >> w >> h;
		if (w == 0) break;
		grid = vector<string>(h);
		arrived = vector<vector<bool>>(20, vector<bool>(20, false));
		ans = 0;
		for (int i = 0; i < h; i++) {
			cin >> grid[i];
		}
		int sy, sx;
		for (int i = 0; i < h; i++) {;
			for (int j = 0; j < w; j++) {
				if (grid[i][j] == '@') {
					sy = i;
					sx = j;
				}
			}
		}
		dfs(sy, sx);
		cout << ans << endl;
	}
}

