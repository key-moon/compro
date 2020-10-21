// detail: https://onlinejudge.u-aizu.ac.jp/status/users/keymoon/submissions/1/1618/judge/4930536/C++17
#include <bits/stdc++.h>
using namespace std;

using ll = long long;
#define var auto

const char newl = '\n';

template<typename T1, typename T2> inline void chmin(T1 &a, T2 b) { if (a > b) a = b; }
template<typename T1, typename T2> inline void chmax(T1 &a, T2 b) { if (a < b) a = b; }

signed main() {
  ios::sync_with_stdio(false);
  int h, w;
  cin >> h >> w;
  if (h == 0) return 0;
  vector<vector<int>> g(h, vector<int>(w));
  for (int i = 0; i < h; i++){
    for (int j = 0; j < w; j++){
      cin >> g[i][j];
    }
  }
  int res = 0;
  for (int sy = 0; sy < h; sy++){
    for (int sx = 0; sx < w; sx++){
      for (int gy = sy + 2; gy < h; gy++){
        for (int gx = sx + 2; gx < w; gx++){
          int im = -1;
          int is = 0;
          int em = INT_MAX;
          for (int i = 0; i < h; i++){
            for (int j = 0; j < w; j++){
              var iny = sy < i && i < gy;
              var inx = sx < j && j < gx;
              var ony = i == sy || i == gy;
              var onx = j == sx || j == gx;
              if (((ony || iny) && onx) || ((onx || inx) && ony)){
                chmin(em, g[i][j]);
              }
              if (iny && inx){
                chmax(im, g[i][j]);
                is += g[i][j];
              }
            }
          }
          if (im >= em) continue;
          var sz = (gy - sy - 1) * (gx - sx - 1) * em - is;
          chmax(res, sz);
        }
      }
    }
  }
  cout << res << endl;
  main();
}

