// detail: https://onlinejudge.u-aizu.ac.jp/status/users/keymoon/submissions/1/2945/judge/6005476/C++17
#include<bits/stdc++.h>
using ll = long long;
#define var auto
const char newl = '\n';

using namespace std;

template<typename T1, typename T2> inline void chmin(T1& a, T2 b) { if (a > b) a = b; }
template<typename T1, typename T2> inline void chmax(T1& a, T2 b) { if (a < b) a = b; }

int y_1, x_1, y_2, x_2;

int dist(int _y1, int _x1, int _y2, int _x2) {
  return abs(_y1 - _y2) + abs(_x1 - _x2);
}

int dist_to_land(int y, int x) {
  bool y_in = y_1 <= y && y <= y_2;
  bool x_in = x_1 <= x && x <= x_2;
  if (y_in && x_in) return 0;
  if (y_in) return min(abs(x - x_1), abs(x - x_2));
  if (x_in) return min(abs(y - y_1), abs(y - y_2));
  int res = INT32_MAX;
  chmin(res, dist(y, x, y_1, x_1));
  chmin(res, dist(y, x, y_1, x_2));
  chmin(res, dist(y, x, y_2, x_1));
  chmin(res, dist(y, x, y_2, x_2));
  return res;
}

bool solve() {
  int n;
  cin >> n;
  if (n == 0) return false;
  cin >> y_1 >> x_1 >> y_2 >> x_2;
  
  ll res = 0;
  int y_prev, x_prev;
  cin >> y_prev >> x_prev;
  for (int i = 0; i < n; i++) {
    int y, x;
    cin >> y >> x;
    res += min(dist(y_prev, x_prev, y, x), max(dist_to_land(y_prev, x_prev) - 1, 0) + dist_to_land(y, x));
    y_prev = y;
    x_prev = x;
  }
  cout << res << endl;
  return true;
}

int main() {
  ios::sync_with_stdio(false);
  cin.tie(nullptr);
  while (solve());
}

