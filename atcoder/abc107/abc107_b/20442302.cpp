// detail: https://atcoder.jp/contests/abc107/submissions/20442302
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
  vector<string> grid{};
  for (int i = 0; i < h; i++) {
    string s;
    cin >> s;
    if (count(s.begin(), s.end(), '#') == 0) continue;
    grid.emplace_back(s);
  }
  for (int i = 0; i < grid[0].size();) {
    for (var&& s : grid) {
      if (s[i] == '#') goto valid;
    }
    for (var&& s : grid) {
      s.erase(i, 1);
    }
    continue;
  valid:;
    i++;
  }
  for (var&& s : grid) {
    cout << s << endl;
  }
}
