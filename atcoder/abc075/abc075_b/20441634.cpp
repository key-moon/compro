// detail: https://atcoder.jp/contests/abc075/submissions/20441634
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
  for (int i = 0; i < h; i++) {
    cin >> grid[i];
    for (int j = 0; j < w; j++)
      if (grid[i][j] == '.') grid[i][j] = '0';
  }
  for (int i = 0; i < h; i++) {
    for (int j = 0; j < w - 1; j++) {
      if (grid[i][j] == '#' && grid[i][j + 1] != '#') grid[i][j + 1]++;
      if (grid[i][j + 1] == '#' && grid[i][j] != '#') grid[i][j]++;
    }
  }
  for (int i = 0; i < h - 1; i++) {
    for (int j = 0; j < w; j++) {
      if (grid[i][j] == '#' && grid[i + 1][j] != '#') grid[i + 1][j]++;
      if (grid[i + 1][j] == '#' && grid[i][j] != '#') grid[i][j]++;
    }
  }
  for (int i = 0; i < h - 1; i++) {
    for (int j = 0; j < w - 1; j++) {
      if (grid[i][j] == '#' && grid[i + 1][j + 1] != '#') grid[i + 1][j + 1]++;
      if (grid[i + 1][j + 1] == '#' && grid[i][j] != '#') grid[i][j]++;

      if (grid[i][j + 1] == '#' && grid[i + 1][j] != '#') grid[i + 1][j]++;
      if (grid[i + 1][j] == '#' && grid[i][j + 1] != '#') grid[i][j + 1]++;
    }
  }
  for (var&& s : grid) {
    cout << s << endl;
  }
}
