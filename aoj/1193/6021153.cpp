// detail: https://onlinejudge.u-aizu.ac.jp/status/users/keymoon/submissions/1/1193/judge/6021153/C++17
#include<bits/stdc++.h>
using ll = long long;
#define var auto
const char newl = '\n';

using namespace std;

template<typename T1, typename T2> inline void chmin(T1& a, T2 b) { if (a > b) a = b; }
template<typename T1, typename T2> inline void chmax(T1& a, T2 b) { if (a < b) a = b; }

bool solve() {
  int n;
  cin >> n;
  if (n == 0) return false;
  vector<vector<int>> board(n, vector<int>(5));
  
  for (var&& row : board) {
    for (var&& elem : row) cin >> elem;
  }

  ll res = 0;
  while (true) {
    bool removed = false;

    for (var&& row : board) {
      int i = 0;
      while (i < row.size()) {
        if (row[i] != 0) {
          var val = row[i];
          int same_until = i;
          while (same_until < row.size() && row[same_until] == row[i]) same_until++;
          var cnt = same_until - i;
          if (3 <= cnt) {
            for (int j = i; j < same_until; j++) {
              assert(row[j] == val);
              res += row[j];
              row[j] = 0;
              removed = true;
            }
          }
        }
        i++;
      }
    }

    for (int j = 0; j < 5; j++) {
      int nxt = n - 1;
      for (int i = n - 1; i >= 0; i--) {
        if (board[i][j] == 0) continue;
        board[nxt][j] = board[i][j];
        nxt--;
      }
      while (nxt >= 0) {
        board[nxt][j] = 0;
        nxt--;
      }
    }

    if (not removed) break;
  }

  cout << res << endl;
  return true;
}

int main() {
  ios::sync_with_stdio(false);
  cin.tie(nullptr);
  while (solve()){}
}

