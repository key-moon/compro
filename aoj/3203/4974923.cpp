// detail: https://onlinejudge.u-aizu.ac.jp/status/users/keymoon/submissions/1/3203/judge/4974923/C++17
//This code was written at a mock domestic contest on 2020/10/25

#include <bits/stdc++.h>
using namespace std;

using ll = long long;
#define var auto

const char newl = '\n';

template< typename T1, typename T2 >
inline void chmin(T1 &a, T2 b) { if (a > b) a = b; }
template< typename T1, typename T2 >
inline void chmax(T1 &a, T2 b) { if (a < b) a = b; }

int main(){
  int n;
  cin >> n;
  if (n == 0) return 0;
  int sx, sy, gx, gy;
  cin >> sx >> sy >> gx >> gy;
  int offx = sx, offy = sy;
  sx -= offx, sy -= offy, gx -= offx, gy -= offy;
  int parx = gx < 0 ? -1 : 1;
  int pary = gy < 0 ? -1 : 1;
  gx *= parx, gy *= pary;
  using P = pair<int, int>;
  using PP = pair<P, int>;
  
  vector<PP> ses{};
  vector<vector<int>> dadds(gy + 1, vector<int>(gx + 1));
  vector<vector<int>> radds(gy + 1, vector<int>(gx + 1));
  int init = 0;
  var incr = [&](vector<vector<int>>& v, int i, int j){
    if (i < 0 || gy < i || j < 0 || gx < j) return;
    v[i][j]++;
    return;
  };
  for (int i = 0; i < n; i++){
    int x, y, r;
    cin >> x >> y >> r;
    y = (y - offy) * pary;
    x = (x - offx) * parx;
    var tx = x - r, ty = y - r;
    var bx = x + r, by = y + r;
    if (ty <= 0 && 0 <= by && tx <= 0 && 0 <= bx){
      init++;
      continue;
    }
    for (int i = tx; i <= bx; i++){
      incr(dadds, ty, i);
    }
    for (int i = ty; i <= by; i++){
      incr(radds, i, tx);
    }

    /*cout << endl;
    cout << x << " " << y << " " << r << endl;
    cout << tx << " " << ty << bx << " " << by << endl;    
    for (int i = 0; i <= gy; i++){
      for (int j = 0; j <= gx; j++){
        cout << (radds[i][j] | dadds[i][j] ? "#" : ".");
      }
      cout << endl;
    }*/
  }
  vector<vector<int>> dp(gy + 1, vector<int>(gx + 1, INT32_MAX / 2));
  {
    dp[0][0] = init;
    for (int j = 1; j <= gx; j++){
      dp[0][j] = dp[0][j - 1] + radds[0][j];
    }
  }
  for (int i = 1; i <= gy; i++){
    dp[i][0] = dp[i - 1][0] + dadds[i][0];
    for (int j = 1; j <= gx; j++){
      dp[i][j] = min(dp[i][j - 1] + radds[i][j], dp[i - 1][j] + dadds[i][j]);
    }
  }
  cout << dp[gy][gx] << endl;
  main();
}

