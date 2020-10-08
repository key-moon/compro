// detail: https://onlinejudge.u-aizu.ac.jp/status/users/keymoon/submissions/1/1125/judge/4898385/C++14
#include <bits/stdc++.h>
using namespace std;

using ll = long long;
const char newl = '\n';
#define var auto

template<typename T1,typename T2> inline void chmin(T1 &a,T2 b){if(a>b) a=b;}
template<typename T1,typename T2> inline void chmax(T1 &a,T2 b){if(a<b) a=b;}

signed main(){
  cin.tie(0);
  ios::sync_with_stdio(0);
  while (1){
  int n;
  cin >> n;
  if (n == 0) return 0;

  int w, h;
  cin >> w >> h;
  vector<vector<int>> m(h, vector<int>(w));
  for (int i = 0; i < n; i++){
    int x, y;
    cin >> x >> y;
    m[y - 1][x - 1]++;
  }
  int s, t;
  cin >> s >> t;
  int res = 0;
  for (int i = t; i <= h; i++){
    for (int j = s; j <= w; j++){
      int sum = 0;
      for (int k = i - t; k < i; k++){
        for (int l = j - s; l < j; l++){
          sum += m[k][l];
        }
      }
      chmax(res, sum);
    }
  }
  cout << res << endl;
  }
  return 0;
}
