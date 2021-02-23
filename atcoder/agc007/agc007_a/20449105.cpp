// detail: https://atcoder.jp/contests/agc007/submissions/20449105
#include<bits/stdc++.h>
using ll = long long;
#define var auto
const char newl = '\n';

using namespace std;

template<typename T1, typename T2> inline void chmin(T1& a, T2 b) { if (a > b) a = b; }
template<typename T1, typename T2> inline void chmax(T1& a, T2 b) { if (a < b) a = b; }

int main() {
  int h, w;
  cin >> h >> w;
  int y = 0, x = 0;
  vector<string> grid(h);
  for (int i = 0; i < h; i++) cin >> grid[i];
  while (true) {
    grid[y][x] = '.';
    if (x != w - 1 && grid[y][x + 1] == '#') {
      x++;
      continue;
    }
    if (y != h - 1 && grid[y + 1][x] == '#') {
      y++;
      continue;
    }
    break;
  }
  for (int i = 0; i < h; i++) {
    for (int j = 0; j < w; j++) {
      if (grid[i][j] == '#') {
        cout << "Impossible" << endl;
        return 0;
      }
    }
  }
  cout << "Possible" << endl;
}
