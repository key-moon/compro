// detail: https://onlinejudge.u-aizu.ac.jp/status/users/keymoon/submissions/1/2000/judge/4907979/C++14
#include <bits/stdc++.h>

using ll = long long;
const char newl = '\n';
#define var auto

using namespace std;

template<typename T1, typename T2> inline void chmin(T1& a, T2 b) { if (a > b) a = b; }
template<typename T1, typename T2> inline void chmax(T1& a, T2 b) { if (a < b) a = b; }

signed main() {
	while (true) {
		int n;
		cin >> n;
		if (n == 0) break;
		vector<vector<int>> gem(101, vector<int>(101));
		for (size_t i = 0; i < n; i++)
		{
			int y, x;
			cin >> x >> y;
			gem[y][x] += 1;
		}
		int cury = 10, curx = 10;
		n -= gem[cury][curx]; gem[cury][curx] = 0;
		int m;
		cin >> m;
		for (size_t i = 0; i < m; i++)
		{
			char dir; int d;
			cin >> dir >> d;
			int dy = 0, dx = 0;
			switch (dir)
			{
			case 'N':
				dy = 1;
				break;
			case 'E':
				dx = 1;
				break;
			case 'S':
				dy = -1;
				break;
			case 'W':
				dx = -1;
				break;
			}
			for (size_t i = 0; i < d; i++)
			{
				cury += dy;
				curx += dx;
				n -= gem[cury][curx]; gem[cury][curx] = 0;
			}
		}
		if (n == 0) cout << "Yes";
		else cout << "No";
		cout << endl;
	}
}


