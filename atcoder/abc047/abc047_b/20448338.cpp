// detail: https://atcoder.jp/contests/abc047/submissions/20448338
#include<bits/stdc++.h>
using ll = long long;
#define var auto
const char newl = '\n';

using namespace std;

template<typename T1, typename T2> inline void chmin(T1& a, T2 b) { if (a > b) a = b; }
template<typename T1, typename T2> inline void chmax(T1& a, T2 b) { if (a < b) a = b; }

int main() {
  int w, h, n;
  cin >> w >> h >> n;
  vector<vector<bool>> f(h, vector<bool>(w, true));
  for (int iter = 0; iter < n; iter++) {
    int x, y, a;
    cin >> x >> y >> a;
    int lx = 0;
    int ux = w - 1;
    int ly = 0;
    int uy = h - 1;
    if (a == 1) ux = x - 1;
    if (a == 2) lx = x;
    if (a == 3) uy = y - 1;
    if (a == 4) ly = y;
    for (int i = ly; i <= uy; i++)
      for (int j = lx; j <= ux; j++)
        f[i][j] = false;
  }
  int res = 0;
  for (int i = 0; i < h; i++)
    for (int j = 0; j < w; j++)
      if (f[i][j])
        res++;
  cout << res << endl;
}
