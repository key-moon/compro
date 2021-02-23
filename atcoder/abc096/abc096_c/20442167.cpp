// detail: https://atcoder.jp/contests/abc096/submissions/20442167
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
  vector<string> grid(h);
  vector<vector<bool>> valid(h, vector<bool>(w));
  for (int i = 0; i < h; i++) cin >> grid[i];
  for (int i = 0; i < h; i++) {
    for (int j = 0; j < w - 1; j++) {
      if (grid[i][j] == grid[i][j + 1]) valid[i][j] = valid[i][j + 1] = true;
    }
  }
  for (int i = 0; i < h - 1; i++) {
    for (int j = 0; j < w; j++) {
      if (grid[i][j] == grid[i + 1][j]) valid[i][j] = valid[i + 1][j] = true;
    }
  }

  for (int i = 0; i < h; i++) {
    for (int j = 0; j < w; j++) {
      if (grid[i][j] == '#' && !valid[i][j]) {
        cout << "No" << endl;
        return 0;
      }
    }
  }
  cout << "Yes" << endl;
}
