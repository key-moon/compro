// detail: https://onlinejudge.u-aizu.ac.jp/status/users/keymoon/submissions/1/2232/judge/4907981/C++14
#include <bits/stdc++.h>

using ll = long long;
const char newl = '\n';
#define var auto

using namespace std;

template<typename T1, typename T2> inline void chmin(T1& a, T2 b) { if (a > b) a = b; }
template<typename T1, typename T2> inline void chmax(T1& a, T2 b) { if (a < b) a = b; }

int h, w, n;

bool drop(vector<string>& board) {
	bool changed = false;
	for (int i = h - 1; i >= 0; i--) {
		for (int j = 0; j < w; j++) {
			for (int k = 0; k <= i; k++) {
				if (board[k][j] != '.') goto val1;
			}
			continue;
		val1:;
			while (board[i][j] == '.') {
				for (int k = i; k >= 1; k--) {
					board[k][j] = board[k - 1][j];
				}
				board[0][j] = '.';
				changed = true;
			}
		}
	}
	return changed;
}

bool process(vector<string>& board) {
	vector<vector<bool>> mark(h, vector<bool>(w, false));
	for (int i = 0; i < h; i++)
	{
		for (int j = 0; j <= w - n; j++)
		{
			char color = board[i][j];
			if (color == '.') goto nxt1;
			for (int k = j; k < j + n; k++)
				if (color != board[i][k]) goto nxt1;
			for (int k = j; k < j + n; k++)
				mark[i][k] = true;
		nxt1:;
		}
	}

	for (int j = 0; j < w; j++)
	{
		for (int i = 0; i <= h - n; i++)
		{
			char color = board[i][j];
			if (color == '.') goto nxt2;
			for (int k = i; k < i + n; k++)
				if (color != board[k][j]) goto nxt2;
			for (int k = i; k < i + n; k++)
				mark[k][j] = true;
		nxt2:;
		}
	}

	for (int i = 0; i < h; i++)
	{
		for (int j = 0; j < w; j++)
		{
			if (mark[i][j]) board[i][j] = '.';
		}
	}
	bool changed = drop(board);
	return changed;
}

bool is_emp(vector<string>& board) {
	for (int i = 0; i < h; i++)
	{
		for (int j = 0; j < w; j++)
		{
			if (board[i][j] != '.') return false;
		}
	}
	return true;
}

signed main() {
	cin >> h >> w >> n;
	vector<string> v(h);
	for (int i = 0; i < h; i++) cin >> v[i];
	
	for (int i = 0; i < h; i++)
	{
		for (int j = 0; j < w - 1; j++)
		{
			//if (v[i][j] == '.' || v[i][j + 1] == '.') continue;
			var board = v;
			swap(board[i][j], board[i][j + 1]);
			drop(board);
			while (process(board));
			if (is_emp(board)) goto valid;
		}
	}

	cout << "NO" << endl;
	return 0;
valid:;
	cout << "YES" << endl;
}


