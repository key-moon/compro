// detail: https://onlinejudge.u-aizu.ac.jp/status/users/keymoon/submissions/1/3202/judge/6026019/C++17
#include<bits/stdc++.h>
using ll = long long;
#define var auto
const char newl = '\n';

using namespace std;

template<typename T1, typename T2> inline void chmin(T1& a, T2 b) { if (a > b) a = b; }
template<typename T1, typename T2> inline void chmax(T1& a, T2 b) { if (a < b) a = b; }

bool solve() {
  int w, h, n, d, b;
  cin >> w >> h >> n >> d >> b;
  if (n == 0) return false;
  vector<vector<int>> board(h, vector<int>(w));
  stack<pair<int, int>> st{};
  ll res = 0;
  for (int i = 0; i < n; i++) {
    int x, y;
    cin >> x >> y;
    y--; x--;
    if (i == b - 1) {
      st.emplace(y, x);
    }
    else {
      board[y][x] = 1;
    }
  }
  var check = [&](int y, int x) {
    if (0 <= y && y < h && 0 <= x && x < w && board[y][x]) {
      board[y][x] = 0;
      st.emplace(y, x);
    }
  };
  while (!st.empty()) {
    var[y, x] = st.top(); st.pop();
    res++;
    for (int i = 1; i <= d; i++) {
      check(y + i, x);
      check(y - i, x);
      check(y, x + i);
      check(y, x - i);
    }
  }
  cout << res << endl;
  return true;
}

int main() {
  ios::sync_with_stdio(false);
  cin.tie(nullptr);
  while (solve());
}


