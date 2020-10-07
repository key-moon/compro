// detail: https://onlinejudge.u-aizu.ac.jp/status/users/keymoon/submissions/1/1600/judge/4895124/C++14
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
    int m, nmin, nmax;
    cin >> m >> nmin >> nmax;
    if (m == 0) break;
    vector<int> ps(m);
    for (int i = 0; i < m; i++){
      cin >> ps[i];
    }
    sort(ps.begin(), ps.end());

    int maxgap = -1;
    int maxn = 0;
    for (int i = m - nmin; i >= m - nmax; i--){
      var gap = ps[i] - ps[i - 1];
      if (gap >= maxgap) {
        maxgap = gap;
        maxn = m - i;
      }
    }
    cout << maxn << endl;
  }
  return 0;
}

