// detail: https://onlinejudge.u-aizu.ac.jp/status/users/keymoon/submissions/1/2299/judge/5990598/C++17
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
  for (var&& s : grid) cin >> s;

  int res = 0;
  while (true) {


    bool changed = false;
    for (int i = 0; i < h; i++) {
      for (int j = 0; j < w; j++) {
        if (grid[i][j] != '.') continue;
        vector<char*> cs;
        for (int i2 = i; i2 < h; i2++) {
          if (grid[i2][j] != '.') {
            cs.emplace_back(&grid[i2][j]);
            break;
          }
        }
        for (int i2 = i; i2 >= 0; i2--) {
          if (grid[i2][j] != '.') {
            cs.emplace_back(&grid[i2][j]);
            break;
          }
        }

        for (int j2 = j; j2 < w; j2++) {
          if (grid[i][j2] != '.') {
            cs.emplace_back(&grid[i][j2]);
            break;
          }
        }
        for (int j2 = j; j2 >= 0; j2--) {
          if (grid[i][j2] != '.') {
            cs.emplace_back(&grid[i][j2]);
            break;
          }
        }
        for (int i = 0; i < cs.size(); i++) {
          for (int j = i + 1; j < cs.size(); j++) {
            if (*cs[i] == *cs[j] && *cs[i] != '.') {
              *cs[i] = '.';
              *cs[j] = '.';
              res += 2;
              changed = true;
            }
          }
        }
      }
    }
    if (not changed) break;
  }
  cout << res << endl;
}

